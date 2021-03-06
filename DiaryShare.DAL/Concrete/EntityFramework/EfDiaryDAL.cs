﻿using DiaryShare.Core.DAL.EntityFramework;
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
        public List<MainPageData> GetDiariesByFollowers(List<Follower> followers)
        {
            using (EfContext context = new EfContext())
            {
                try
                {
                    List<int> fromFollow = followers.Select(x => x.ToAccountID).ToList();
                    int userID = followers[0].FromAccountID;
                    IQueryable<MainPageData> query = from d in context.Diaries
                                                     join a in context.Accounts
                                                     on d.AccountID equals a.AccountID
                                                     where (fromFollow.Contains(d.AccountID) || d.AccountID == userID) && a.IsActive == true && (d.DiaryStatusID == 1 || d.DiaryStatusID == 3)
                                                     select new MainPageData
                                                     {
                                                         DiaryContent = d.DiaryContent,
                                                         FirstName = a.FirstName,
                                                         LastName = a.LastName,
                                                         CreatedDate = d.CreatedDate,
                                                         DiaryID = d.DiaryID,
                                                         AccountID = a.AccountID,
                                                         ProfilPhotoPath = a.ProfilPhotoPath,
                                                         Title = d.Title
                                                     };
                    return query.ToList();
                }
                catch
                {
                    return new List<MainPageData>();
                }

            }
        }

        public DiaryDetailData GetDiaryDetail(int id)
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<DiaryDetailData> diaryDetailData = from d in context.Diaries
                                                              join a in context.Accounts
                                                              on d.AccountID equals a.AccountID
                                                              where id == d.DiaryID
                                                              select new DiaryDetailData
                                                              {
                                                                  DiaryContent = d.DiaryContent,
                                                                  DiaryID = d.DiaryID,
                                                                  AccountID = a.AccountID,
                                                                  CreatedDate = d.CreatedDate,
                                                                  FirstName = a.FirstName,
                                                                  LastName = a.LastName,
                                                                  ProfilPhotoPath = a.ProfilPhotoPath,
                                                                  Title = d.Title
                                                              };
                return diaryDetailData.ToList()[0];
            }
        }

        public List<MainPageData> GetHasMostReviewDiaries()
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<MainPageData> diaries = (from d in context.Diaries
                                                    join a in context.Accounts
                                                    on d.AccountID equals a.AccountID
                                                    where d.DiaryStatus.StatusName == "Public"
                                                    orderby d.Reviews.Count descending
                                                    select new MainPageData
                                                    {
                                                        DiaryContent = d.DiaryContent,
                                                        FirstName = a.FirstName,
                                                        LastName = a.LastName,
                                                        CreatedDate = d.CreatedDate,
                                                        DiaryID = d.DiaryID,
                                                        AccountID = a.AccountID,
                                                        ProfilPhotoPath = a.ProfilPhotoPath,
                                                        Title = d.Title
                                                    }).Take(10);
                return diaries.ToList();
            }
        }
    }
}
