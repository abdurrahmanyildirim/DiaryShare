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


        public List<Follower> GetFollowers(int userID)
        {
            return _followerDal.GetAll(x => x.ToAccountID == userID);
        }

        

        public bool IsFollower(int fromAccount, int toAccount)
        {
            return _followerDal.Get(x => x.FromAccountID == fromAccount && x.ToAccountID == toAccount) != null ? true : false;
        }
    }
}
