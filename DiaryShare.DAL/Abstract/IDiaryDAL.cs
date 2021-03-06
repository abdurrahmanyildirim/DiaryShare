﻿using DiaryShare.Core.DAL;
using DiaryShare.Entities.ComplexTypes;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Abstract
{
    public interface IDiaryDal : IEntityRepository<Diary>
    {
        List<MainPageData> GetDiariesByFollowers(List<Follower> followers);
        DiaryDetailData GetDiaryDetail(int id);
        List<MainPageData> GetHasMostReviewDiaries();
    }
}
