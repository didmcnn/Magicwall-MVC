namespace CoreLayer.Persistence.Paging;

/// <summary>
/// DataTable is an object that is compatible with the JS library to give data from the backend.
/// </summary>
/// <typeparam name="TEntity">Parameter required to be compatible with each entity in a generic way.</typeparam>
public class BaseDataTablePageableModel<TEntity> : BasePageableModel
{
    public int RecordsTotal { get; set; }
    public int RecordsFiltered { get; set; }
    public IList<TEntity> Data { get; set; }
}
