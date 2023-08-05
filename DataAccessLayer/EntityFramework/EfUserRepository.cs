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
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        public bool Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            if (user.Password == password)
            {
                return true;
            }
            return false;
        }

        public List<User> SearchUsers(string query)
        {
            return _context.Users.Where(u => u.Username.Contains(query)).ToList();
        }
    }
}
