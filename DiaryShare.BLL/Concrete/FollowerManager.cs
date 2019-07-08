using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.Concrete
{
    public class FollowerManager : IFollowerService
    {
        private IFollowerDal _followerDal;

        public FollowerManager(IFollowerDal followerDal)
        {
            _followerDal = followerDal;
        }

        public void Add(Follower follower)
        {
            _followerDal.Add(follower);
        }

        public void Delete(Follower follower)
        {
            _followerDal.Delete(follower);
        }

        public int GetFollowingCount(int userID)
        {
            return _followerDal.GetAll(x => x.FromAccountID == userID).Count;
        }

        public int GetFollowerCount(int userID)
        {
            return _followerDal.GetAll(x => x.ToAccountID == userID).Count;
        }

        public List<Follower> GetFollowings(int userID)
        {
            return _followerDal.GetAll(x => x.FromAccountID == userID);
        }

        public Follower GetFollower(int fromAccountID, int toAccountID)
        {
            return _followerDal.Get(x => x.FromAccountID == fromAccountID && x.ToAccountID == toAccountID);
        }

        public bool IsFollower(int fromAccount, int toAccount)
        {
            return _followerDal.Get(x => x.FromAccountID == fromAccount && x.ToAccountID == toAccount) != null ? true : false;
        }
    }
}
