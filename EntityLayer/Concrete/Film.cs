using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public decimal Rate { get; set; }
        public int DirectorId { get; set; }

        public Director Director { get; set; }
        public List<Review> Reviews { get; set; }
    }

}
