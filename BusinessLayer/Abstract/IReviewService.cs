using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
        List<Review> GetReviewsByFilmId(int filmId);
        List<Review> GetReviewsByUserId(int userId);
        List<Review> SearchReviews(string query);
    }
}
