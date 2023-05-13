using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Contracts.Exceptions
{
    public class NotFoundException : Exception
    {
        private string userId;

        public NotFoundException(string message, string userId) : base(message)
        {
            this.userId = userId;
        }

        public NotFoundException(string name, object key, object var) : base($"Entity \"{name}\" ({key}) was not found.")
        {
            
        }
    }
}