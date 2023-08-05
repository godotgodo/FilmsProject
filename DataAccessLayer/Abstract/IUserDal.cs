using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal:IGenericDal<User>
    {
        public List<User> SearchUsers(string query);
        public bool Login(string email, string password);
    }
}
