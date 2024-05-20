using BackEndv2.Data;
using BackEndv2.Models;

namespace BackEndv2.Repositories
{
    public interface ICustomerRepositories
    {
        public Task<CustomerModel> NousegetCustomerAsync(int id);
        public Task<List<Cart>> NousegetAllCartByCustomer(int CustomerID);
    }
}
