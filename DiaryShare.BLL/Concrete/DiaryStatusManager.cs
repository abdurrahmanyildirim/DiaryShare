using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.Concrete
{
    public class DiaryStatusManager : IDiaryStatusService
    {
        private IDiaryStatusDal _diaryStatusDal;

        public DiaryStatusManager(IDiaryStatusDal diaryStatusDal )
        {
            _diaryStatusDal = diaryStatusDal;
        }
    }
}
