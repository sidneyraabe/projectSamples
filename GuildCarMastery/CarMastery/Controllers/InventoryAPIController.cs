using CarMastery.Data.Factories;
using CarMastery.Models.Queries;
using CarMastery.Models.Queries.Reports;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarMastery.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/inventory/new")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(string UserInput, decimal? PriceMin, decimal? PriceMax, int? YearMin, int? YearMax)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    UserInput = UserInput,
                    PriceMin = PriceMin,
                    PriceMax = PriceMax,
                    YearMin = YearMin,
                    YearMax = YearMax
                };

                var result = repo.SearchNew(parameters);
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/used")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsed(string UserInput, decimal? PriceMin, decimal? PriceMax, int? YearMin, int? YearMax)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    UserInput = UserInput,
                    PriceMin = PriceMin,
                    PriceMax = PriceMax,
                    YearMin = YearMin,
                    YearMax = YearMax
                };

                var result = repo.SearchUsed(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/sales/index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchAll(string UserInput, decimal? PriceMin, decimal? PriceMax, int? YearMin, int? YearMax)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    UserInput = UserInput,
                    PriceMin = PriceMin,
                    PriceMax = PriceMax,
                    YearMin = YearMin,
                    YearMax = YearMax
                };

                var result = repo.SearchAll(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/vehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult AdminSearchAll(string UserInput, decimal? PriceMin, decimal? PriceMax, int? YearMin, int? YearMax)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    UserInput = UserInput,
                    PriceMin = PriceMin,
                    PriceMax = PriceMax,
                    YearMin = YearMin,
                    YearMax = YearMax
                };

                var result = repo.SearchAll(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/addvehicle")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ModelsFromMake(int makeId)
        {
            var repo = MakeRepositoryFactory.GetRepository();

            try
            {               
                var result = repo.GetModels(makeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/specials")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddSpecial(string specialTitle, string specialDescription)
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            try
            {
                repo.Add(specialTitle, specialDescription);
                return Ok(repo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/specials")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteSpecial(int id)
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            try
            {
                repo.Delete(id);
                return Ok(repo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/reports/sales")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchSales(string FirstLast, string DateMin, string DateMax)
        {
            var repo = ReportRepositoryFactory.GetRepository();

            try
            {
                var parameters = new ReportsSalesSearchParameters()
                {
                    FirstLast = FirstLast,
                    DateMin = DateMin,
                    DateMax = DateMax
                };

                var result = repo.SearchSalesByUser(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/deletevehicle")]
        [AcceptVerbs("DELETE")]

        public IHttpActionResult DeleteVehicle(int vehicleId)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {              
                repo.Delete(vehicleId);
                repo.GetAll();
                return Ok(repo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
