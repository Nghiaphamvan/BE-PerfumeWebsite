﻿using AutoMapper;
using BackEndv2.Data;
using BackEndv2.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PerfumeDetailModel> GetPerfumeModelAsync(int id)
        {
            var Perfume = await _perfumeContext.Perfumes.FindAsync(id);
            return _mapper.Map<PerfumeDetailModel>(Perfume);
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
