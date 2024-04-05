using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderEmail { get; set; }

        [Required]
        public string ReceiverEmail { get; set; }

        public string Message { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

    }
}
