using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDService.Models;

namespace DVDService.Models
{
    public class DVDRepositoryMock : IDVDRepository
    {
        private List<DVD> _dvds;

        public DVDRepositoryMock()
        {
            _dvds = new List<DVD>()

            {
                new DVD
                {
                    Id = 1,
                    Title = "Minions",
                    ReleaseYear = 2017,
                    Director = "Kyle Balda & Pierre Coffin",
                    Rating = "PG",
                    Notes = "Small. Yellow. Ridiculous."
                },

                new DVD
                {
                    Id = 43,
                    Title = "Muppets Take Manhattan",
                    ReleaseYear = 1984,
                    Director = "Frank Oz",
                    Rating = "G",
                    Notes = "Muppets .... ON BROADWAY!"
                },

                new DVD
                {
                    Id = 45,
                    Title = "The Great Muppet Caper",
                    ReleaseYear = 1981,
                    Director = "Jim Henson",
                    Rating = "G",
                    Notes = "Diamonds. Muppets. Intrigue. A+++"
                }
            };
        }

        public List<DVD> GetAll()
        {
            return _dvds;
        }
        public DVD Get(int dvdId)
        {
            return _dvds.FirstOrDefault(d => d.Id == dvdId);
        }
        public void Create(DVD newDVD)
        {
            newDVD.Id = 0;
            if (_dvds.Any())
            {
                newDVD.Id = _dvds.Max(d => d.Id) + 1;
            }
            
            _dvds.Add(newDVD);
        }

        public void Update(DVD updatedDVD)
        {
            Delete(updatedDVD.Id);
            Create(updatedDVD);
        }

        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(d => d.Id == dvdId);
        }

        //Search
        public List<DVD> GetAllMatchingTitle(string searchString)
        {
            var _searchList = from DVD in _dvds
                              where DVD.Title.Contains(searchString)
                              select DVD;

            // method:
            //_searchList = _dvds.Where(x => x.Title.Contains(searchString));
            List<DVD> _results = new List<DVD>();

            foreach (DVD d in _searchList)
                _results.Add(d);

            return _results;
        }

        public List<DVD> GetAllMatchingReleaseYear(int searchString)
        {
            var _searchList = from DVD in _dvds
                              where DVD.ReleaseYear == searchString
                              select DVD;
            List<DVD> _results = new List<DVD>();

            foreach (DVD d in _searchList)
                _results.Add(d);

            return _results;
        }

        public List<DVD> GetAllMatchingDirectorName(string searchString)
        {
            var _searchList = from DVD in _dvds
                              where DVD.Director.Contains(searchString)
                              select DVD;
            List<DVD> _results = new List<DVD>();

            foreach (DVD d in _searchList)
                _results.Add(d);

            return _results;
        }

        public List<DVD> GetAllMatchingRating(string searchString)
        {
            var _searchList = from DVD in _dvds
                              where DVD.Rating == searchString
                              select DVD;
            List<DVD> _results = new List<DVD>();

            foreach (DVD d in _searchList)
                _results.Add(d);

            return _results;
        }
    }
}