using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class Diary : IEntity
    {
        public Diary()
        {
            Reviews = new List<Review>();
        }

        public int DiaryID { get; set; }
        public int AccountID { get; set; }
        public int DiaryStatusID { get; set; }
        public string Title { get; set; }
        public string DiaryContent { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual DiaryStatus DiaryStatus { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
