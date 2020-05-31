using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epic_Game.ViewModels
{
    public class UserInfoViewModel
    {
        public string UserID { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Birthday { get; set; }
    }

    public class UserHistoryViewModel
    {
        public DateTime PurchaseDate { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set;}
    }
}