using DiaryShare.Entities.Concrete;
using System.Collections.Generic;

namespace DiaryShare.BLL.Abstract
{
    public interface IReviewService
    {
        List<Review> ReviewsByDiary(int id);
        void Add(Review review);
    }
}