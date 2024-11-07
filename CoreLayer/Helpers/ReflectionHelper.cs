namespace CoreLayer.Helpers;

public static class ReflectionHelper
{
    public static bool TryGetPropertyValue<T>(T obj, string propertyName, out object propertyValue)
    {
        propertyValue = null;
        if (obj == null)
        {
            return false;
        }

        var propertyInfo = typeof(T).GetProperty(propertyName);
        if (propertyInfo == null)
        {
            return false;
        }

        propertyValue = propertyInfo.GetValue(obj)!;

        if (propertyValue == null)
        {
            return false;
        }

        return true;
    }

    public static bool TrySetPropertyValue<T>(T obj, string propertyName, object value)
    {
        if (obj == null)
        {
            return false;
        }

        var propertyInfo = typeof(T).GetProperty(propertyName);
        if (propertyInfo == null || !propertyInfo.CanWrite)
        {
            return false;
        }

        propertyInfo.SetValue(obj, value);
        return true;
    }
}
