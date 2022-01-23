using CarMastery.Data.ADO;
using CarMastery.Data.Interfaces;
using CarMastery.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Factories
{
    public static class BodyStyleRepositoryFactory
    {

        public static IBodyStyleRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new BodyStyleRepositoryADO();
                case "QA":
                    return new BodyStyleRepositoryMock();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }

    }
}
