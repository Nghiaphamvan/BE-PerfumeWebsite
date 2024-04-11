using AutoMapper;
using BackEndv2.Data;
using BackEndv2.Models;

namespace BackEndv2.Helper
{
    public class Mapper: Profile
    {
       public Mapper()
        {
            CreateMap<PerfumeDetail, PerfumeDetailModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }
    }
}
