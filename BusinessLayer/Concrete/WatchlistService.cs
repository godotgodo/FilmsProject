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
    public class WatchlistService : IWatchlistService
    {
        private IWatchlistDal _watchlistDal;
        private IFilmDal _filmDal;
        private IDirectorService _directorService;
        public WatchlistService(IWatchlistDal watchlistDal, IFilmDal filmDal, IDirectorService directorService)
        {
            _watchlistDal = watchlistDal;
            _filmDal = filmDal;
            _directorService = directorService;
        }
        public void AddToWatchlist(int userId, int filmId)
        {
            _watchlistDal.AddToWatchlistFilms(userId, filmId);
        }

        public List<Watchlist> GetWatchlistByUserId(int userId)
        {
            var watchlistsFilms = _watchlistDal.GetWatchlistByUserId(userId);
            foreach (var watchlistfilm in watchlistsFilms)
            {
                watchlistfilm.Film = _filmDal.GetById(watchlistfilm.FilmId);
                watchlistfilm.Film.Director = _directorService.GetDirectorById(watchlistfilm.Film.DirectorId);
            }
            return watchlistsFilms;
        }

        public void RemoveFromWatchlist(int userId, int filmId)
        {
            _watchlistDal.RemoveFromWatchlistFilms(userId, filmId);
        }
    }
}
