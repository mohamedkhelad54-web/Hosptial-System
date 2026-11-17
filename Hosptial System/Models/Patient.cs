using Microsoft.EntityFrameworkCore;

namespace Hosptial_System.Models
{
    [PrimaryKey(nameof(Id))]
    public class Patient
    {
        public int Id { get; set; }
       public string name { get; set; }

    }
}
