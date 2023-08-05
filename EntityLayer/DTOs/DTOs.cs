using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public record FilmDTO(int FilmId, string Title, string Description, int Year, int Time, decimal Rate,int DirectorId, string DirectorName);
    public record UserDTO(int UserId,string Username,string Email);
    public record ReviewDTO(int ReviewId,string Title,string Description,decimal Rate,DateTime Time,int UserId,string Username,int FilmId,string FilmTitle);
}
