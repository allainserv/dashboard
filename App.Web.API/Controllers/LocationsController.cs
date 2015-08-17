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
    public class LocationsController : ApiController
    {
        private App_DBEntities dbContext;
        private LocationRepository repository;

        public LocationsController()
        {
            dbContext = new App_DBEntities();
            repository = new LocationRepository(dbContext);
        }

        public IQueryable<LocationVM> GetLocations()
        {
            return repository.GetLocations();
        }

        [ResponseType(typeof(LocationVM))]
        public IHttpActionResult GetLocation(int Id)
        {
            var model = repository.GetLocation(Id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST: api/category
        [ResponseType(typeof(LocationVM))]
        public IHttpActionResult PostProduct(LocationVM location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = repository.Add(location);
            task.Wait();

            return CreatedAtRoute("DefaultApi", new { id = location.Id }, location);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproduct(int id, LocationVM location)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (id != location.Id) { return BadRequest(); }

            try
            {
                var task = repository.Update(location);
                task.Wait();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (repository.GetLocation(id) == null)
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/category/5
        [ResponseType(typeof(LocationVM))]
        public IHttpActionResult Deleteproduct(int id)
        {
            var model = repository.GetLocation(id);
            if (model == null)
            {
                return NotFound();
            }

            var task = repository.Delete(id);
            task.Wait();

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
