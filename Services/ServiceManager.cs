using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
       private readonly Lazy<IAuthenticationService> _authenticationService; 
        public ServiceManager(IRepositoryManager manager
            , ILoggingService loggingService,
            IMapper mapper,
            IDataShaper<PostDto> shaper,
             UserManager<User> userManager,
            IConfiguration configuration )
        {
           _postService=new Lazy<IPostService>(()=>new PostManager(manager ,loggingService,mapper, shaper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(loggingService, mapper, userManager, configuration));

        }

        public IPostService postService => _postService.Value;

        public IAuthenticationService authenticationService => _authenticationService.Value;
    }
}
