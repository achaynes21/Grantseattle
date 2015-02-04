using InventoryERP.Core;
using InventoryERP.Services.Models;
using InventoryERP.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryERP.Web.Models
{
    #region Membership

    public class ResetPasswordModel
    {
        public string Email { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter your new password.")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Please enter a email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }
    }
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please enter First Name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid Email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email.")]
        [System.Web.Mvc.Remote(MVC.RouteNames.Account.EmailExist, ErrorMessage = "This email address is already registered with another account.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Please confirm password.")]
        public string ConfirmPassword { get; set; }

        [MustBeTrue(ErrorMessage = "You must agree to the Terms of Use.")]
        public bool Agree { get; set; }

        public bool RememberMe { get; set; }
    }

    #endregion

    public class SignInViewModel
    {
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    

}