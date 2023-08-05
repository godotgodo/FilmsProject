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
    public class EfReviewRepository : GenericRepository<Review>, IReviewDal
    {
        public List<Review> GetReviewsByFilmId(int filmId)
        {
            return _context.Reviews.Where(r => r.FilmId == filmId).ToList();
        }

        public List<Review> GetReviewsByUserId(int userId)
        {
            return _context.Reviews.Where(r => r.UserId == userId).ToList();
        }

        public List<Review> SearchReviews(string query)
        {
            return _context.Reviews.Where(r => r.Title.Contains(query) || r.Description.Contains(query)).ToList();
        }
    }
}
