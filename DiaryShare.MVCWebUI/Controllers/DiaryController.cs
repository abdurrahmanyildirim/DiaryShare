using DiaryShare.BLL.Abstract;
using DiaryShare.Entities.Concrete;
using DiaryShare.MVCWebUI.Dtos;
using System;
using System.Web.Mvc;

namespace DiaryShare.MVCWebUI.Controllers
{
    [Authorize(Roles ="Admin,Client")]
    public class DiaryController : Controller
    {
        private readonly IDiaryService _diaryService;

        public DiaryController(IDiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        public ActionResult DiaryPage()
        {
            return View(new DiaryForInsertDto());
        }

        [HttpPost]
        public ActionResult DiaryPage(FormCollection diaryContent)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Info = string.Format("Bir hata meydana geldi.");
                return View();
            }

            Diary diary = new Diary
            {
                AccountID = (int)Session["userID"],
                CreatedDate = DateTime.Now,
                DiaryContent = diaryContent[1],
                Title = diaryContent[0],
                DiaryStatusID = int.Parse(diaryContent[2])
            };

            _diaryService.Add(diary);

            ViewBag.Info = string.Format($"{diary.Title} isimli günlük başarıyla kaydedildi.");

            return View();
        }

    }
}