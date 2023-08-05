using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFilmService
    {
        List<Film> GetAllFilms();
        Film GetFilmById(int id);
        void AddFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(Film film);
        List<Film> SearchFilms(string query);
        void UpdateFilmRating(int filmId);

    }
}
