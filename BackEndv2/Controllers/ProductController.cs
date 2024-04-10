using BackEndv2.Models;
using BackEndv2.Repositories;
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
    }
}
