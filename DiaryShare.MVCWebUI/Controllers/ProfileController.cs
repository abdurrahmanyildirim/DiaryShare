using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
    [Authorize(Roles = "Admin,Client")]
    public class ProfileController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IDiaryService _diaryService;
        private readonly IFollowerService _followerService;

        public ProfileController(IAccountService accountService,
            IDiaryService diaryService,
            IFollowerService followerService
            )
        {
            _accountService = accountService;
            _diaryService = diaryService;
            _followerService = followerService;
        }

        public ActionResult Main(int id = 0)
        {
            bool isMain = false;
            bool isFollower = false;
            int accountID = (int)Session["userID"];
            List<DiaryForProfileDto> diariesForProfileDto;

            if (id == 0 || accountID == id)
                isMain = true;
            else
                accountID = id;

            if (!isMain)
            {
                isFollower = _followerService.IsFollower((int)Session["userID"], accountID);
            }

            if (isMain)
            {
                diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForOwnAccount(accountID));
            }
            else if (isFollower)
            {
                diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForFollower(accountID));
            }
            else
            {
                diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForPublic(accountID));
            }

            AccountForProfileDto accountForProfileDto = Mapper.Map<AccountForProfileDto>(_accountService.GetAccount(accountID));


            ProfileViewModel profileViewModel = new ProfileViewModel
            {
                AccountInfo = accountForProfileDto,
                DiariesInfo = diariesForProfileDto,
                IsOwnProfile = isMain
            };

            return View(profileViewModel);
        }

        [HttpGet]
        public ActionResult ProfilSettings()
        {
            int id = (int)Session["userID"];
            AccountForModifyDto accountForModifyDto = Mapper.Map<AccountForModifyDto>(_accountService.GetAccount(id));

            return View(accountForModifyDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfilSettings(AccountForModifyDto accountForModify)
        {
            Account account = _accountService.GetAccount((int)Session["userID"]);

            string lastName = accountForModify.LastName.Trim();
            if (accountForModify.FirstName.Trim() == "" || accountForModify.LastName.Trim() == "")
            {
                ViewBag.Info = "İsim veya Soyisim boş bırakılamaz.";
                return View();
            }

            if (accountForModify.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(accountForModify.ImageFile.FileName);
                string extension = Path.GetExtension(accountForModify.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                accountForModify.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                accountForModify.ImageFile.SaveAs(fileName);
                account.ProfilPhotoPath = accountForModify.ImagePath;
            }


            account.PersonelInfo = accountForModify.PersonelInfo;
            account.FirstName = accountForModify.FirstName;
            account.LastName = accountForModify.LastName;
            _accountService.Update(account);

            ViewBag.Info = "Profil ayarları değiştirildi.";

            return View();
        }
    }
}