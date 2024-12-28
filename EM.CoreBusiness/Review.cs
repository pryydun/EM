using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.CoreBusiness
{
    public class Review
    {
        public int Id { get; set; } // Унікальний ідентифікатор відгуку
        public int EventId { get; set; } // ID події, до якої належить відгук
        public string UserName { get; set; } = string.Empty; // Ім'я користувача
        public string UserId { get; set; } = string.Empty; // ID користувача
        public string Comment { get; set; } = string.Empty; // Текст відгуку
        public int Rating { get; set; } // Рейтинг (1-5 зірок)

        public Event? Event { get; set; } // Навігаційна властивість
    }
}
