using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Relative_Humidity.ViewModel
{
    public class UserModel
    {
        [Required(ErrorMessage = "Invalide Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalide Mot de Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
