using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReviewService : IReviewService
    {
        private IReviewDal _reviewDal;
        private IUserDal _userDal;
        private IFilmDal _filmDal;
        public ReviewService(IReviewDal reviewDal, IUserDal userDal, IFilmDal filmDal)
        {
            _reviewDal = reviewDal;
            _userDal = userDal;
            _filmDal = filmDal;
        }
        public void AddReview(Review review)
        {
            review.DateTime = DateTime.Now;
            _reviewDal.Insert(review);
        }
        public void DeleteReview(Review review)
        {
            _reviewDal.Delete(review);
        }
        public List<Review> GetAllReviews()
        {
            return _reviewDal.GetListAll();
        }
        public Review GetReviewById(int id)
        {
            var review = _reviewDal.GetById(id);
            review.User = _userDal.GetById(review.UserId);
            return review;
        }
        public List<Review> GetReviewsByFilmId(int filmId)
        {
            var reviews = _reviewDal.GetReviewsByFilmId(filmId);

            foreach (var item in reviews)
            {
                item.User = _userDal.GetById(item.UserId);
                item.Film = _filmDal.GetById(item.FilmId);
            }
            return reviews;

        }
        public List<Review> GetReviewsByUserId(int userId)
        {
            var reviews = _reviewDal.GetReviewsByUserId(userId);
            foreach (var review in reviews)
            {
                review.User = _userDal.GetById(review.UserId);
                review.Film = _filmDal.GetById(review.FilmId);
            }
            return reviews;
        }
        public List<Review> SearchReviews(string query)
        {
            return _reviewDal.SearchReviews(query);
        }
        public void UpdateReview(Review review)
        {
            _reviewDal.Update(review);
        }
    }
}
