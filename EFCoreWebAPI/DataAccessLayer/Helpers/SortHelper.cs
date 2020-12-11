using DataAccessLayer.Parameters;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace DataAccessLayer.Helpers
{
	public class SortHelper<T> : ISortHelper<T>
	{
		public IQueryable<T> ApplySort(IQueryable<T> entities, QueryStringParameters orderByQueryString)
		{
			if (!entities.Any() || string.IsNullOrWhiteSpace(orderByQueryString.OrderBy))
				return entities;

			string[] orderParams = orderByQueryString.OrderBy.Trim().Split(',');
			PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			StringBuilder orderQueryBuilder = new StringBuilder();

			foreach (string param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;

				string propertyFromQueryName = param.Split(" ")[0];
				PropertyInfo objectProperty = propertyInfos.FirstOrDefault
					(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty == null)
					continue;

				string sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

				orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
			}

			string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

			return entities.OrderBy(orderQuery);
		}
	}
}