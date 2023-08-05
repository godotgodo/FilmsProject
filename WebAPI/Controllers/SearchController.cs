using BusinessLayer;
using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private IFilmService _filmService;
        private IDirectorService _directorService;
        private IReviewService _reviewService;
        private IUserService _userService;

        public SearchController(IFilmService filmService, IDirectorService directorService, IReviewService reviewService, IUserService userService)
        {
            _filmService = filmService;
            _directorService = directorService;
            _reviewService = reviewService;
            _userService = userService;
        }
        [HttpGet("{query}")]
        public IActionResult Search(string query)
        {
            var films = _filmService.SearchFilms(query);
            var directors = _directorService.SearchDirectors(query);
            var reviews = _reviewService.SearchReviews(query);
            var users = _userService.SearchUsers(query);
            var userDTOs = new List<UserDTO>();
            foreach (var item in users)
            {
                userDTOs.Add(DTOConverter.ConvertToUserDTO(item));
            }

            var result = new List<object>();

            if (films.Any())
            {
                result.Add(new{Films = films});
            }

            if (directors.Any())
            {
                result.Add(new { Directors = directors });
            }

            if (reviews.Any())
            {
                result.Add(new { Reviews = reviews });
            }

            if (userDTOs.Any())
            {
                result.Add(new { Users = userDTOs });
            }

            return Ok(result);
        }
    }
}

