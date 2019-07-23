using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                isFollower = _followerService.IsFollower((int)Session["userID"], accountID);


            if (isMain)
                diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForOwnAccount(accountID));
            else if (isFollower)
                diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForFollower(accountID));
            else
                diariesForProfileDto = Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForPublic(accountID));

            AccountForProfileDto accountForProfileDto = Mapper.Map<AccountForProfileDto>(_accountService.GetAccount(accountID));
            int followerCount = _followerService.GetFollowerCount(accountID);
            int followingCount = _followerService.GetFollowingCount(accountID);

            ProfileViewModel profileViewModel = new ProfileViewModel
            {
                AccountInfo = accountForProfileDto,
                DiariesInfo = diariesForProfileDto,
                IsOwnProfile = isMain,
                IsFollower = isFollower,
                FollowerCount = followerCount,
                FollowingCount = followingCount
            };

            return View(profileViewModel);
        }

        [HttpPost]
        public JsonResult GetListOfFollowers(int id)
        {
            List<AccountForFollowerListDto> accounts = Mapper.Map<List<AccountForFollowerListDto>>(_accountService.GetFollowerAccounts(id));

            return Json(accounts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetListOfFollowings(int id)
        {
            List<AccountForFollowerListDto> accounts = Mapper.Map<List<AccountForFollowerListDto>>(_accountService.GetFollowingAccounts(id));

            return Json(accounts, JsonRequestBehavior.AllowGet);
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
                accountForModify.ImagePath = "/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
                accountForModify.ImageFile.SaveAs(fileName);
                account.ProfilPhotoPath = accountForModify.ImagePath;
            }


            account.PersonelInfo = accountForModify.PersonelInfo;
            account.FirstName = accountForModify.FirstName;
            account.LastName = accountForModify.LastName;
            _accountService.Update(account);

            ViewBag.Info = "Profil ayarları değiştirildi.";

            return View(Mapper.Map<AccountForModifyDto>(account));
        }

        [HttpPost]
        public JsonResult ChangeToFollower(int id)
        {
            int fromAccountID = (int)Session["userID"];
            Follower follower = _followerService.GetFollower(fromAccountID, id);

            if (follower == null)
            {
                _followerService.Add(new Follower
                {
                    FollowDate = DateTime.Now,
                    FromAccountID = fromAccountID,
                    ToAccountID = id
                });
                return Json(Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForFollower(id)), JsonRequestBehavior.AllowGet);
            }
            else
            {
                _followerService.Delete(follower);

                return Json(Mapper.Map<List<DiaryForProfileDto>>(_diaryService.GetDiariesForPublic(id)), JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public void RemoveDiary(int id)
        {
            _diaryService.Delete(id);
        }
    }
}