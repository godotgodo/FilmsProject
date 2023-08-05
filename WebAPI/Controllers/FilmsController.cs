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
    public class FilmsController : Controller
    {
        private IFilmService _filmService;
        private IReviewService _reviewService;

        public FilmsController(IFilmService filmService, IReviewService reviewService)
        {
            _filmService = filmService;
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetFilms()
        {
            try
            {
                var films = _filmService.GetAllFilms();
                var filmDTOs = films.Select(film => DTOConverter.ConvertToFilmDTO(film)).ToList();
                return Ok(filmDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmById(int id)
        {
            try
            {
                var film = _filmService.GetFilmById(id);
                if (film != null)
                {
                    //return Ok(film);
                    return Ok(DTOConverter.ConvertToFilmDTO(film));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddFilm([FromBody] Film film)
        {
            try
            {
                if (film.Rate!=0)
                {
                    return StatusCode(500, "You cannot enter your rating while adding a movie.");
                }
                _filmService.AddFilm(film);
                //return CreatedAtAction(nameof(GetFilmById), new { id = film.FilmId }, film);
                return Ok(film);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] Film film)
        {
            try
            {
                if (film.Rate!=0)
                {
                    return StatusCode(500,"You cannot update film rating while updating film data.");
                }
                var existingFilm = _filmService.GetFilmById(id);
                if (existingFilm == null)
                {
                    return NotFound();
                }

                film.FilmId = id;
                _filmService.UpdateFilm(film);
                return Ok(film);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            try
            {
                var existingFilm = _filmService.GetFilmById(id);
                if (existingFilm == null)
                {
                    return NotFound();
                }

                _filmService.DeleteFilm(existingFilm);
                return Ok(existingFilm);
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
                var reviews = _reviewService.GetReviewsByFilmId(id);

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

        [HttpPost("{id}/reviews")]
        public IActionResult AddReview(int id, [FromBody] Review review)
        {
            try
            {
                if (review.Rate>=10||review.Rate<0)
                {
                    return StatusCode(500, "Rating is calculated out of 10. Enter a value between 0-10");
                }
                review.FilmId = id;
                _reviewService.AddReview(review);
                _filmService.UpdateFilmRating(id);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }
    }
}
