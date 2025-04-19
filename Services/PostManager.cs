using Entities.Models.BlogNest.Models;
using Services.Contracts;
using Repositories.Contracts;
using Entities.Exceptions;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services
{
    internal class PostManager : IPostService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggingService _logger;
        private readonly IMapper mapper;
        private readonly IDataShaper<PostDto> dataShaper;

        public PostManager(IRepositoryManager repositoryManager, ILoggingService logger, IMapper mapper, IDataShaper<PostDto> dataShaper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            this.mapper = mapper;
            this.dataShaper = dataShaper;
        }

        public async Task<(IEnumerable<ExpandoObject> postDtos, MetaData metaData)> GetAllAsync(PostParameters postParameters, bool trackChanges = false)
        {
            var postsWithMetaData = await _repositoryManager.Post.GetAllAsync(postParameters , trackChanges);

            var pagedPosts = mapper.Map<IEnumerable<PostDto>>(postsWithMetaData);
            var shapedData = dataShaper.ShapeData(pagedPosts, postParameters.Fields);
            return (postDtos:shapedData, postsWithMetaData.MetaData);
        }

        public async Task<PostDto> GetOneAsync(int id, bool trackChanges = false)
        {
            var post = await _repositoryManager.Post.GetOneAsync(id, false) ?? throw new PostNotFoundException(id);
            return mapper.Map<PostDto>(post); 

        }

        public async Task<PostDto> CreateOneBookAsync(PostDtoForCreate postCreate)
        {
            var post = mapper.Map<Post>(postCreate);
            _repositoryManager.Post.Create(post);
            await _repositoryManager.SaveAsync();
            return mapper.Map<PostDto>(post);
        }

        public async Task UpdateOnePostAsync(int id, PostDtoForUpdate postDto, bool trackChanges = false)
        {
            var existingPost =await  _repositoryManager.Post.GetOneAsync(id,false);
            if (existingPost is null)
            {
                throw new PostNotFoundException(id);    
            }
           
            if (existingPost != null)
            {
                //existingPost.Title = post.Title;
                //existingPost.Content = post.Content;
                existingPost=mapper.Map<Post>(postDto);    
               await _repositoryManager.SaveAsync();
            }
        }

        public async Task DeleteOnePostAsync(int id, bool trackChanges = false)
        {
            var post =await _repositoryManager.Post.GetOneAsync(id,false) ?? 
                throw new PostNotFoundException(id);    
          
                _repositoryManager.Post.Delete(post);
                await _repositoryManager.SaveAsync();
            
        }

        public async Task<List<Post>> GetAllAsync(bool trackChanges)
        {
            var posts = await _repositoryManager.Post.GetAllAsync(false);

            return posts; 
        }
    }
}
