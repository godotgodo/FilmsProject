using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DirectorService:IDirectorService
    {
        private IDirectorDal _directorDal;

        public DirectorService(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }
        public List<Director> GetAllDirectors()
        {
            return _directorDal.GetListAll();
        }
        public Director GetDirectorById(int id)
        {
            return _directorDal.GetById(id);
        }
        public void AddDirector(Director director)
        {
            _directorDal.Insert(director);
        }
        public void UpdateDirector(Director director)
        {
            _directorDal.Update(director);
        }
        public void DeleteDirector(Director director)
        {
            _directorDal.Delete(director);
        }
        public List<Film> GetFilmsByDirectorId(int directorId)
        {
            return _directorDal.GetFilmsByDirectorId(directorId);
        }
        public List<Director> SearchDirectors(string query)
        {
            return _directorDal.SearchDirectors(query);
        }
    }
}
