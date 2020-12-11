using DataAccessLayer.Parameters;
using System.Linq;

namespace DataAccessLayer.Helpers
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, QueryStringParameters orderByQueryString);
    }
}