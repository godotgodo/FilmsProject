using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Watchlist
    {
        [Key]
        public int WatchlistFilmId { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
