using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMastery.Data;
using CarMastery.Data.ADO;
using CarMastery.Models.Queries;
using CarMastery.Models.Queries.Inventory;
using CarMastery.Models.Queries.Reports;
using CarMastery.Models.Tables;
using NUnit.Framework;

namespace CarMastery.Tests.IntegrationTests
{

    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DbReset", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DbReset", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(50, data.Count());

            Assert.AreEqual(1, data[0].StateId);
            Assert.AreEqual("OH", data[34].StateName);
        }
        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStyleRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(4, data.Count());

            Assert.AreEqual(1, data[0].BodyStyleId);
            Assert.AreEqual("Car", data[0].BodyStyleName);
        }
        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(3, data.Count());

            Assert.AreEqual(1, data[0].PurchaseTypeId);
            Assert.AreEqual("Bank Finance", data[0].PurchaseTypeName);
        }
        [Test]
        public void CanLoadInteriorColors()
        {
            var repo = new InteriorColorRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(4, data.Count());

            Assert.AreEqual(1, data[0].InteriorColorId);
            Assert.AreEqual("Black", data[0].InteriorColorName);
        }

        [Test]
        public void CanLoadExteriorColors()
        {
            var repo = new ExteriorColorRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(5, data.Count());

            Assert.AreEqual(5, data[4].ExteriorColorId);
            Assert.AreEqual("White", data[4].ExteriorColorName);
        }

        [Test]
        public void CanLoadMake()
        {
            var repo = new MakeRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(3, data.Count());
        }

        [Test]
        public void CanAddMake()
        {
            var repo = new MakeRepositoryADO();

            Make make = new Make()
            {
                MakeName = "TestMake",
                UserId = "00000000-0000-0000-0000-000000000000"
            };

            repo.Add(make.MakeName, make.UserId);
            var data = repo.GetAll();


            Assert.AreEqual(4, data.Count());
        }

        [Test]
        public void CanLoadModel()
        {
            var repo = new ModelRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(7, data.Count());
        }

        [Test]
        public void CanAddModel()
        {
            var repo = new ModelRepositoryADO();

            Model model = new Model()
            {
                ModelName = "TestModel",
                MakeId = 1,
                UserId = "00000000-0000-0000-0000-000000000000"
            };

            repo.Add(model);
            var data = repo.GetAll();

            Assert.AreEqual(8, data.Count());
        }

        [Test]
        public void CanLoadSpecial()
        {
            var repo = new SpecialRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(2, data.Count());

            Assert.AreEqual("Hello World!", data[0].SpecialTitle);
            Assert.AreEqual("Uh, I don't know what to put here.", data[1].SpecialDescription);
        }

        [Test]
        public void CanAddSpecial()
        {
            var repo = new SpecialRepositoryADO();

            Special special = new Special()
            {
                SpecialTitle = "TestSpecialTitle",
                SpecialDescription = "TestSpecialDescription"
            };

            repo.Add(special.SpecialTitle, special.SpecialDescription);
            var data = repo.GetAll();

            Assert.AreEqual(3, data.Count());
            Assert.AreEqual(special.SpecialTitle, data[2].SpecialTitle);
            Assert.AreEqual(special.SpecialDescription, data[2].SpecialDescription);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            var repo = new SpecialRepositoryADO();

            var data = repo.GetAll();
            Assert.AreEqual(2, data.Count());

            repo.Delete(1);

            data = repo.GetAll();

            Assert.AreEqual(1, data.Count());
        }

        [Test]
        public void CanAddContactUs()
        {
            var repo = new ContactUsRepositoryADO();

            ContactUs contactUs = new ContactUs()
            {
                Phone = null,
                Name = "Test",
                Email = "NiceEmail@gmail.com",
                Message = "Sup"
            };

            repo.Add(contactUs);

            var data = repo.GetAll();
            Assert.AreEqual(3, data.Count());
            Assert.AreEqual(contactUs.Name, data[2].Name);
        }

        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehicleRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(11, data.Count());

            Assert.AreEqual(data[0].ImageLocation, "");
            Assert.AreEqual("This is a test, it is sold and featured, just to make it weird.", data[4].VehicleDescription);
            Assert.AreEqual(true, data[1].IsAvailable);
        }

        [Test]
        public void CanAddVehicleWithImage()
        {
            var repo = new VehicleRepositoryADO();

            Vehicle vehicle = new Vehicle()
            {
                UserId = "00000000-0000-0000-0000-000000000000",
                ModelId = 1,
                InteriorColorId = 1,
                ExteriorColorId = 1,
                BodyStyleId = 1,
                IsNew = true,
                IsAutoTransmission = true,
                Mileage = 0,
                Vin = "ThisIsA17CharStr",
                Msrp = 20000,
                VehicleSalePrice = 19999,
                VehicleDescription = "This is a car, I think.",
                ModelDate = 2021,
                IsFeatured = true,
                IsAvailable = true,
                ImageLocation = "inventory-12.jpeg"
            };

            repo.Add(vehicle);

            var data = repo.GetAll();

            Assert.AreEqual(vehicle.VehicleId, 12);
            Assert.AreEqual(vehicle.UserId, data[11].UserId);
            Assert.AreEqual(vehicle.Vin, data[11].Vin);
            Assert.AreEqual("inventory-12.jpeg", data[11].ImageLocation);
            Assert.IsNotNull(vehicle.VehicleId);
        }

        [Test]
        public void CanAddVehicleWithoutImage()
        {
            var repo = new VehicleRepositoryADO();

            Vehicle vehicle = new Vehicle()
            {
                UserId = "00000000-0000-0000-0000-000000000000",
                ModelId = 1,
                InteriorColorId = 1,
                ExteriorColorId = 1,
                BodyStyleId = 1,
                IsNew = true,
                IsAutoTransmission = true,
                Mileage = 0,
                Vin = "99999999999999999",
                Msrp = 20000,
                VehicleSalePrice = 19999,
                VehicleDescription = "This is a car, I think.",
                ModelDate = 2021,
                IsFeatured = true,
                IsAvailable = true,
                ImageLocation = null
            };

            repo.Add(vehicle);

            var data = repo.GetAll();

            Assert.IsNotNull(data[11].VehicleId);
            Assert.AreEqual(vehicle.UserId, data[11].UserId);
            Assert.AreEqual(vehicle.Vin, data[11].Vin);
            Assert.AreEqual(data[11].ImageLocation, "");
        }

        [Test]
        public void CanUpdateVehicle()
        {
            var repo = new VehicleRepositoryADO();

            Vehicle vehicle = new Vehicle()
            {
                VehicleId = 1,
                UserId = "00000000-0000-0000-0000-000000000000",
                ModelId = 1,
                InteriorColorId = 1,
                ExteriorColorId = 1,
                BodyStyleId = 1,
                IsNew = true,
                IsAutoTransmission = true,
                Mileage = 0,
                Vin = "99999999999999999",
                Msrp = 20000,
                VehicleSalePrice = 19999,
                VehicleDescription = "UPDATED, BABY!!!!!",
                ModelDate = 2021,
                IsFeatured = true,
                IsAvailable = true,
                ImageLocation = null
            };

            repo.Update(vehicle);

            var data = repo.GetAll();

            Assert.AreEqual("UPDATED, BABY!!!!!", data[0].VehicleDescription);
        }
        [Test]
        public void CanGetVehicleById()
        {
            var repo = new VehicleRepositoryADO();

            VehicleDetailsItem selected = repo.GetById(1);
            Assert.AreEqual(selected.VehicleSalePrice, 15000);

        }
            [Test]
        public void CanLoadSale()
        {
            var repo = new SaleRepositoryADO();

            var data = repo.GetAll();

            Assert.AreEqual(2, data.Count());

            Assert.AreEqual("I Myself", data[0].CustomerName);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", data[1].UserId);
        }

        [Test]
        public void CanAddSaleIfVehicleIsAvailable()
        {
            var repo = new SaleRepositoryADO();
            var vrepo = new VehicleRepositoryADO();

            Sale sale = new Sale()
            {
                UserId = "22222222-2222-2222-2222-222222222222",
                VehicleId = 6,
                StateId = 1,
                PurchaseTypeId = 3,
                Price = "15000",
                DateSold = DateTime.Today,
                CustomerName = "TheTestClass",
                Street1 = "Testy Street",
                Street2 = null,
                City = "test city babyyyyy",
                Zip = "12345"
            };

            var vdata = vrepo.GetAll();
            Assert.AreEqual(true, vdata[5].IsAvailable);

            var success = repo.Add(sale);
            var data = repo.GetAll();
            vdata = vrepo.GetAll();

            Assert.IsTrue(success);

            //check if vehicletable turned unavailable
            Assert.AreEqual(false, vdata[5].IsAvailable);

            Assert.AreEqual(3, data.Count());
            Assert.AreEqual(sale.UserId, data[2].UserId);
            Assert.AreEqual(sale.Street1, data[2].Street1);

        }

        [Test]
        public void CanNotAddSaleIfVehicleIsNotAvailable()
        {
            var repo = new SaleRepositoryADO();

            Sale sale = new Sale()
            {
                UserId = "22222222-2222-2222-2222-222222222222",
                VehicleId = 1,
                StateId = 1,
                PurchaseTypeId = 3,
                Price = "15000",
                DateSold = DateTime.Today,
                Email = null,
                Phone = null,
                CustomerName = "TheTestClass",
                Street1 = "Testy Street",
                Street2 = null,
                City = "test city babyyyyy",
                Zip = "12345"
            };

            var success = repo.Add(sale);
            var data = repo.GetAll();

            Assert.IsFalse(success);
            Assert.AreEqual(2, data.Count());
        }

        [Test]
        public void CanSearchUsedVehicles()
        {
            var repo = new VehicleRepositoryADO();
            var found1 = repo.SearchUsed(new VehicleSearchParameters {
                UserInput = "",
                PriceMin = 0,
                PriceMax = 9999999,
                YearMin = 0,
                YearMax = 2100
            });
            var found2 = repo.SearchUsed(new VehicleSearchParameters
            {
                UserInput = "fusION",
                PriceMin = 0,
                PriceMax = 9999999,
                YearMin = 0,
                YearMax = 2100
            });
            Assert.AreEqual(found1.Count(), 4);
            Assert.AreEqual(found2.Count(), 1);
        }

        [Test]
        public void CanSearchNewVehicles()
        {
            var repo = new VehicleRepositoryADO();
            var found1 = repo.SearchNew(new VehicleSearchParameters {UserInput = ""});
            var found2 = repo.SearchNew(new VehicleSearchParameters
            {UserInput = "porsche",
                PriceMin = 0,
                PriceMax = 9999999,
                YearMin = 0,
                YearMax = 2100
            });
            Assert.AreEqual(found1.Count(), 5);
            Assert.AreEqual(found2.Count(), 2);
        }

        [Test]
        public void CanSearchAllVehicles()
        {
            var repo = new VehicleRepositoryADO();
            var found1 = repo.SearchAll(new VehicleSearchParameters {UserInput = ""});
            var found2 = repo.SearchAll(new VehicleSearchParameters
            {UserInput = "porsche",
                PriceMin = 0,
                PriceMax = 9999999,
                YearMin = 0,
                YearMax = 2100
            });
            Assert.AreEqual(found1.Count(), 9);
            Assert.AreEqual(found2.Count(), 2);
        }
        [Test]
        public void CanLoadFeaturedVehicles()
        {
            var repo = new VehicleRepositoryADO();
            var featuredVehicles = repo.GetAllFeatured();
            
            Assert.AreEqual(featuredVehicles.Count(), 5);
        }

        [Test]
        public void CanSearchReportInventoryNew()
        {
            var repo = new ReportRepositoryADO();

            var found = repo.GetAllNew();
            Assert.AreEqual(found.Count(), 5);
            var foundArray = found.ToArray();
            Assert.AreEqual(foundArray[0].ModelName, "911");
        }

        [Test]
        public void CanSearchReportInventoryUsed()
        {
            var repo = new ReportRepositoryADO();

            var found = repo.GetAllUsed();
            Assert.AreEqual(found.Count(), 3);
            var foundArray = found.ToArray();
            Assert.AreEqual(foundArray[0].ModelName, "Cybertruck");
            Assert.AreEqual(foundArray[0].VehicleCount, 1);
        }

        [Test]
        public void CanSearchReportSalesByUser()
        {
            var repo = new ReportRepositoryADO();
            var param = new ReportsSalesSearchParameters()
            {
                FirstLast = "Test2 Boi2",
                DateMax = null,
                DateMin = null
            };
            var found = repo.SearchSalesByUser(param);
            Assert.AreEqual(found.Count(), 1);
        }

        [Test]
        public void CanSearchReportSalesByAllUser()
        {
            var repo = new ReportRepositoryADO();
            var param = new ReportsSalesSearchParameters()
            {
                DateMax = null,
                DateMin = null
            };
            var found = repo.SearchSalesAll(param);
            Assert.AreEqual(found.Count(), 2);
        }

        [Test]
        public void CanGetModelsFromMake()
        {
            var repo = new MakeRepositoryADO();
            
            var found = repo.GetModels(2);
            Assert.AreEqual(found.Count(), 4);
        }

        [Test]
        public void CanGetEditVehicleItem()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.GetEditById(1);
            Assert.AreEqual(found.ModelId, 1);
        }
        [Test]
        public void CanDeleteVehicle()
        {
            var repo = new VehicleRepositoryADO();

            var found1 = repo.GetAll().Count();
            repo.Delete(2);

            var found2 = repo.GetAll().Count();

            Assert.AreEqual(found1, 11);
            Assert.AreEqual(found2, 10);


        }


    }
}
