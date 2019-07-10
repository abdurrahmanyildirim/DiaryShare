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
                ViewBag.RegisterMessage = "Bir hata meydana geldi";
                return View();
            }

            if (_accountService.UserExists(account.Email))
            {
                ViewBag.RegisterMessage = "Bu Email başka bir kullanıcı tarafından alınmıştır.";
                return View();
            }

            Account newAccount = new Account
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                RoleID = 2,
                IsActive = true,
                MemberDate = DateTime.Now,
                ProfilPhotoPath = "/Images/DefaultImage.jpg",
                UserName = account.Email
            };

            _accountService.Register(newAccount, account.Password);
            ViewBag.RegisterMessage = "Üyelik işlemi tamamlanmıştır. Giriş yapabilirsiniz.";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["userID"] = null;
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "Admin,Client")]
        public ActionResult ChangeToPassword()
        {
            int id = (int)Session["userID"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeToPassword(AccountForChangePasswordDto account)
        {
            if (account.Password != account.RePassword)
            {
                ViewBag.Info = "Yazdığınız şifreler eşleşmemektedir! Lütfen Tekrar Deneyiniz";
                return View();
            }
            int id = (int)Session["userID"];
            if (!_accountService.ChangePassword(_accountService.GetAccount(id), account.Password))
            {
                ViewBag.Info = "Yeni şifre eski şifre ile aynı olamaz!";
                return View();
            }
            ViewBag.Info = "Şifreniz başarıyla değiştirildi.";
            return View();
        }
    }
}