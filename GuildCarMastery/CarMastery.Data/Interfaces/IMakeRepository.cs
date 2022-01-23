using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IMakeRepository
    {
        IEnumerable<MakeListingItem> GetAll();
        IEnumerable<ModelListingItem> GetModels(int makeId);
        void Add(string makeName, string userId);
    }
}
