using AutoMapper;
using BackEndv2.Data;
using BackEndv2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEndv2.Repositories
{
    public class PerfumeRepositories : IPerfumeRepositories
    {

        private readonly IMapper _mapper;
        private readonly PerfumeDetailContext _perfumeContext;
        public PerfumeRepositories(PerfumeDetailContext context, IMapper mapper)
        {
            _mapper = mapper;
            _perfumeContext = context;
        }

        public async Task<int> AddPerfumeModelAsync(PerfumeDetailModel model)
        {
            var newPerfume = _mapper.Map<PerfumeDetail>(model);
            _perfumeContext.Perfumes.Add(newPerfume);
            await _perfumeContext.SaveChangesAsync();
            return newPerfume.id;
        }

        public async Task DeletePerfumeModelAsync(int id, PerfumeDetailModel model)
        {
            var deletePerfume = _perfumeContext.Perfumes!.SingleOrDefault(b => b.id == id);

            if (deletePerfume != null)
            {
                _perfumeContext.Perfumes.Remove(deletePerfume);
                await _perfumeContext.SaveChangesAsync();
            }
        }

        public async Task<List<PerfumeDetailModel>> GetAllPerfumeModelsAsync()
        {
            var AllPerfumes = await _perfumeContext.Perfumes.ToListAsync();
            return _mapper.Map<List<PerfumeDetailModel>>(AllPerfumes);
        }

        public async Task<List<string>> getBrandsAsync()
        {
            var uniqueBrands = await _perfumeContext.Perfumes.Select(c => c.brand).Distinct().ToListAsync();
            return uniqueBrands!;
        }

        public async Task<List<string>> getCategoriesAsync()
        {
            // Select: Lay theo name
            // Distinct: Lay unique
            // ToListAsync: List Asynce
            var uniqueCategories = await _perfumeContext.Categories.Select(c => c.type).Distinct().ToListAsync();
            return uniqueCategories!;
        }

        public async Task<int> getPercentSaleAsync(int id)
        {
            var getpercent = await _perfumeContext.Sale.FindAsync(id);
            return getpercent.per;
        }

        public async Task<PerfumeDetailModel> GetPerfumeModelAsync(int id)
        {
            var Perfume = await _perfumeContext.Perfumes.FindAsync(id);
            return _mapper.Map<PerfumeDetailModel>(Perfume);
        }

        public async Task<List<PerfumeDetailModel>> getProductByNameAsync(string category)
        {
            /* var productNames = await _perfumeContext.Categories.Where(c => c.name == category).ToListAsync();
             var allPerfumes = await _perfumeContext.Perfumes.ToListAsync();
             var perfumesName = allPerfumes.Where(perfume => productNames.Select(pn => pn.name).Contains(perfume.name))
                 .Select(perfume => perfume.name)
                 .ToList();
             return perfumesName!;*/
            var eCategoriesNames = await _perfumeContext.Categories.Where(c => c.type == category)
                .Select(b => b.name)
                .ToListAsync();
            var PerfumesbyCategori = await _perfumeContext.Perfumes.Where(p => eCategoriesNames.Contains(p.name))
                .ToListAsync();

            return _mapper.Map<List<PerfumeDetailModel>>(PerfumesbyCategori);
        }

        public async Task<List<PerfumeDetailModel>> GetSomePerfumesModelAsync(int n)
        {
            var latestNPerfumes = await _perfumeContext.Perfumes
                .OrderByDescending(p => p.id) // Sắp xếp theo Id giảm dần để lấy perfume mới nhất
                .Take(n) // Lấy n perfume đầu tiên
                .ToListAsync();

            // Ánh xạ danh sách perfume sang danh sách PerfumeDetailModel
            return _mapper.Map<List<PerfumeDetailModel>>(latestNPerfumes);
        }

        public async Task UpdatePerfumeModelAsync(int id, PerfumeDetailModel model)
        {
            if (id == model.id)
            {
                var updatePerfume = _mapper.Map<PerfumeDetail>(model);
                _perfumeContext.Perfumes.Update(updatePerfume);

                await _perfumeContext.SaveChangesAsync();
            }
        }
    }
}
