using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }


        public string Name { get; set; }

        [Required]
        public string password { get; set; }
    }
}
