using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class FilmService : IFilmService
    {
        private IFilmDal _filmDal;
        private IDirectorDal _directorDal;
        private IReviewDal _reviewDal;
        private IUserDal _userDal;
        public FilmService(IFilmDal filmDal, IDirectorDal directorDal, IReviewDal reviewDal, IUserDal userDal)
        {
            _filmDal = filmDal;
            _directorDal = directorDal;
            _reviewDal = reviewDal;
            _userDal = userDal;
        }
        public void AddFilm(Film film)
        {
            _filmDal.Insert(film);
        }
        public void DeleteFilm(Film film)
        {
            _filmDal.Delete(film);
        }
        public List<Film> GetAllFilms()
        {
            var films = _filmDal.GetListAll();
            if (films!=null)
            {
                foreach (var film in films)
                {
                    film.Director = _directorDal.GetById(film.DirectorId);
                }
            }
            return _filmDal.GetListAll();
        }
        public Film GetFilmById(int id)
        {
            var film = _filmDal.GetById(id);
            if (film != null)
            {
                film.Director = _directorDal.GetById(film.DirectorId);
                film.Reviews = _reviewDal.GetReviewsByFilmId(id);
                foreach (var item in film.Reviews)
                {
                    item.User = _userDal.GetById(item.UserId);
                }
            }
            return film;
        }
        public void UpdateFilm(Film film)
        {
            var existingFilm = _filmDal.GetById(film.FilmId);

            if (existingFilm == null)
            {
                return;
            }

            // to update only the desired fields
            existingFilm.Title = !string.IsNullOrEmpty(film.Title) ? film.Title : existingFilm.Title;
            existingFilm.Description = !string.IsNullOrEmpty(film.Description) ? film.Description : existingFilm.Description;
            existingFilm.Year = film.Year != 0 ? film.Year : existingFilm.Year;
            existingFilm.Time = film.Time != 0 ? film.Time : existingFilm.Time;
            existingFilm.Rate = film.Rate != 0 ? film.Rate : existingFilm.Rate;
            existingFilm.DirectorId = film.DirectorId != 0 ? film.DirectorId : existingFilm.DirectorId;

            if (film.Reviews != null)
            {
                existingFilm.Reviews = film.Reviews;
            }

            _filmDal.Update(existingFilm);
        }
        public List<Film> SearchFilms(string query)
        {
            return _filmDal.SearchFilms(query);
        }
        public void UpdateFilmRating(int filmId)
        {
            var film = _filmDal.GetById(filmId);
            var reviews = _reviewDal.GetReviewsByFilmId(filmId).ToArray();
            decimal totalRating = 0;
            foreach (var review in reviews)
            {
                totalRating = totalRating + review.Rate;
            }
            film.Rate = totalRating / reviews.Length;
            _filmDal.Update(film);
        }
    }
}
