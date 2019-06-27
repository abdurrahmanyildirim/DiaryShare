using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.Concrete
{
    public class DiaryManager : IDiaryService
    {
        private IDiaryDal _diaryDAL;

        public DiaryManager(IDiaryDal diaryDal)
        {
            _diaryDAL = diaryDal;
        }

        public void Add(Diary diary)
        {
            _diaryDAL.Add(diary);
        }

        public List<Diary> GetDiariesForProfile(int id)
        {
            return _diaryDAL.GetAll(x => x.AccountID == id);
        }


        public List<MainPageData> GetDiariesByAccount(List<Follower> followers)
        {
            return _diaryDAL.GetDiariesByFollowers(followers).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public DiaryDetailData GetChosenDiary(int id)
        {
            return _diaryDAL.GetDiaryDetail(id);
        }
    }
}
