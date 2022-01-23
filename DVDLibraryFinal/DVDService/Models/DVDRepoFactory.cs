using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDService.Models
{
    public static class DVDRepoFactory
    {
        public static IDVDRepository GetRepo()
        {
            string mode = ConfigurationManager.AppSettings.Get("Mode");

            switch (mode)
            {
                case "SampleData":
                    return new DVDRepositoryMock();
                case "ADO":
                    return new DVDRepositoryADO();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}