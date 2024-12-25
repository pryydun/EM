using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.CoreBusiness
{
    public class User
    {
        public int Id { get; set; } // Унікальний ID користувача
        public string Name { get; set; } = string.Empty; // Ім'я користувача
        public string Email { get; set; } = string.Empty; // Email користувача

        public ICollection<UserEvents> UserEvents { get; set; } = new List<UserEvents>();

    }
}
