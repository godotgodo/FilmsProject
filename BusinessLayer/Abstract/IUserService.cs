using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        List<User> SearchUsers(string query);
        bool Login(string email, string password);
    }
}
