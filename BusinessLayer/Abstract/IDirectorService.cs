using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDirectorService
    {
        List<Director> GetAllDirectors();
        Director GetDirectorById(int id);
        void AddDirector(Director director);
        void UpdateDirector(Director director);
        void DeleteDirector(Director director);
        List<Film> GetFilmsByDirectorId(int directorId);
        List<Director> SearchDirectors(string query);
    }
}
