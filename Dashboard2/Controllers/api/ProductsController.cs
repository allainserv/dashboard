using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Owin.Cors;

using App.Model.Model;
using App.DAL;
using App.Model.ViewModel;
using System.Web.Http.Cors;
using App.DAL.Repository;

namespace Dashboard2.Controllers.api
{
     [EnableCors(origins: "http://localhost:60956", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        
        private App_DBEntities db;
        private ProductRepository productRepository;
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
            db = new App_DBEntities();
            productRepository = new ProductRepository(db);
            base.Initialize(controllerContext);
        }

        // GET: api/Products
        public IQueryable<ProductVM> Getproducts()
        {
            return productRepository.GetProducts();
        }

        // GET: api/Products/5
        //[ResponseType(typeof(product))]
        //public IHttpActionResult Getproduct(int id)
        //{
        //    product product = productRepository.GetProduct(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
            
        //}

        //// PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putproduct(int id, product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        productRepository.updateproduct(product);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!productExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);

        //}

        //// POST: api/Products
        //[ResponseType(typeof(product))]
        //public IHttpActionResult Postproduct(product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    productRepository.addproduct(product);
        //    return CreatedAtRoute("DefaultApi", new { id = product.id }, product);
        //}

        //// DELETE: api/Products/5
        //[ResponseType(typeof(product))]
        //public IHttpActionResult Deleteproduct(int id)
        //{
        //    var prod = productRepository.GetProduct(id);
        //    if (prod == null)
        //    {
        //        return NotFound();
        //    }
            
        //    return Ok(prod);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productExists(int id)
        {
            var prod = productRepository.GetProduct(id);
            return prod != null;
        }
    }
}

