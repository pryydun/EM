


using System.ComponentModel.DataAnnotations;

namespace EM.WebApp.Components.Pages.ViewModel
{
    public class JoinEventViewModel
    {
        [Required(ErrorMessage = "The UserId field is required.")]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "The EventId field is required.")]
        public int EventId { get; set; }

        [Required]
        public string? Name { get; set; }
       
         
    }
}
