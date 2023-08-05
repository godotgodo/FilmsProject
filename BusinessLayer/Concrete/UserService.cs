using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        private IReviewDal _reviewDal;
        private IWatchlistDal _watchlistDal;
        private IWatchedFilmDal _watchedFilmDal;

        public UserService(IUserDal userDal, IReviewDal reviewDal, IWatchedFilmDal watchedFilmDal, IWatchlistDal watchlistDal)
        {
            _userDal = userDal;
            _reviewDal = reviewDal;
            _watchlistDal = watchlistDal;
            _watchedFilmDal = watchedFilmDal;
        }

        public void AddUser(User user)
        {
            _userDal.Insert(user);
        }
        public void DeleteUser(User user)
        {
            _userDal.Delete(user);
        }
        public List<User> GetAllUsers()
        {
            return _userDal.GetListAll();
        }
        public User GetUserById(int userId)
        {
            var user = _userDal.GetById(userId);
            return user;
        }
        public List<User> SearchUsers(string query)
        {
            return _userDal.SearchUsers(query);
        }
        public void UpdateUser(User user)
        {
            var existingUser = _userDal.GetById(user.UserId);
            if (existingUser == null)
            {
                return;
            }

            existingUser.UserId = user.UserId;
            existingUser.Username = !string.IsNullOrEmpty(user.Username) ? user.Username : existingUser.Username;
            existingUser.Email = !string.IsNullOrEmpty(user.Email) ? user.Email : existingUser.Email;
            existingUser.Password = !string.IsNullOrEmpty(user.Password) ? user.Password : existingUser.Password;
            _userDal.Update(existingUser);
        }
        public bool Login(string email,string password)
        {
            return _userDal.Login(email, password);
        }
    }
}
