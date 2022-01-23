using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class InteriorColorRepositoryMock : IInteriorColorRepository
    {
        private List<InteriorColor> _interiorColors;
        public InteriorColorRepositoryMock()
        {
            _interiorColors = new List<InteriorColor>()
            {
                new InteriorColor
                {
                    InteriorColorId = 1,
                    InteriorColorName = "Grey"
                },
                new InteriorColor
                {
                    InteriorColorId = 2,
                    InteriorColorName = "Blue"
                },
                new InteriorColor
                {
                    InteriorColorId = 3,
                    InteriorColorName = "Rainbow"
                }
            };

        }
        public List<InteriorColor> GetAll()
        {
            return _interiorColors;
        }
    }
}
