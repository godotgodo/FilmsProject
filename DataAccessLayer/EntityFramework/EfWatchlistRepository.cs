using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWatchlistRepository : IWatchlistDal
    {
        Context _context = new Context();


        public void AddToWatchlistFilms(int userId, int filmId)
        {
            var watchlistFilm = new Watchlist
            {
                UserId = userId,
                FilmId = filmId
            };

            _context.Watchlists.Add(watchlistFilm);
            _context.SaveChanges();
        }

        public List<Watchlist> GetWatchlistByUserId(int userId)
        {
            var watchlists = _context.Watchlists.Where(wf => wf.UserId == userId).Join(_context.Films, wf => wf.FilmId, f => f.FilmId,
            (wf, f) => new Watchlist
            {
                UserId = userId,
                FilmId = wf.FilmId,
                Film = f
            }).ToList();

            return watchlists;
        }

        public void RemoveFromWatchlistFilms(int userId, int filmId)
        {
            var watchlistFilm = _context.Watchlists
                .FirstOrDefault(w => w.UserId == userId && w.FilmId == filmId);

            if (watchlistFilm != null)
            {
                _context.Watchlists.Remove(watchlistFilm);
                _context.SaveChanges();
            }
        }
    }
}
