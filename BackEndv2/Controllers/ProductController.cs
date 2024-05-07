using BackEndv2.Data;
using BackEndv2.Helper;
using BackEndv2.Models;
using BackEndv2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IPerfumeRepositories _perfumeRepositories;
       
        public ProductController(IPerfumeRepositories repo)
        {
            _perfumeRepositories = repo;
        }

        [HttpGet("GetCartsByCustomerID")]   
        public async Task<IActionResult> getCartsByCustomerID(int customerID)
        {
            try
            {
                return Ok(await _perfumeRepositories.GetCartsByCustomerIDAsync(customerID));
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteCartAsync")]
        public async Task<IActionResult> DeleteCartAsync(int id)
        {
            try
            {
                await _perfumeRepositories.DeleteCartAsync(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> addProductToCart(CartModel model)
        {
            try
            {
                var success = await _perfumeRepositories.AddProductToCart(model);

                return success ? Ok() : BadRequest(); // Trả về Ok nếu thêm thành công, BadRequest nếu có lỗi
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return StatusCode(500); // Trả về status code 500 nếu có lỗi không xác định
            }
        }


        [HttpGet("getCart")]
        public async Task<IActionResult> GetCartAsync(int id)
        {
            try
            {
                var cart = await _perfumeRepositories.GetCartAsync(id);
                return cart == null ? NotFound() : Ok(cart);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost("addNewPerfume")]
        public async Task<IActionResult> AddNewPerfume(PerfumeDetailModel model)
        {
            try
            {
                var newPerfume = await _perfumeRepositories.AddPerfumeModelAsync(model);
                var perfumeAdded = await _perfumeRepositories.GetPerfumeModelAsync(newPerfume);

                return perfumeAdded == null ? NotFound() : Ok(perfumeAdded);
            }
            catch { return BadRequest(); }
        }

        [HttpGet("GetProductSale")]
        public async Task<IActionResult> getProductSale()
        {
            try
            {
                return Ok(await _perfumeRepositories.getProductSaleAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPercentSaleByID")]
        public async Task<IActionResult> getPercentSaleById(int id)
        {
            try
            {
                return Ok(await _perfumeRepositories.getPercentSaleAsync(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetProductByCategory")]
        public async Task<IActionResult> GetProductByCategori(string name)
        {
            try
            {
                return Ok(await _perfumeRepositories.getProductByNameAsync(name));
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsynce()
        {
            try
            {
                return Ok(await _perfumeRepositories.getCategoriesAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllBrands")]
        public async Task<IActionResult> GetAllBrandsAsynce()
        {
            try
            {
                return Ok(await _perfumeRepositories.getBrandsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetSomeProduct")]
        public async Task<IActionResult> GetSomePerfumeModelAsync(int n)
        {
            try
            {
                return Ok(await _perfumeRepositories.GetSomePerfumesModelAsync(n));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("getAllPerfumes")]
        public async Task<IActionResult> getAllPerfumesAsync()
        {
            try
            {
                return Ok(await _perfumeRepositories.GetAllPerfumeModelsAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        
        [HttpGet("getPerfumeby{id}")]
        public async Task<IActionResult> GetPerfumeByID(int id)
        {
            try
            {
                var getperfume = await _perfumeRepositories.GetPerfumeModelAsync(id);
                return getperfume == null ? NotFound() : Ok(getperfume);
            }
            catch { return BadRequest(); }
        }

        [HttpPut("UpdateCart")]
        public async Task<IActionResult> UpdateCart(int id, string response)
        {
            try
            {
                return Ok(await _perfumeRepositories.UpdateCartAsync(id, response));
            } catch
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateCartByAmount")]
        public async Task<IActionResult> UpdateCartAmount(int id, int amount)
        {
            try
            {
                return Ok(await _perfumeRepositories.UpdateCartAsyncbyAmount(id, amount));
            } catch
            {
                return NotFound();
            }
        }

        [HttpPut("updatePerfume")]
        public async Task<IActionResult> UpdatePerfume(int id, PerfumeDetailModel model)
        {
            try
            {
                await _perfumeRepositories.UpdatePerfumeModelAsync(id, model);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("deletePerfume")]
        public async Task<IActionResult> DeletePerfume(int id, PerfumeDetailModel model)
        {
            try
            {
                await _perfumeRepositories.DeletePerfumeModelAsync(id, model);
                return Ok();
            }

            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteCart")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            try
            {
                await _perfumeRepositories.DeleteCartAsync(id);
                return Ok();
            } catch
            {
                return NotFound();
            }
        }
    }
}
