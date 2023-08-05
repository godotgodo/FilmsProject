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
    public class EfDirectorRepository : GenericRepository<Director>, IDirectorDal
    {

        public List<Film> GetFilmsByDirectorId(int directorId)
        {
            return _context.Films.Where(f => f.DirectorId == directorId).ToList();
        }

        public List<Director> SearchDirectors(string query)
        {
            return _context.Directors
            .Where(d => d.Name.Contains(query))
            .ToList();
        }
    }

}
