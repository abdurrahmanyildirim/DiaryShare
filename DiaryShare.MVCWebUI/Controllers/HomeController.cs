using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
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

        public HomeController(IFollowerService followerService,
            IDiaryService diaryService
            )
        {
            _followerService = followerService;
            _diaryService = diaryService;
        }

        // GET: Home
        public ActionResult Index()
        {

            int userID = (int)Session["userID"];

            List<int> followers = _followerService.GetFollowers(userID).Select(x=>x.FromAccountID).ToList();

            MainPageViewModel mainPageViewModel = new MainPageViewModel
            {
                MainPageDatas=_diaryService.GetDiariesByAccount(followers)
            };

            return View(mainPageViewModel);
        }
    }
}