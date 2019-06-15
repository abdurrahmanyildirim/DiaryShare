using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
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
    }
}
