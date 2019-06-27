using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System.Collections.Generic;

namespace DiaryShare.BLL.Abstract
{
    public interface IDiaryService
    {
        List<MainPageData> GetDiariesByAccount(List<Follower> followers);
        DiaryDetailData GetChosenDiary(int id);
        List<Diary> GetDiariesForProfile(int id);
        void Add(Diary diary);
    }
}