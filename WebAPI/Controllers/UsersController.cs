using BusinessLayer;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWatchedFilmService _watchedFilmService;
        private readonly IWatchlistService _watchlistService;
        private readonly IReviewService _reviewService;

        public UsersController(IUserService userService, IWatchedFilmService watchedFilmService, IWatchlistService watchlistService, IReviewService reviewService)
        {
            _userService = userService;
            _watchedFilmService = watchedFilmService;
            _watchlistService = watchlistService;
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();

                //optional dto
                var userDTOs = users.Select(user => DTOConverter.ConvertToUserDTO(user)).ToList();
                return Ok(userDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);

                //optional dto
                var userDTO = DTOConverter.ConvertToUserDTO(user);
                if (user == null)
                    return NotFound();

                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult UserLogin([FromBody] User user)
        {
            try
            {
               return Ok(_userService.Login(user.Email, user.Password));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
                _userService.AddUser(user);
                return Ok(DTOConverter.ConvertToUserDTO(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                var existingUser = _userService.GetUserById(id);
                if (existingUser == null)
                    return NotFound();
                user.UserId = existingUser.UserId;
                _userService.UpdateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                _userService.DeleteUser(user);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/watched")]
        public IActionResult GetWatchedFilms(int id)
        {
            try
            {
                var watchedFilms = _watchedFilmService.GetWatchedFilmsByUserId(id);

                // optional dto
                var watchedFilmsFilmDTOs = new List<FilmDTO>();
                foreach (var watchedFilm in watchedFilms)
                {
                    var filmDTO = DTOConverter.ConvertToFilmDTO(watchedFilm.Film);
                    watchedFilmsFilmDTOs.Add(filmDTO);
                }

                return Ok(watchedFilmsFilmDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/watchlist")]
        public IActionResult GetWatchlist(int id)
        {
            try
            {
                var watchlist = _watchlistService.GetWatchlistByUserId(id);

                // optional dto
                var watchlistFilmDTOs = new List<FilmDTO>();
                foreach (var film in watchlist)
                {
                    var filmDTO = DTOConverter.ConvertToFilmDTO(film.Film);
                    watchlistFilmDTOs.Add(filmDTO);
                }
                return Ok(watchlistFilmDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/watched/{filmId}")]
        public IActionResult AddFilmToWatched(int id, int filmId)
        {
            try
            {
                _watchedFilmService.AddToWatchedFilms(id, filmId);
                return Ok("Film added to watched list successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}/watched/{filmId}")]
        public IActionResult RemoveFilmFromWatched(int id, int filmId)
        {
            try
            {
                _watchedFilmService.RemoveFromWatchedFilms(id, filmId);
                return Ok("Film removed from watched list successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/watchlist/{filmId}")]
        public IActionResult AddFilmToWatchlist(int id, int filmId)
        {
            try
            {
                if (_watchedFilmService.GetWatchedFilmsByUserId(id).Find(f => f.FilmId == filmId) != null)
                {
                    return StatusCode(500, "You can't add that because you've already watched that.");
                }
                _watchlistService.AddToWatchlist(id, filmId);
                return Ok("Film added to watchlist successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}/watchlist/{filmId}")]
        public IActionResult RemoveFilmFromWatchlist(int id, int filmId)
        {
            try
            {
                _watchlistService.RemoveFromWatchlist(id, filmId);
                return Ok("Film removed from watchlist successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/reviews")]
        public IActionResult GetReviews(int id)
        {
            try
            {
                var reviews = _reviewService.GetReviewsByUserId(id);

                // optional dto
                var reviewsDTOs = new List<ReviewDTO>();
                foreach (var review in reviews)
                {
                    var reviewDTO = DTOConverter.ConvertToReviewDTO(review);
                    reviewsDTOs.Add(reviewDTO);
                }

                return Ok(reviewsDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
