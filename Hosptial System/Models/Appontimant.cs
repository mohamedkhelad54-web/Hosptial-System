using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hosptial_System.Models
{
    [PrimaryKey(nameof(Id))]
    public class Appontimant
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeOnly Time { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey(nameof(PatientId))]
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public int DoctorId { get; set; }
        
    }

}
