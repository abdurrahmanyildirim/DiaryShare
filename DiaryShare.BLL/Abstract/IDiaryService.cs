using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System.Collections.Generic;

namespace DiaryShare.BLL.Abstract
{
    public interface IDiaryService
    {
        List<MainPageData> GetDiariesByAccount(List<Follower> followers);
        DiaryDetailData GetChosenDiary(int id);
        List<Diary> GetDiariesForOwnAccount(int id);
        List<Diary> GetDiariesForPublic(int id);
        List<Diary> GetDiariesForFollower(int id);
        void Add(Diary diary);
        List<MainPageData> GetHasMostReviewDiaries();
    }
}