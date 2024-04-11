using AutoMapper;
using BackEndv2.Data;
using BackEndv2.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndv2.Repositories
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private readonly IMapper? _mapper;
        private readonly PerfumeDetailContext _perfumeContext;


        public CustomerRepositories(IMapper mapper, PerfumeDetailContext context)
        {
            _mapper = mapper;
            _perfumeContext = context;
        }

        public async Task<List<Cart>> getAllCartByCustomer(int CustomerID)
        {
            var AllCart = await _perfumeContext.Cart.Where(a => a.CustomerID == CustomerID).ToListAsync();
            return AllCart;
        }

        public async Task<CustomerModel> getCustomerAsync(int id)
        {
            var getCustomer = await _perfumeContext.Customer.FindAsync(id);

            return _mapper!.Map<CustomerModel>(getCustomer);
        }
    }
}
