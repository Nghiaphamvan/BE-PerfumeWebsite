using BackEndv2.Data;
using BackEndv2.Models;

namespace BackEndv2.Repositories
{
    public interface ICustomerRepositories
    {
        public Task<CustomerModel> getCustomerAsync(int id);
        public Task<List<Cart>> getAllCartByCustomer(int CustomerID);

    }
}
