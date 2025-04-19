using Entities.Models.BlogNest.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories.EF_CORE.Extensions
{
    public static class PostRepositoryExtensions
    {
        public static IQueryable<Post> Search(this IQueryable<Post> posts, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return posts;

            var lowerCase = searchText.ToLower().Trim();
            return posts.Where(post => post.Title.ToLower().Contains(searchText));
        }
        public static IQueryable<Post> SortBy(this IQueryable<Post> books, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return books.OrderBy(book => book.Id);

            var orderQuery = OrderByQueryBuilder
                .CreateOrderQuery<Post>(orderByQueryString);
            if (orderQuery is null)
                return books.OrderBy(b => b.Id);
            return books.OrderBy(orderQuery);
        }
    }
}
