using System.ComponentModel.DataAnnotations;

namespace EM.CoreBusiness
{
    public class Event
    {
            public int Id { get; set; } // Унікальний ідентифікатор події

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title must be less than 150 characters.")]
        public string Title { get; set; } = string.Empty; // Назва події
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty; // Опис події

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; } // Дата початку
        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { get; set; } // Дата завершення
       
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; } = string.Empty; // Локація


        public ICollection<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
