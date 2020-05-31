using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Epic_Game.ViewModels
{
    public class UserInfoViewModel
    {
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please enter your nickname.")]
        [StringLength(256, ErrorMessage = "The length  of your nickname is limited between 1 to 256 charactes")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid e-mail address.")]
        public string Email { get; set; }

        [StringLength(256, ErrorMessage = "The length  of your first name is limited between 1 to 256 charactes")]

        public string FirstName { get; set; }

        [StringLength(256, ErrorMessage = "The length  of your last name is limited between 1 to 256 charactes")]
        public string LastName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        
        [DataType(DataType.PostalCode)]
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