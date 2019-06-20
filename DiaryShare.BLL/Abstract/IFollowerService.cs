using System.Collections.Generic;
using DiaryShare.Entities.Concrete;

namespace DiaryShare.BLL.Abstract
{
    public interface IFollowerService
    {
        List<Diary> GetDiariesByAccount(int userID);
        List<Follower> GetFollowers(int userID);
    }
}