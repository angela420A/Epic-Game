using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game_Backend.ViewModels
{
    public class UserManageViewModel
    {
        public string UserName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}