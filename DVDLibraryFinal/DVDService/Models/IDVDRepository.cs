using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDService.Models
{
    public interface IDVDRepository
    {
        List<DVD> GetAll();
        DVD Get(int dvdId);
        void Create(DVD newDVD);
        void Update(DVD updatedDVD);
        void Delete(int dvdId);
        List<DVD> GetAllMatchingTitle(string searchString);
        List<DVD> GetAllMatchingReleaseYear(int searchString);
        List<DVD> GetAllMatchingDirectorName(string searchString);
        List<DVD> GetAllMatchingRating(string searchString);

    }
}
