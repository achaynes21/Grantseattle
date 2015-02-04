using InventoryERP.Services;
using InventoryERP.Core;
using InventoryERP.Domain;
using InventoryERP.Web.Models;
using InventoryERP.Web.ModelConverters;
using InventoryERP.Web.ModelBuilders;
using InventoryERP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryERP.Web.Controllers
{
    [Authorize]
    public partial class AccountController : BaseMVCController
    {
        protected IAccountService AccountService { get; private set; }
        protected IAuthenticationService AuthenticationService { get; private set; }
        protected IEmailService EmailService { get; private set; }

        public AccountController(IAccountService accountService, IAuthenticationService authenticationService, IEmailService emailService)
        {
            AccountService = accountService;
            AuthenticationService = authenticationService;
            EmailService = emailService;
        }

        #region Authentication

        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult LogInWithFacebook(string email, string firstName, string lastName)
        {
            if (email.IsNullOrWhiteSpace()) return Json(false);
            if (!email.IsEmail()) return Json(false);
            if (firstName.IsNullOrWhiteSpace() || lastName.IsNullOrWhiteSpace()) return Json(false);

            if (AuthenticationService.FacebookLoginAsMember(email, true))
                return Json(true);

            var model = new CreateMemberModel { Email = email, FirstName = firstName, LastName = lastName };

            Member member = AccountService.CreateMember(model);
            if (member != null)
            {
                Authentication.SaveAuthenticationInformation(member.Id, member.Email, "Member", true, member.FirstName + " " + member.LastName, member.FriendlyUrl);
                EmailService.SendEmailVarification(member.FirstName + " " + member.LastName, member.Email, member.EmailVerificationCode);                

                return Json(true);
            }

            return Json(false);
        }

        [AllowAnonymous]
        public virtual ActionResult SignIn()
        {
            if (HttpContextHelper.IsAuthenticated)
                return RedirectToRoute(MVC.RouteNames.Home.Index);
            return View(new SignInViewModel());
        }
        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = SignInModelBuilder.SignIn(model, AuthenticationService, ModelState);

            if (ModelState.IsValid)

                if (user.Role.Equals("Admin")) { return RedirectToRoute(MVC.RouteNames.Home.Index); }
                else if (user.Role.Equals("Member")) { return RedirectToAction("Index","Client"); }
                

            return View(model);
        }

        public virtual ActionResult SignOut()
        {
            AuthenticationService.Logout();

            return RedirectToRoute(MVC.RouteNames.Account.SignIn);
        }

        #endregion

        #region Membership

        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult SignUpWithFacebook(string email, string firstName, string lastName)
        {
            if (email.IsNullOrWhiteSpace()) return Json(false);
            if (!email.IsEmail()) return Json(false);
            if (firstName.IsNullOrWhiteSpace() || lastName.IsNullOrWhiteSpace()) return Json(false);

            var model = new CreateMemberModel { Email = email, FirstName = firstName, LastName = lastName };

            Member member = AccountService.CreateMember(model);
            if (member != null)
            {
                AuthenticationService.LoginAsMember(model.Email, string.Empty, true);
                EmailService.SendEmailVarification(member.FirstName + " " + member.LastName, member.Email, member.EmailVerificationCode);

                return Json(true);
            }           

            return Json(false);
        }

        [AllowAnonymous]
        public virtual ActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }
        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            #region Check if email already exist

            var memberCheck = AccountService.GetUserByEmail(model.Email.Trim());
            if (memberCheck != null)
            {
                ModelState.AddModelError("Email", "This email address is already registered with another account.");
                return View(model);
            }

            #endregion

            Member member = AccountService.CreateMember(model.ToCreateMemberModel());
            if (member != null)
            {
                AuthenticationService.LoginAsMember(model.Email, model.Password, model.RememberMe);
                //EmailService.SendEmailVarification(member.FirstName + " " + member.LastName, member.Email, member.EmailVerificationCode);

                //return RedirectToRoute(MVC.RouteNames.Home.Index);
                return RedirectToAction("Index", "Client");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult CreateAdmin()
        {
            try
            {

                var member = new Member();
                member.Email = "aileenhaynes21@gmail.com";
                member.FirstName = "aileen";
                member.LastName = "haynes";
                member.Password = "123456#";
                member.EmailVerificationCode = Guid.NewGuid().NewGuidString();
                member.CreatedAt = DateTime.UtcNow;
                member.Role = "Admin";
                #region Check if email already exist

                var memberCheck = AccountService.GetUserByEmail(member.Email.Trim());
                if (memberCheck != null)
                {
                    ModelState.AddModelError("Email", "This email address is already registered with another account.");
                    return RedirectToAction("SignIn");
                }

                #endregion

                AccountService.SaveMember(member);
                return RedirectToAction("SignIn");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        [AllowAnonymous]
        public virtual ActionResult EmailConfirmation(string code)
        {
            var member = AccountService.GetMemberByEmailVerificationCode(code);
            if (member != null)
            {
                member.EmailVerified = true;

                AccountService.SaveMember(member);

                ViewBag.Heading = "Email Confirmed";
                ViewBag.Message = "Thank you for confirming your email address. You now will receive email notifications from InventoryERP.com.";

                return View();
            }

            ViewBag.Heading = "Email Not Confirmed";
            ViewBag.Message = "Sorry, you email verification code is not valid. Please use the verification code that has been sent to you.";

            return View();
        }

        [AllowAnonymous]
        public virtual ActionResult ForgotPassword()
        {
            return View(new ForgotPasswordModel());
        }
        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var member = AccountService.GetUserByEmail(model.Email);
            if (member != null)
            {
                string code = AccountService.SetResetPasswordCode(model.Email);

                EmailService.SendForgotPassword(member.FirstName + " " + member.LastName, member.Email, member.Password);
                
                ViewData["Message"] = "An email has been sent to your email address with a link to reset your password.";

                return View(model);
            }

            ModelState.AddModelError("Email", "No user was found with this email address.");

            return View(model);
        }

        [AllowAnonymous]        
        public virtual ActionResult ResetPassword(string code, string email)
        {
            var compareDate = DateTime.Parse(DateTime.UtcNow.ToShortDateString() + " 11:59 PM");

            var member = AccountService.GetMemberByResetPasswordCodeEmail(code, email);
            if (member != null)
            {
                if(DateTime.Compare(member.PasswordResetCodeExpired.Value, compareDate) < 0)
                {
                    ViewData["Message"] = "Sorry! Your password reset period has expired.";
                    return View(new ResetPasswordModel());
                }

                var model = new ResetPasswordModel { Code = code, Email = email };
                return View(model);
            }

            return RedirectToRoute(MVC.RouteNames.Home.Index);
        }
        [AllowAnonymous]
        [HttpPost]
        public virtual ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (AccountService.CheckForValidResetPassword(model.Email, model.Code))
                AccountService.ResetPassword(model.Email, model.Password);

            ViewData["Message"] = "Your password has been reset successfully.";

            return View(model);
        }

        #endregion

        [AllowAnonymous]
        public virtual ActionResult EmailExist(string email)
        {
            if (email.IsNotNullOrWhiteSpace()) return Json(true, JsonRequestBehavior.AllowGet);

            var user = AccountService.GetUserByEmail(email.Trim());
            if (user != null) return Json(false, JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PasswordChange()
        {
            var resetPass = new ResetPasswordModel();
            return View(resetPass);
        }

        [HttpPost]
        public ActionResult PasswordChange(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid) return View(resetPasswordModel);
            var userId = HttpContextHelper.Current.UserId;
            var user = AccountService.GetUserById(userId);
            user.Password = resetPasswordModel.Password;
            AccountService.SaveMember(user);
            ViewBag.SuccessMessage = "Password Update Successfully";
            return View();
        }
	}
}