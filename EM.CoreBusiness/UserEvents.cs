using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.CoreBusiness
{

  

        public class UserEvent
        {
            public int Id { get; set; } // Унікальний ідентифікатор
            public string? UserId { get; set; } // Ідентифікатор користувача
            public int EventId { get; set; } // Ідентифікатор події
            public string? Name { get; set; } // Ім'я користувача
            public Event? Event { get; set; }
            
    }



    }
 
