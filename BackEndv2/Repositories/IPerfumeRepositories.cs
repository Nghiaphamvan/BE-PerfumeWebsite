﻿using BackEndv2.Models;

namespace BackEndv2.Repositories
{
    public interface IPerfumeRepositories
    {
        public Task<List<PerfumeDetailModel>> GetAllPerfumeModelsAsync();
        public Task<PerfumeDetailModel> GetPerfumeModelAsync(int id);
        public Task<int> AddPerfumeModelAsync(PerfumeDetailModel model);
        public Task DeletePerfumeModelAsync(int id, PerfumeDetailModel model);
        public Task UpdatePerfumeModelAsync(int id, PerfumeDetailModel model);
        public Task<List<PerfumeDetailModel>> GetSomePerfumesModelAsync(int id);
        public Task<List<string>> getCategoriesAsync();
        public Task<List<PerfumeDetailModel>> getProductByNameAsync(string category);
        public Task<List<string>> getBrandsAsync();
        public Task<int> getPercentSaleAsync(int id);
    }
}
