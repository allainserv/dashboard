using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Model;
using App.Models.ViewModel;
using App.DAL.Repository;

namespace App.DAL.Repository
{
    public class CategoryRepository
    {
        private App_DBEntities dbContext;

        public CategoryRepository(App_DBEntities _context)
        {
            dbContext = _context;
        }

        public void Add(CategoryVM _category)
        {
            dbContext.categories.Add(ParseModel(_category));
            dbContext.SaveChanges();
        }

        public void Update(CategoryVM _category)
        {
            dbContext.Entry(ParseModel(_category)).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = dbContext.categories.SingleOrDefault(p => p.id == id);
            dbContext.categories.Remove(model);
            dbContext.SaveChanges();
        }

        public IQueryable<CategoryVM> GetCategories()
        {
            var results = dbContext.categories.Select(c => new CategoryVM()
            {
                Id = c.id,
                Name = c.category_name
            });

            return results;
        }

        public CategoryVM GetCategory(int id)
        {
            var result = dbContext.categories.Where(c => c.id == id).Select(c => new CategoryVM()
            {
                Id = c.id,
                Name = c.category_name
               
            }).SingleOrDefault();

            return result;
        }

        private category ParseModel(CategoryVM vm)
        {
            var model = new category();
            model.id = vm.Id;
            model.category_name = vm.Name;
         
            return model;
        }
    }
}
