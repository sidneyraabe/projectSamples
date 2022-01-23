using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class BodyStyleRepositoryMock : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>()
            {
                new BodyStyle
                {
                    BodyStyleId = 1,
                    BodyStyleName = "Car"
                },

                new BodyStyle
                {
                    BodyStyleId = 2,
                    BodyStyleName = "SUV"
                },

                new BodyStyle
                {
                    BodyStyleId = 3,
                    BodyStyleName = "Truck"
                },

                new BodyStyle
                {
                    BodyStyleId = 4,
                    BodyStyleName = "Van"
                }
            };
            return bodyStyles;
        }
    }
}
