using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.ViewModel;
using App.Models.Model;

namespace App.DAL.Repository
{
    public class ProductRepository
    {
        private App_DBEntities dbContext;

        public ProductRepository(App_DBEntities _context)
        {
            this.dbContext = _context;
        }

        public void Add(ProductVM _product)
        {
            var model = ParseModel(_product);
            dbContext.products.Add(model);
            dbContext.SaveChanges();
        }

        public void Update(ProductVM _product)
        {
            var model = ParseModel(_product);
            dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public IQueryable<ProductVM> GetProducts() {
            var results = dbContext.products.Select(p => new ProductVM() { 
                    Id = p.id,
                    Name = p.name,
                    Description = p.description,
                    Price = p.price,
                    CategoryId = p.category_id,
                    Category = p.category.category_name,
                    Location = p.location.location_name,
                    Currency = p.currency,
                    ImgUrl = p.img_url,
                    UnitMeasure = p.unit_measure,
                    Quantity = p.quantity,
                    IsActive = p.is_active,
                    LocationId = p.location_id,
                    CreatedDate = p.created_date
            });

            return results;
        }

        public ProductVM GetProduct(int id) {
            var result = dbContext.products.Where(p => p.id == id).Select(p => new ProductVM() {
                Id = p.id,
                Name = p.name,
                Description = p.description,
                Price = p.price,
                CategoryId = p.category_id,
                Currency = p.currency,
                ImgUrl = p.img_url,
                UnitMeasure = p.unit_measure,
                Quantity = p.quantity,
                IsActive = p.is_active,
                LocationId = p.location_id,
                CreatedDate = p.created_date
            }).SingleOrDefault();

            return result;
        }

        public void Delete(int id)
        {
            var prod = dbContext.products.SingleOrDefault(p => p.id == id);
            dbContext.products.Remove(prod);
            dbContext.SaveChangesAsync();
        }

        private product ParseModel(ProductVM vm)
        {
            product model;
            if (vm.Id == null || vm.Id == 0)
            {
                model = new product();
            }
            else {
                model = dbContext.products.SingleOrDefault(p=> p.id == vm.Id);
            }
                      
            model.name = vm.Name;
            model.description = vm.Description;
            model.img_url = vm.ImgUrl;
            model.is_active = vm.IsActive;
            model.location_id = vm.LocationId;
            model.category_id = vm.CategoryId;
            model.created_date = vm.CreatedDate;
            model.currency = vm.Currency;
            model.price = vm.Price;
            model.quantity = vm.Quantity;
            model.unit_measure = vm.UnitMeasure;

            return model;
        }
    }
}
