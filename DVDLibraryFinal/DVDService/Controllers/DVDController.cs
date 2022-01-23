using DVDService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDController : ApiController
    {
        IDVDRepository repo;
        public DVDController()
        {
            repo = DVDRepoFactory.GetRepo();
        }
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
            DVD found = repo.Get(dvdId);

            if(found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD dvd)
        {
            repo.Create(dvd);

            return Created($"dvd/{dvd.Id}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(DVD dvd)
        {
            repo.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTitleMatches(string title)
        {
            return Ok(repo.GetAllMatchingTitle(title));
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetYearMatches(int releaseYear)
        {
            return Ok(repo.GetAllMatchingReleaseYear(releaseYear));
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDirectorMatches(string directorName)
        {
            return Ok(repo.GetAllMatchingDirectorName(directorName));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetRatingMatches(string rating)
        {
            return Ok(repo.GetAllMatchingRating(rating));
        }
    }
}
