using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReviewDal : IGenericDal<Review>
    {
        public List<Review> GetReviewsByUserId(int userId);
        public List<Review> GetReviewsByFilmId(int filmId);
        public List<Review> SearchReviews(string query);
    }
}
