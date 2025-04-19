using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public abstract class NotFoundExceptionBase : Exception
    {
        protected NotFoundExceptionBase(string message) : base(message) { }
    }
}
