using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly StoreContext _context;//dbcontext from StoreContext.cs
        //naming convention: underscore_ at first represents that it's a readonly, private variable
        public ProductsController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet]//specify metadata of attribute of this funtion
        public async Task<ActionResult<List<Product>>> GetProducts()//returns all products
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]//api/products/id(1,2,3...)
        public async Task<ActionResult<Product>> GetProduct(int id)//only return specified product with the id
        {
            var product = await _context.Products.FindAsync(id);
            return product == null ? NotFound() : product;
        }
    }
}