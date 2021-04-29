using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestion_RH.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}