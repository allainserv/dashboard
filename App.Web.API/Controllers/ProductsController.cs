using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.Models.Model;
using App.Models.ViewModel;
using App.DAL.Repository;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Cors;

namespace App.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private App_DBEntities dbContext;
        private ProductRepository prodRepo;

        public ProductsController()
        {
            dbContext = new App_DBEntities();
            prodRepo = new ProductRepository(dbContext);
        }

        public IQueryable<ProductVM> GetProducts()
        {
            return prodRepo.GetProducts();
        }

        [ResponseType(typeof(ProductVM))]
        public IHttpActionResult GetProduct(int Id)
        {
            var product = prodRepo.GetProduct(Id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductVM))]
        public IHttpActionResult PostProduct(ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            prodRepo.Add(product);
         //   task.Wait();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            try{
                prodRepo.Update(product);
                //task.Wait();
            }
            catch (DbUpdateConcurrencyException) {
                if (prodRepo.GetProduct(id) == null){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductVM))]
        public IHttpActionResult Deleteproduct(int id)
        {
            var prod = prodRepo.GetProduct(id);
            if (prod == null)
            {
                return NotFound();
            }
            prodRepo.Delete(id);
           
            return Ok(prod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
