using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDirectorDal : IGenericDal<Director>
    {
        public List<Film> GetFilmsByDirectorId(int directorId);
        public List<Director> SearchDirectors(string query);
    }
}
