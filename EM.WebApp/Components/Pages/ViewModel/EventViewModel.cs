using EM.CoreBusiness;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace EM.WebApp.Components.Pages.ViewModel
{
    public class EventViewModel
    {
        public int Id { get; set; } // Унікальний ідентифікатор події

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title must be less than 150 characters.")]
        public string Title { get; set; } = string.Empty; // Назва події
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty; // Опис події

        [Required(ErrorMessage = "Start Date is required.")]

        public DateTime StartDate { get; set; } = DateTime.Today;


        [Required(ErrorMessage = "End Date is required.")]
     
        public DateTime EndDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; } = string.Empty; // Локація
    }


}

