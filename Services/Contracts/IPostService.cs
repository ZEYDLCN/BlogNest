using Entities.DataTransferObjects;
using Entities.Models.BlogNest.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts

{
    public interface IPostService
    {
        Task<(IEnumerable<ExpandoObject> postDtos, MetaData metaData)> GetAllAsync(PostParameters postParameters, bool trackChanges = false);
        Task<PostDto> GetOneAsync(int id, bool trackChanges = false);
        Task<PostDto> CreateOneBookAsync(PostDtoForCreate postDtoForCreate);
        Task UpdateOnePostAsync(int id, PostDtoForUpdate postDtoForUpdate, bool trackChanges = false);
        Task DeleteOnePostAsync(int id, bool trackChanges = false);
        Task<List<Post>> GetAllAsync(bool trackChanges);
    }
}
