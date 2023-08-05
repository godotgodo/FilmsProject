using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWatchedFilmService
    {
        List<WatchedFilm> GetWatchedFilmsByUserId(int userId);
        void AddToWatchedFilms(int userId, int filmId);
        void RemoveFromWatchedFilms(int userId, int filmId);
    }
}
