using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWatchlistService
    {
        List<Watchlist> GetWatchlistByUserId(int userId);
        void AddToWatchlist(int userId, int filmId);
        void RemoveFromWatchlist(int userId, int filmId);
    }
}
