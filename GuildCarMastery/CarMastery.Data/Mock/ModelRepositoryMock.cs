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
    public class ModelRepositoryMock : IModelRepository
    {
        private List<Model> _models;
        public ModelRepositoryMock()
        {
            _models = new List<Model>()
            {
                new Model
                {
                    ModelId = 1,
                    ModelName = "Fiesta",
                    MakeId = 2,
                    UserId = "00000000-0000-0000-0000-000000000000",
                    DateAdded = DateTime.Parse("01-01-2021")
                },
                new Model
                {
                    ModelId = 2,
                    ModelName = "Cayenne",
                    MakeId = 1,
                    UserId = "00000000-0000-0000-0000-000000000000",
                    DateAdded = DateTime.Parse("01-02-2021")
                },
                new Model
                {
                    ModelId = 3,
                    ModelName = "Fusion",
                    MakeId = 2,
                    UserId = "00000000-0000-0000-0000-000000000000",
                    DateAdded = DateTime.Parse("01-03-2021")
                }
            };
        }
        public void Add(Model model)
        {
            _models.Add(model);
        }

        public IEnumerable<ModelListingItem> GetAll()
        {
            MakeRepositoryMock makerepo = new MakeRepositoryMock();
            List<MakeListingItem> makes = makerepo.GetAll().ToList();

            UserRepositoryMock urepo = new UserRepositoryMock();
            List<User> users = urepo.GetAll();

            List<ModelListingItem> results = new List<ModelListingItem>();

            var mli = new ModelListingItem();
            foreach (Model model in _models)
            {
                User matchingUser = users.First(u => u.Id == model.UserId);
                MakeListingItem matchingMake = makes.First(m => m.MakeId == model.MakeId);

                mli.UserId = model.UserId;
                mli.Email = matchingUser.Email;
                mli.MakeName = matchingMake.MakeName;
                mli.ModelId = model.MakeId;
                mli.DateAdded = model.DateAdded;

                results.Add(mli);
            }
            return results;
        }
    }
}
