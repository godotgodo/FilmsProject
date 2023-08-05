using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Watchlist> Watchlists { get; set; }
        public List<WatchedFilm> WatchedFilms { get; set; }
    }
}
