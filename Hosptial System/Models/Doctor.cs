using Microsoft.EntityFrameworkCore;

namespace Hosptial_System.Models
{
    [PrimaryKey(nameof(Id))]
    public class Doctor
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; } 
        public string Specialization { get; set; }
        public string Img { get; set; }

    }
}
