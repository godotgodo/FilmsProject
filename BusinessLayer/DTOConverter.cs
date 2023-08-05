using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class DTOConverter
    {
        public static FilmDTO ConvertToFilmDTO(Film film)
        {
            return new FilmDTO(film.FilmId, film.Title, film.Description, film.Year, film.Time, film.Rate, film.DirectorId, film.Director.Name);
        }
        public static ReviewDTO ConvertToReviewDTO(Review review)
        {
            return new ReviewDTO(review.ReviewId, review.Title, review.Description, review.Rate, review.DateTime, review.UserId, review.User.Username, review.Film.FilmId,review.Film.Title);
        }
        public static UserDTO ConvertToUserDTO(User user)
        {
            return new UserDTO(user.UserId, user.Username, user.Email);
        }
    }
}
