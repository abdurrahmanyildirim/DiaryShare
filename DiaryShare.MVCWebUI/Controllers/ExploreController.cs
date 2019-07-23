using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
    [Authorize(Roles = "Admin,Client")]
    public class ExploreController : Controller
    {
        readonly private IAccountService _accountService;
        readonly private IDiaryService _diaryService;

        public ExploreController(IAccountService accountService,
            IDiaryService diaryService)
        {
            _accountService = accountService;
            _diaryService = diaryService;
        }

        public ActionResult Search(string key)
        {
            SearchViewModel searchViewModel = new SearchViewModel
            {
                Accounts = Mapper.Map<List<AccountForFollowerListDto>>(_accountService.GetAccountsBySearchKey(key.Trim()))
            };
            return View(searchViewModel);
        }

        public ActionResult Bests()
        {
            BestPageViewModel bestPageViewModel = new BestPageViewModel
            {
                MostActiveAccounts = Mapper.Map<List<AccountForFollowerListDto>>(_accountService.GetTrendAccounts()),
                HasMostFollowerAccounts = Mapper.Map<List<AccountForFollowerListDto>>(_accountService.GetAccountsHasMostFollowers()),
                HasMostReviewDiaries =Mapper.Map<List<MainPageData>>(_diaryService.GetHasMostReviewDiaries())
            };

            return View(bestPageViewModel);
        }
    }
}