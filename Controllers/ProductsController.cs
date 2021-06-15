using API.Core.DbModels;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context1;

        public ProductsController(StoreContext context)
        {
            _context1 = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> data = await _context1.Products.ToListAsync();

            return data;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = await _context1.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return product;
        }
    }
}
