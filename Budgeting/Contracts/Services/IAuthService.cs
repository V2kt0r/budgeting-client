using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgeting.Contracts.Services
{
    public interface IAuthService
    {
        Task<bool> IsUserAuthenticatedAsync();
        Task<bool> LoginWithCredentialsAsync(string username = null, string password = null);
        Task LogoutAsync();
    }
}
