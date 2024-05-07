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

        [HttpGet("GetCustomerAsync")]
        public async Task<IActionResult> getCustomer(int id)
        {
            try
            {
                return Ok(await _customerRepositories.getCustomerAsync(id));
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getAllCartByCustomer")]
        public async Task<IActionResult> getAllCartByCustomer(int CustomerId)
        {
            try
            {
                return Ok(await _customerRepositories.getAllCartByCustomer(CustomerId));
            } catch
            {
                return NotFound();
            }
        }
    }
}
