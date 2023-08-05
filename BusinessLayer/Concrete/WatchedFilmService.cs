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
    public class WatchedFilmService : IWatchedFilmService
    {
        private IWatchedFilmDal _watchedFilmDal;
        private IFilmDal _filmDal;
        private IDirectorService _directorService;
        private IWatchlistDal _watchlistDal;
        public WatchedFilmService(IWatchedFilmDal watchedFilmDal, IFilmDal filmDal, IDirectorService directorService, IWatchlistDal watchlistDal)
        {
            _watchedFilmDal = watchedFilmDal;
            _filmDal = filmDal;
            _directorService = directorService;
            _watchlistDal = watchlistDal;
        }
        public void AddToWatchedFilms(int userId, int filmId)
        {
            if (_watchlistDal.GetWatchlistByUserId(userId).Find(f => f.FilmId == filmId) != null)
            {
                _watchlistDal.RemoveFromWatchlistFilms(userId, filmId);
            }
            _watchedFilmDal.AddToWatchedFilms(userId, filmId);
        }

        public List<WatchedFilm> GetWatchedFilmsByUserId(int userId)
        {
            var watchedFilms = _watchedFilmDal.GetWatchedFilmsByUserId(userId);
            foreach (var watchedfilm in watchedFilms)
            {
                watchedfilm.Film = _filmDal.GetById(watchedfilm.FilmId);
                watchedfilm.Film.Director = _directorService.GetDirectorById(watchedfilm.Film.DirectorId);
            }
            return watchedFilms;
        }

        public void RemoveFromWatchedFilms(int userId, int filmId)
        {
            _watchedFilmDal.RemoveFromWatchedFilms(userId, filmId);
        }
    }
}
