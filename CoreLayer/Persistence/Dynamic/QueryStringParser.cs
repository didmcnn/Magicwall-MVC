using CoreLayer.Persistence.Request;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.WebUtilities;
using System.Reflection;

namespace CoreLayer.Persistence.Dynamic;

public static class QueryStringParser
{
    public static GetListQuery Parse(string queryString, Type entityType)
    {
        var queryDictionary = QueryHelpers.ParseQuery(queryString);

        int start = queryDictionary.TryGetValue("start", out var startValue) ? int.Parse(startValue) : 0;
        int length = queryDictionary.TryGetValue("length", out var lengthValue) ? int.Parse(lengthValue) : 10;
        int page = start != 0 ? (start / length) : 0;

        var pageRequest = new PageRequest
        {
            Page = page,
            PageSize = length
        };

        var sortList = new List<Sort>();
        var columns = new Dictionary<int, string>();

        foreach (var key in queryDictionary.Keys.Where(k => k.StartsWith("columns[") && k.EndsWith("][data]")))
        {
            var columnIndex = int.Parse(key.Split('[')[1].Split(']')[0]);
            var columnName = queryDictionary[key];

            var property = FindNestedProperty(entityType, columnName!);
            if (property != null)
            {
                columns[columnIndex] = columnName!;
            }
        }

        foreach (var key in queryDictionary.Keys.Where(k => k.StartsWith("order[") && k.EndsWith("][column]")))
        {
            var orderIndex = int.Parse(key.Split('[')[1].Split(']')[0]);
            var columnIndex = int.Parse(queryDictionary[key]!);
            if (columns.TryGetValue(columnIndex, out var columnName))
            {
                var sortDirectionKey = $"order[{orderIndex}][dir]";
                var sortDirection = queryDictionary[sortDirectionKey];

                sortList.Add(new Sort { Field = columnName, Dir = sortDirection! });
            }
        }

        StringValues searchValue;
        queryDictionary.TryGetValue("search[value]", out searchValue);

        Filter primaryFilter = null!;

        if (!string.IsNullOrEmpty(searchValue))
        {
            foreach (var column in columns.Values)
            {
                var property = FindNestedProperty(entityType, column);
                if (property != null && property.PropertyType == typeof(string))
                {
                    if (primaryFilter == null)
                    {
                        primaryFilter = new Filter
                        {
                            Field = column,
                            Operator = "contains",
                            Value = searchValue,
                            Logic = "or",
                            Filters = new List<Filter>()
                        };
                    }
                    else
                    {
                        var filter = new Filter
                        {
                            Field = column,
                            Operator = "contains",
                            Value = searchValue
                        };
                        ((List<Filter>)primaryFilter.Filters!).Add(filter);
                    }
                }
            }
        }

        var dynamic = new Dynamic
        {
            Sort = sortList,
            Filter = primaryFilter
        };

        return new GetListQuery
        {
            PageRequest = pageRequest,
            Dynamic = dynamic
        };
    }

    private static PropertyInfo FindNestedProperty(Type type, string propertyPath)
    {
        var propertyNames = propertyPath.Split('.');
        PropertyInfo property = null;
        Type currentType = type;

        foreach (var propertyName in propertyNames)
        {
            var normalizedPropertyName = ReplaceTurkishCharacters(propertyName);

            property = currentType.GetProperties()
                .FirstOrDefault(p => p.Name.Equals(normalizedPropertyName, StringComparison.OrdinalIgnoreCase))!;

            if (property == null)
            {
                return null;
            }

            currentType = property.PropertyType;
        }

        return property;
    }

    public static string ReplaceTurkishCharacters(string input)
    {
        Dictionary<char, char> turkishToEnglish = new Dictionary<char, char>
        {
            {'ç', 'c'},
            {'Ç', 'C'},
            {'ğ', 'g'},
            {'Ğ', 'G'},
            {'ı', 'i'},
            {'İ', 'I'},
            {'ö', 'o'},
            {'Ö', 'O'},
            {'ş', 's'},
            {'Ş', 'S'},
            {'ü', 'u'},
            {'Ü', 'U'}
        };

        foreach (var pair in turkishToEnglish)
        {
            input = input.Replace(pair.Key, pair.Value);
        }

        return input;
    }
}
