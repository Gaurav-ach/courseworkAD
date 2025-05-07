using System.ComponentModel.DataAnnotations;

namespace Pusthakalaya.Models
{
    public class DeletionNoticeViewModel
    {
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "A message is required.")]
        public string Message { get; set; } = string.Empty;
    }
}