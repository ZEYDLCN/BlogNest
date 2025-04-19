using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
       private readonly  Lazy<IPostService> _postService;
        public ServiceManager(IRepositoryManager manager, ILoggingService loggingService, IMapper mapper,IDataShaper<PostDto> shaper)
        {
           _postService=new Lazy<IPostService>(()=>new PostManager(manager ,loggingService,mapper, shaper));

        }

        public IPostService postService => _postService.Value;
    }
}
