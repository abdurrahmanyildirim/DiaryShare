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
    [Authorize(Roles ="Admin,Client")]
    public class ProfileController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IDiaryService _diaryService;

        public ProfileController(IAccountService accountService,
            IDiaryService diaryService
            )
        {
            _accountService = accountService;
            _diaryService = diaryService;
        }

        public ActionResult Main(int id = 0)
        {
            bool isMain = false;
            int accountID = (int)Session["userID"];

            if (id == 0 || accountID == id)
                isMain = true;
            else
                accountID = id;

            AccountForProfileDto accountForProfileDto = Mapper.Map<AccountForProfileDto>(_accountService.GetAccount(accountID));
            List<DiaryForProfileDto> diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForProfile(accountID));

            ProfileViewModel profileViewModel = new ProfileViewModel
            {
                AccountInfo = accountForProfileDto,
                DiariesInfo = diariesForProfileDto,
                IsOwnProfile = isMain
            };

            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult ChangeProfilePhoto(AccountForProfilePictureDto accountForProfilePictureDto)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Main");
            }
            string fileName = Path.GetFileNameWithoutExtension(accountForProfilePictureDto.ImageFile.FileName);
            string extension = Path.GetExtension(accountForProfilePictureDto.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            accountForProfilePictureDto.ImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            accountForProfilePictureDto.ImageFile.SaveAs(fileName);

            Account account = _accountService.GetAccount((int)Session["userID"]);
            account.ProfilPhotoPath = accountForProfilePictureDto.ImagePath;
            _accountService.Update(account);

            return RedirectToAction("Main");
        }
    }
}