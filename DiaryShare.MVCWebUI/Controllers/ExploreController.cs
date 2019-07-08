using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
    public class ExploreController : Controller
    {

        readonly private IAccountService _accountService;

        public ExploreController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Search(string key)
        {
            List<AccountForFollowerListDto> accounts = Mapper.Map<List<AccountForFollowerListDto>>(_accountService.GetAccountsBySearchKey(key));

            SearchViewModel searchViewModel = new SearchViewModel
            {
                Accounts = accounts
            };
            return View(searchViewModel);
        }
    }
}