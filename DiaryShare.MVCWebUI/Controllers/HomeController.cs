using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.Helpers;
using DiaryShare.MVCWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
    [Authorize(Roles = "Client,Admin")]
    public class HomeController : Controller
    {
        private readonly IFollowerService _followerService;
        private readonly IDiaryService _diaryService;
        private readonly IAccountService _accountService;

        public HomeController(IFollowerService followerService,
            IDiaryService diaryService,
            IAccountService accountService
            )
        {
            _followerService = followerService;
            _diaryService = diaryService;
            _accountService = accountService;
        }

        // GET: Home
        public ActionResult Index()
        {

            int userID = (int)Session["userID"];

            List<int> followers = _followerService.GetFollowers(userID).Select(x => x.FromAccountID).ToList();

            MainPageViewModel mainPageViewModel = new MainPageViewModel
            {
                MainPageDatas = _diaryService.GetDiariesByAccount(followers)
            };

            return View(mainPageViewModel);
        }

        public ActionResult _TrendAccounts()
        {
            //List<AccountForTrendPanelDto> trendAccounts = _accountService.GetTrendAccounts().Select(x => new AccountForTrendPanelDto
            //{
            //    AccountID = x.AccountID,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName
            //}).ToList();

            List<AccountForTrendPanelDto> trendAccounts = Mapper.Map<List<AccountForTrendPanelDto>>(_accountService.GetTrendAccounts());

            TrendAccountsViewModel trendAccountsViewModel = new TrendAccountsViewModel
            {
                AccountForTrendPanelDtos = trendAccounts
            };

            return PartialView(trendAccountsViewModel);
        }
    }
}