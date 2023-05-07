using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Models.Identity;
using Screamer.Application.Contracts.Identity;

namespace Screamer.Identity.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}