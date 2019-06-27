using System.Collections.Generic;
using DiaryShare.Entities.Concrete;

namespace DiaryShare.BLL.Abstract
{
    public interface IFollowerService
    {
        List<Follower> GetFollowers(int userID);
        bool IsFollower(int fromAccount, int toAccount);
    }
}