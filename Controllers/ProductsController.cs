using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;

namespace DruidsHikeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private StoreDB.Repository.IDataRepository<Product> productService;
        public ProductsController(StoreDB.IStoreManager service)
        {
            this.productService = service.ProductManager;

        }
        // GET: api/Products
        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.productService.GetAll().ToList();
        }

        // GET: api/Products/5
        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int productId)
        {
            return this.productService.Get(productId);
        }

        // POST: api/Products
        
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            if (value == null)
            {
                return BadRequest("product is null");
            }

            try
            {
                
                productService.Add(value);
                return CreatedAtRoute("Get",
                  new { Id = value.ProductId },
                  value);
            }
            catch (Exception ex)
            {
                return BadRequest("product not saved => " + ex.Message);
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
