using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWatchlistDal
    {
        public void AddToWatchlistFilms(int userId, int filmId);
        public List<Watchlist> GetWatchlistByUserId(int userId);
        public void RemoveFromWatchlistFilms(int userId, int filmId);
    }
}
