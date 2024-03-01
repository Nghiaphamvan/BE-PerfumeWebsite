using BackEndv2.Models;

namespace BackEndv2.Repositories
{
    public interface IPerfumeRepositories
    {
        public Task<List<PerfumeDetailModel>> GetAllPerfumeModelsAsync();
        public Task<PerfumeDetailModel> GetPerfumeModelAsync(int id);
        public Task<int> AddPerfumeModelAsync(PerfumeDetailModel model);
        public Task DeletePerfumeModelAsync(int id, PerfumeDetailModel model);
        public Task UpdatePerfumeModelAsync(int id, PerfumeDetailModel model);
    }
}
