using BackEndv2.Models;
using BackEndv2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BackEndv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepositories accountRepo;

        public AccountController(IAccountRepositories accountRepo)
        {
            this.accountRepo = accountRepo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await accountRepo.SignUpModelAsync(model);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }

        [HttpGet("checkEmail")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            try
            {
                var result = await accountRepo.CheckEmailASync(email);
                return Ok(result);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await accountRepo.SignInModelAsync(model);

            var jsonresult = new JsonResult(result);
            if(string.IsNullOrEmpty(result)) {
                jsonresult.StatusCode = 400;
                return Ok(jsonresult);
            }

            jsonresult.StatusCode = 200;
            return Ok(jsonresult);
        }

    }
}
