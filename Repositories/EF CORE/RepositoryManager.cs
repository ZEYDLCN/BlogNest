
using Repositories.Contracts;
using Repositories.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IPostRepository> _postRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() =>
                new PostRepository(_context));
        }

        public IPostRepository Post => _postRepository.Value;


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
