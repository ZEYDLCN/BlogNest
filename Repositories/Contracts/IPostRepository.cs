using Entities.Models.BlogNest.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        void Create(Post entity);
        void Delete(Post entity);
        Task<PagedList<Post>> GetAllAsync(PostParameters postParameters , bool trackChanges);
        Task<List<Post>> GetAllAsync(bool trackChanges);
        IQueryable<Post> GetByCondition(Expression<Func<Post, bool>> expression, bool trackChanges);
        Task<Post> GetOneAsync(int id, bool trackChanges);
        void Update(Post entity);
    }
}
