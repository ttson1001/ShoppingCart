using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Entities;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public ProductsController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _context.Product.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        [HttpGet("FindProductsByName/{search}")]
        public async Task<ActionResult<IEnumerable<Product>>> FindProductsByName(string search)
        {
            var list = await _context.Product.ToListAsync();
            var filter = list.FindAll(p => p.Name.Contains(search));
            return filter;
        }

        [HttpGet("FindProductsByMaker/{search}")]
        public async Task<ActionResult<IEnumerable<Product>>> FindProductsByMaker(string search)
        {
            var list = await _context.Product.ToListAsync();
            var filter = list.FindAll(p => p.Maker.Contains(search));
            return filter;
        }

        [HttpGet("FindProductsByPrice/{min}/{max}")]
        public async Task<ActionResult<IEnumerable<Product>>> FindProductsByPrice(decimal? min, decimal? max)
        {
            var list = await _context.Product.ToListAsync();
            var filter = list.FindAll(p => p.Price >= min && p.Price <= max);
            return filter;
        }

        // DELETE: api/Products/5
        //[httpdelete("{id}")]
        //public async task<iactionresult> deleteproduct(int id)
        //{
        //    var product = await _context.product.findasync(id);
        //    if (product == null)
        //    {
        //        return notfound();
        //    }

        //    _context.product.remove(product);
        //    await _context.savechangesasync();

        //    return nocontent();
        //}

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
