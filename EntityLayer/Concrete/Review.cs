using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public DateTime DateTime { get; set; }

        public User User { get; set; }
        public Film Film { get; set; }
    }

}
