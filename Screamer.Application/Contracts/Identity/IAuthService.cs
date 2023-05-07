using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Models.Identity;

namespace Screamer.Application.Contracts.Identity
{
    public interface IAuthService
    {
            Task<AuthResponse> Login(AuthRequest request) ;
            Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}