using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DiaryShare.MVCWebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Login()
        {
            //if (Request.Cookies[".ASPXAUTH"] != null)
            //{
            //    return RedirectToAction("Index", "Product");
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountForLoginDto account)
        {
            if (ModelState.IsValid)
            {
                var accountInDb = _accountService.Login(account.Email, account.Password);
                if (accountInDb != null)
                {
                    FormsAuthentication.SetAuthCookie(accountInDb.Email, false);
                    Request.Cookies[".ASPXAUTH"].Expires = DateTime.Now.AddDays(5);
                    Session["userID"] = accountInDb.AccountID;
                    //userInDb.Cookie = Request.Cookies[".ASPXAUTH"].Value;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "Geçersiz Email veya Şifre";
                    return View("Login");
                }
            }
            TempData["Message"] = "Hatalı Giriş Tespit Edildi.";
            return View("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountForRegisterDto account)
        {

            if (!ModelState.IsValid)
            {
                TempData["RegisterMessage"] = "Bir hata meydana geldi";
                return RedirectToAction("Register");
            }

            if (_accountService.UserExists(account.Email))
            {
                TempData["RegisterMessage"] = "Bu Email başka bir kullanıcı tarafından alınmıştır.";
                return RedirectToAction("Register");
            }

            Account newAccount = new Account
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                RoleID = 2,
                IsActive = true,
                MemberDate = DateTime.Now,
                ProfilPhotoPath = "~/Images/DefaultImage.jpg",
                UserName = account.Email
            };

            _accountService.Register(newAccount, account.Password);

            return RedirectToAction("SuccessRegister");
        }

        public ActionResult SuccessRegister()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}