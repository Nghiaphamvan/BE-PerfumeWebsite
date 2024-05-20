using BackEndv2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEndv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepositories _customerRepositories;
        public CustomerController(ICustomerRepositories repo)
        {
            _customerRepositories = repo;
        }
    }
}
