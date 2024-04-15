using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class FieldWorker
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string WorkType { get; set; }
        public DateTime DOB { get; set; }
        public string NIC { get; set; }
        public string ProfileImage { get; set; }

        private string[] Certificates { get; set; }
        private string[] ExperienceLetter { get; set; }

        [Required]
        public string Status { get; set; } = "false";

        public int AcceptOrRejectBy { get; set; }

    }
}
