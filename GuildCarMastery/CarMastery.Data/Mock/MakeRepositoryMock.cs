using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class MakeRepositoryMock : IMakeRepository
    {
        private List<Make> _makes;
        public MakeRepositoryMock()
        {
            _makes = new List<Make>()
            {
                new Make
                {
                    MakeId = 1,
                    MakeName = "Porsche",
                    UserId = "00000000-0000-0000-0000-000000000000",
                    DateAdded = DateTime.Parse("01-01-2021")
                },
                 new Make
                {
                    MakeId = 2,
                    MakeName = "Ford",
                    UserId = "00000000-0000-0000-0000-000000000000",
                    DateAdded = DateTime.Parse("01-02-2021")
                },                
            };
        }
        public void Add(string makeName, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MakeListingItem> GetAll()
        {
            UserRepositoryMock urepo = new UserRepositoryMock();
            List<User> users = urepo.GetAll();

            List<MakeListingItem> results = new List<MakeListingItem>();

            var mli = new MakeListingItem();
            foreach(Make make in _makes)
            {
                User matchingUser = users.First(u => u.Id == make.UserId);

                mli.UserId = make.UserId;
                mli.Email = matchingUser.Email;
                mli.MakeId = make.MakeId;
                mli.MakeName = make.MakeName;
                mli.DateAdded = make.DateAdded;

                results.Add(mli);
            }
            return results;
        }

        public IEnumerable<ModelListingItem> GetModels(int makeId)
        {
            throw new NotImplementedException();
        }
    }
}
