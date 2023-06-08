using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Models.Identity
{
    public class ExternalAuthRequest
    {
          public string Provider { get; set; }
        public string AccessToken { get; set; }
    }
}