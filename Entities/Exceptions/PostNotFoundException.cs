using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PostNotFoundException : NotFoundExceptionBase
    {
        public PostNotFoundException(int id) : base($"No such post with id: {id}")
        {

        }
    }
}
