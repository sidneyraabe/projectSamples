using CarMastery.Models.Queries;
using CarMastery.Models.Queries.Home;
using CarMastery.Models.Queries.Inventory;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        VehicleDetailsItem GetById(int vehicleId);
        VehicleEditItem GetEditById(int vehicleId);
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int vehicleId);
        IEnumerable<VehicleListingItem> SearchNew(VehicleSearchParameters input);
        IEnumerable<VehicleListingItem> SearchUsed(VehicleSearchParameters input);
        IEnumerable<VehicleListingItem> SearchAll(VehicleSearchParameters input);
        IEnumerable<HomeFeaturedVehicleListingItem> GetAllFeatured();
    }
}
