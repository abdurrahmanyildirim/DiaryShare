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
        public ActionResult ChangeToPhotoOrPersonelInfo()
        {
            int id = (int)Session["userID"];
            AccountForModifyDto accountForModifyDto = Mapper.Map<AccountForModifyDto>(_accountService.GetAccount(id));

            return View(accountForModifyDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeToPhotoOrPersonelInfo(AccountForModifyDto accountForModify)
        {

            if (accountForModify.FirstName.Trim() == null || accountForModify.LastName.Trim() == null)
            {
                return RedirectToAction("Main");
            }

            string fileName = Path.GetFileNameWithoutExtension(accountForModify.ImageFile.FileName);
            string extension = Path.GetExtension(accountForModify.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            accountForModify.ImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            accountForModify.ImageFile.SaveAs(fileName);

            Account account = _accountService.GetAccount((int)Session["userID"]);
            account.ProfilPhotoPath = accountForModify.ImagePath;
            account.PersonelInfo = accountForModify.PersonelInfo;
            account.FirstName = accountForModify.FirstName;
            account.LastName = accountForModify.LastName;
            _accountService.Update(account);

            return RedirectToAction("Main");
        }
    }
}