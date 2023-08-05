using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWatchedFilmDal
    { 
        public void AddToWatchedFilms(int userId, int filmId);
        public List<WatchedFilm> GetWatchedFilmsByUserId(int userId);
        public void RemoveFromWatchedFilms(int userId, int filmId);
    }
}
