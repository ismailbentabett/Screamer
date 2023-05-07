using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Contracts.Exceptions
{
    public class BadRequest : Exception
    {
        public BadRequest(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
            
        }
    }
}