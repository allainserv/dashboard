//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using App.Model.Model;
//using App.DAL;
//using System.Web.Http.Cors;
//using App.DAL.ViewModel;

//namespace Dashboard2.Controllers.api
//{
//    [EnableCors(origins: "http://localhost:60956", headers: "*", methods: "*")]
//    public class CategoriesController : ApiController
//    {
//        private App_DBEntities db;
//        private CategoryRepository categoryRepository;
       

//        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
//        {
//            db = new App_DBEntities();
//            categoryRepository = new CategoryRepository(db);
//            base.Initialize(controllerContext);
//        }

//        // GET: api/Categories
//        public IQueryable<CategoryVM> Getcategories()
//        {
//           // var categories = categoryRepository.GetCategories();
//            var categories = new List<CategoryVM>()
//            {
//                new CategoryVM(){Id = 1, Name = "For Bulk Sale"},
//                new CategoryVM(){Id = 2 , Name ="For Pcs"}
//            };

//            return categories.AsQueryable();
//        }

//        // GET: api/Categories/5
//        [ResponseType(typeof(category))]
//        public IHttpActionResult Getcategory(int id)
//        {
//            category category = db.categories.Find(id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            return Ok(category);
//        }

//        // PUT: api/Categories/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult Putcategory(int id, category category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != category.id)
//            {
//                return BadRequest();
//            }

//            db.Entry(category).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!categoryExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Categories
//        [ResponseType(typeof(category))]
//        public IHttpActionResult Postcategory(category category)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.categories.Add(category);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = category.id }, category);
//        }

//        // DELETE: api/Categories/5
//        [ResponseType(typeof(category))]
//        public IHttpActionResult Deletecategory(int id)
//        {
//            category category = db.categories.Find(id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            db.categories.Remove(category);
//            db.SaveChanges();

//            return Ok(category);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool categoryExists(int id)
//        {
//            return db.categories.Count(e => e.id == id) > 0;
//        }
//    }
//}