﻿using AutoMapper;
using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using DiaryShare.MVCWebUI.Helpers;
using DiaryShare.MVCWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IReviewService _reviewService;

        public HomeController(IFollowerService followerService,
            IDiaryService diaryService,
            IAccountService accountService,
            IReviewService reviewService
            )
        {
            _followerService = followerService;
            _diaryService = diaryService;
            _accountService = accountService;
            _reviewService = reviewService;
        }

        public ActionResult Index()
        {
            int userID = (int)Session["userID"];

            List<Follower> followings = _followerService.GetFollowings(userID).ToList();

            MainPageViewModel mainPageViewModel = new MainPageViewModel
            {
                MainPageDatas = _diaryService.GetDiariesByAccount(followings)
            };

            return View(mainPageViewModel);
        }

        public ActionResult _TrendAccounts()
        {
            return PartialView(new TrendAccountsViewModel { AccountForTrendPanelDtos = Mapper.Map<List<AccountForTrendPanelDto>>(_accountService.GetTrendAccounts()) });
        }

        public ActionResult DiaryDetail(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("Index");

            DiaryForDetailDto diaryForDetailDto = Mapper.Map<DiaryForDetailDto>(_diaryService.GetChosenDiary(id));

            DiaryDetailViewModel diaryDetailViewModel = new DiaryDetailViewModel
            {
                Diary = diaryForDetailDto,
                Reviews = GetReviews(id)
            };

            return View(diaryDetailViewModel);
        }

        [HttpPost]
        public JsonResult RequestToReview(Review review)
        {
            review.FromAccount = (int)Session["userID"];
            review.ReviewDate = DateTime.Now;
            _reviewService.Add(review);

            return Json(GetReviews(review.DiaryID), JsonRequestBehavior.AllowGet);
        }

        //Veri tabanındaki hatalı kurgulamadan dolayı aşağıdaki kötü kod yazılmıştır. Allah Affetsin :)
        private List<ReviewsForDiariesDto> GetReviews(int id)
        {
            List<Review> reviews = _reviewService.ReviewsByDiary(id).OrderBy(x => x.ReviewDate).ToList();
            List<ReviewsForDiariesDto> reviewsForDiariesDto = new List<ReviewsForDiariesDto>();
            foreach (var item in reviews)
            {
                Account account = _accountService.GetAccount(item.FromAccount);
                ReviewsForDiariesDto addReviews = new ReviewsForDiariesDto
                {
                    AccountID = item.FromAccount,
                    Description = item.Description,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    ReviewDate = item.ReviewDate,
                    ProfilPhotoPath = account.ProfilPhotoPath
                };
                reviewsForDiariesDto.Add(addReviews);
            }

            return reviewsForDiariesDto;
        }
    }
}