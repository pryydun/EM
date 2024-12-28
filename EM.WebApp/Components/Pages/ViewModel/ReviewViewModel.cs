using System.ComponentModel.DataAnnotations;

namespace EM.WebApp.Components.Pages.ViewModel
{
    public class ReviewViewModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public int EventId { get; set; }

        
        public int Rating { get; set; }

         
        public string? Comment { get; set; }
    }

}
