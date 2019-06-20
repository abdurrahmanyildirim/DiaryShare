using DiaryShare.Core.DAL.EntityFramework;
using DiaryShare.DAL.Abstract;
using DiaryShare.DAL.Concrete.EntityFramework.Context;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework
{
    public class EfDiaryDal : EfEntityRepository<EfContext, Diary>, IDiaryDal
    {
        public List<MainPageData> GetDiariesByFollowers(List<int> followers)
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<MainPageData> query = from d in context.Diaries
                                                 join a in context.Accounts
                                                 on d.AccountID equals a.AccountID
                                                 where followers.Contains(d.AccountID) && a.IsActive == true && (d.DiaryStatusID == 1 || d.DiaryStatusID == 3)
                                                 orderby d.CreatedDate descending
                                                 select new MainPageData
                                                 {
                                                     DiaryContent = d.DiaryContent,
                                                     FirstName = a.FirstName,
                                                     LastName = a.LastName,
                                                     CreatedDate = d.CreatedDate

                                                 };
                return query.ToList();
            }
        }
    }
}
