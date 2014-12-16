using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using ASP5AppWithEF7.Services;
using ASP5AppWithEF7.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP5AppWithEF7.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class ProductAPIController : Controller
    {

        IProductService service;

        public ProductAPIController(IProductService srv)
        {
            service = srv;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return service.GetProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return service.GetProduct(id);
        }

        // POST api/values
        [HttpPost]
        public Product Post(Product prd)
        {
           return service.CreateProduct(prd);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Product Put(int id, Product prd)
        {
           return service.UpdateProduct(id, prd);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
           return service.DeleteProduct(id);
        }
    }
}
