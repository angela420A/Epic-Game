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

    public class TransactionHistoryViewModel
    {
        public string PurchaseDate { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set;}
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Old password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        [StringLength(100, ErrorMessage = "The length of {0} is at least {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "You need to confirm new password.")]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Confirm password not match to new password。")]
        public string ConfirmPassword { get; set; }
    }
}