using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
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
    }
}