using System.Collections.Generic;
using DiaryShare.Entities.Concrete;

namespace DiaryShare.BLL.Abstract
{
    public interface IFollowerService
    {
        List<Follower> GetFollowings(int userID);
        //List<Follower> GetFollowers(int userID);
        bool IsFollower(int fromAccount, int toAccount);
        Follower GetFollower(int fromAccountID, int toAccountID);
        void Delete(Follower follower);
        void Add(Follower follower);
        int GetFollowerCount(int userID);
        int GetFollowingCount(int userID);
    }
}