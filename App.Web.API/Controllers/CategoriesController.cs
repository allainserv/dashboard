using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.Models.Model;
using App.Models.ViewModel;
using App.DAL.Repository;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace App.Web.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriesController : ApiController
    {
        private App_DBEntities dbContext;
        private CategoryRepository categoryRepo;

        public CategoriesController()
        {
            dbContext = new App_DBEntities();
            categoryRepo = new CategoryRepository(dbContext);
        }

        public IQueryable<CategoryVM> GetCategories()
        {
            return categoryRepo.GetCategories();
        }

        [ResponseType(typeof(CategoryVM))]
        public IHttpActionResult GetCategory(int Id)
        {
            var model = categoryRepo.GetCategory(Id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        // POST: api/category
        [ResponseType(typeof(CategoryVM))]
        public IHttpActionResult PostProduct(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           categoryRepo.Add(category);
           
            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategory(int id, CategoryVM category)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (id != category.Id) { return BadRequest();  }

            try
            {
                categoryRepo.Update(category);
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (categoryRepo.GetCategory(id) == null){
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/category/5
        [ResponseType(typeof(CategoryVM))]
        public IHttpActionResult Deleteproduct(int id)
        {
            var model = categoryRepo.GetCategory(id);
            if (model == null)
            {
                return NotFound();
            }
           categoryRepo.Delete(id);           
            return Ok(model);
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
