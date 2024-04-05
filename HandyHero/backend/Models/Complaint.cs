using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Complaint
    {
        [Key]
        public int ComplaintId { get; set; }

        [Required]
        public string Complainant { get;}

        [Required]
        public string Accused { get; set;}

        [Required]
        public string ComplaintMessage { get; set; }

        public DateTime TimeStamp { get; set; }


    }
}
