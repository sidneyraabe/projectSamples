using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class ExteriorColorRepositoryMock : IExteriorColorRepository
    {
        private List<ExteriorColor> _exteriorColors;
        public ExteriorColorRepositoryMock()
        {
            _exteriorColors = new List<ExteriorColor>()
            {
                new ExteriorColor
                {
                    ExteriorColorId = 1,
                    ExteriorColorName = "Red"
                },
                new ExteriorColor
                {
                    ExteriorColorId = 2,
                    ExteriorColorName = "Blood Red"
                },
                new ExteriorColor
                {
                    ExteriorColorId = 3,
                    ExteriorColorName = "Bright Red"
                },
                new ExteriorColor
                {
                    ExteriorColorId = 4,
                    ExteriorColorName = "Very Red"
                }
            };
        }
        public List<ExteriorColor> GetAll()
        {
            return _exteriorColors;
        }
    }
}
