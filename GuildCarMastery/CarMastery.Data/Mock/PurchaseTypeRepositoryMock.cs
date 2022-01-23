using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class PurchaseTypeRepositoryMock : IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAll()
        {
            List<PurchaseType> ptypes = new List<PurchaseType>()
            {
                new PurchaseType
                {
                    PurchaseTypeId = 1,
                    PurchaseTypeName = "Bank Finance"
                },
                new PurchaseType
                {
                    PurchaseTypeId = 2,
                    PurchaseTypeName = "Cash"
                },
                new PurchaseType
                {
                    PurchaseTypeId = 3,
                    PurchaseTypeName = "Dealer Finance"
                }
            };
            return ptypes;
        }
    }
}
