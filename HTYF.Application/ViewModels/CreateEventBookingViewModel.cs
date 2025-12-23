using System.ComponentModel.DataAnnotations;

namespace HTYF.Application.ViewModels
{
    public class CreateEventBookingViewModel
    {
        public int EventId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Note { get; set; }
    }
}
