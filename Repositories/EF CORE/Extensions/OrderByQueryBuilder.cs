﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_CORE.Extensions
{
    public static class OrderByQueryBuilder
    {
        public static String CreateOrderQuery<T> (String orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(",");
            var propertyInfos = typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
               var  propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos
                     .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName,
                     StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty is null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");


            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;




        }
    }
}
