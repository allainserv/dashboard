using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Model;
using App.Models.ViewModel;

namespace App.DAL.Repository
{
    public class LocationRepository: IDisposable
    {
        private App_DBEntities dbCtx;

        public LocationRepository(App_DBEntities _context)
        {
            this.dbCtx = _context;
        }

        public async Task Add(LocationVM location)
        {
            dbCtx.locations.Add(ParseModel(location));
            await dbCtx.SaveChangesAsync();
        }

        public async Task Update(LocationVM location) {
            dbCtx.Entry(ParseModel(location)).State = System.Data.Entity.EntityState.Modified;
            await dbCtx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = dbCtx.locations.SingleOrDefault(l=> l.id == id);
            dbCtx.locations.Remove(model);
            await dbCtx.SaveChangesAsync();
        }

        public LocationVM GetLocation(int id) {
           
            var result = dbCtx.locations.Where(l => l.id == id).Select(l => new LocationVM() { Id = l.id, LocationName = l.location_name }).SingleOrDefault();

            return result;
        }

        public IQueryable<LocationVM> GetLocations() {
            var result = dbCtx.locations.Select(l => new LocationVM() { 
                Id= l.id,
                LocationName = l.location_name
            });

            return result;
        }
        
        private location ParseModel(LocationVM vm) {
            var locModel = new location();
            locModel.id = vm.Id;
            locModel.location_name = vm.LocationName;
            return locModel;
        }

        public void Dispose()
        {
            this.dbCtx.Dispose();
        }
    }
}
