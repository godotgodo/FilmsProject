using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=FilmsDB; integrated security=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<WatchedFilm> WatchedFilms { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Review> Reviews{ get; set; }
    }
}
