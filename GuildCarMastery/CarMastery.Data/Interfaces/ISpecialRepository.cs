using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetAll();
        void Delete(int specialId);
        void Add(string specialTitle, string specialDescription);
    }
}
