using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.CoreBusiness
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } // Заголовок
        public string Message { get; set; } // Текст сповіщення
        public string RecipientId { get; set; } // Id отримувача з бази Identity
        public bool IsRead { get; set; } // Прочитане чи ні
        public DateTime CreatedAt { get; set; } // Дата створення
    }
}
