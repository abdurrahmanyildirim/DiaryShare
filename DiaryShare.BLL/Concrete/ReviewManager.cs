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
    public class ReviewManager : IReviewService
    {
        private IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public List<Review> ReviewsByDiary(int id)
        {
            return _reviewDal.GetAll(x => x.DiaryID == id);

        }

        public void Add(Review review)
        {
            _reviewDal.Add(review);
        }
    }
}
