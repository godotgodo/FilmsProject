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
    public class EfWatchedFilmRepository : IWatchedFilmDal
    {
        Context _context = new Context();

        public void AddToWatchedFilms(int userId, int filmId)
        {
            // Kullanıcının izlediği filmler listesine bir film eklemek için gerekli işlemleri gerçekleştirin.
            var watchedFilm = new WatchedFilm
            {
                UserId = userId,
                FilmId = filmId,
                DateTime = DateTime.Now
            };

            _context.WatchedFilms.Add(watchedFilm);
            _context.SaveChanges();
        }

        public List<WatchedFilm> GetWatchedFilmsByUserId(int userId)
        {
            // Kullanıcının izlediği filmleri kullanıcı kimliği (userId) kullanarak almak için gerekli işlemleri gerçekleştirin.
            var watchedFilmData = _context.WatchedFilms
                .Where(wf => wf.UserId == userId)
                .Join(_context.Films, wf => wf.FilmId, f => f.FilmId,
                    (wf, f) => new WatchedFilm
                    {
                        UserId = userId,
                        FilmId = wf.FilmId,
                        DateTime = wf.DateTime,
                        Film = f
                    }).ToList();


            return watchedFilmData;
        }

        public void RemoveFromWatchedFilms(int userId, int filmId)
        {
            // Kullanıcının izlediği filmler listesinden bir filmi kaldırmak için gerekli işlemleri gerçekleştirin.
            var watchedFilm = _context.WatchedFilms
                .SingleOrDefault(wf => wf.UserId == userId && wf.FilmId == filmId);

            if (watchedFilm != null)
            {
                _context.WatchedFilms.Remove(watchedFilm);
                _context.SaveChanges();
            }
        }
    }
}
