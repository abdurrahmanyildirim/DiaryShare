using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
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
    }
}
