using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class SpecialRepositoryMock : ISpecialRepository
    {
        private List<Special> _specials;
        public SpecialRepositoryMock()
        {
            _specials = new List<Special>()
            {
                new Special
                {
                    SpecialId = 1,
                    SpecialTitle = "Hello World!",
                    SpecialDescription = "I wish I had a friend. :("
                },
                new Special
                {
                    SpecialId = 2,
                    SpecialTitle = "Hello, Special at SpecialId=1!",
                    SpecialDescription = "I noticed you were lonely, so I'm here to keep you company! :)"
                }
            };
        }
        public void Add(string specialTitle, string specialDescription)
        {
            throw new NotImplementedException();
        }

        public void Delete(int specialId)
        {
            _specials.RemoveAll(s => s.SpecialId == specialId);
        }

        public List<Special> GetAll()
        {
            return _specials;
        }
    }
}
