using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/posts")]
    public class PostsV2Controller : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public PostsV2Controller(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            var posts = await serviceManager.postService.GetAllAsync(false);
            var postsV2 = posts.Select(p => new
            {
                Id = p.Id,
                Title = p.Title

            });
            return Ok(postsV2);

        }
    }
}
