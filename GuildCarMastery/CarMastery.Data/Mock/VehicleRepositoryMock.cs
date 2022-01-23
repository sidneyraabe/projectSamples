using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Queries.Home;
using CarMastery.Models.Queries.Inventory;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class VehicleRepositoryMock : IVehicleRepository
    {
        public void Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HomeFeaturedVehicleListingItem> GetAllFeatured()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleListingItem> SearchAll(VehicleSearchParameters input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleListingItem> SearchNew(VehicleSearchParameters input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleListingItem> SearchUsed(VehicleSearchParameters input)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public VehicleDetailsItem GetById(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public VehicleEditItem GetEditById(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
