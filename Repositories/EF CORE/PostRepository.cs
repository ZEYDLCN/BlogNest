using Entities.Models.BlogNest.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EF_CORE.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EF_CORE
{
    internal class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
        public void CreateOnePost(Post post) => Create(post);

        public void DeleteOnePost(Post post) => Delete(post);

        public async Task<PagedList<Post>> GetAllAsync(PostParameters postParameters, bool trackChanges)
        {
            var posts = await GetAll(trackChanges)
                .Search(postParameters.SearchTerm)
                .SortBy(postParameters.OrderBy).
                ToListAsync()
                ;
            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber, postParameters.PageSize); 

           
        }

        public async Task<List<Post>> GetAllAsync(bool trackChanges)
        {
            return await GetAll(trackChanges).OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Post> GetOneAsync(int id, bool trackChanges) =>

            await GetByCondition(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneBook(Post post) => Update(post);
    }
}
