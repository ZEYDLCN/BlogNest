using Entities.DataTransferObjects;
using Entities.Models.BlogNest.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiVersion("1.0")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName =  "5mins")]
    public class PostController : ControllerBase
    {
        private readonly IServiceManager _serviceManager; // ✅ Artık ServiceManager kullanıyoruz

        public PostController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/post/posts
        [Authorize(Roles ="Admin")]
        [HttpHead]
        [HttpGet("posts")]
        [ResponseCache(Duration =60)]
        public async Task< IActionResult > GetAllPostsAsync([FromQuery]PostParameters postParameters)
        {
            var pagedList = await  _serviceManager.postService.GetAllAsync(postParameters,trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedList.metaData));
            return Ok(pagedList.postDtos);
        }

        // GET: api/post/posts/{id}
        [HttpGet("posts/{id}")]
        public async Task<IActionResult> GetPostByIdAsync(int id)
        {
            var post =await _serviceManager.postService.GetOneAsync(id, trackChanges: false);
          
            return Ok(post);
        }

        // POST: api/post/posts
        [ServiceFilter(typeof(ValidationFilterAttribute))] 
        [HttpPost("posts")]
        public async Task<IActionResult> CreatePost([FromBody] PostDtoForCreate postDtoForCreate)
        {

            var createdPost =await  _serviceManager.postService.CreateOneBookAsync(postDtoForCreate);

            return CreatedAtAction(nameof(GetPostByIdAsync), new { id = createdPost.Id }, createdPost);
        }

        // PUT: api/post/posts/{id}
        [ServiceFilter(typeof(ValidationFilterAttribute))] 
        [HttpPut("posts/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDtoForUpdate postDto)
        {
         
            await _serviceManager.postService.UpdateOnePostAsync(id, postDto, false);
            return NoContent();
        }

        // DELETE: api/post/posts/{id}
        [HttpDelete("posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _serviceManager.postService.DeleteOnePostAsync(id, trackChanges: true);
            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetPostsOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
