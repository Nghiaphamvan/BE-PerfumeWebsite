using BackEndv2.Models;
using Microsoft.AspNetCore.Identity;

namespace BackEndv2.Repositories
{
    public interface IAccountRepositories
    {

        public Task<IdentityResult> SignUpModelAsync(SignUpModel model);
        public Task<string> SignInModelAsync(SignInModel model);
        public Task<bool> CheckEmailASync(string email);

    }
}
    