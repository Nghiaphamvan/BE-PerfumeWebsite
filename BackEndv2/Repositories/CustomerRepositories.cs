using AutoMapper;
using BackEndv2.Data;
using BackEndv2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackEndv2.Repositories
{
    public class CustomerRepositories : ICustomerRepositories
    {
        private readonly IMapper? _mapper;
        private readonly PerfumeDetailContext _perfumeContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public CustomerRepositories(IMapper mapper, PerfumeDetailContext context, UserManager<User> userManager,
            SignInManager<User> signInManager, IConfiguration confi, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _perfumeContext = context;
            this._userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = confi;
            this.roleManager = roleManager;
        }

        public async Task<List<Cart>> NousegetAllCartByCustomer(int CustomerID)
        {
            var AllCart = await _perfumeContext.Cart.Where(a => a.CustomerID == CustomerID).ToListAsync();
            return AllCart;
        }

        public async Task<CustomerModel> NousegetCustomerAsync(int id)
        {
            var getCustomer = await _perfumeContext.Customer.FindAsync(id);

            return _mapper!.Map<CustomerModel>(getCustomer);
        }
    }
}
