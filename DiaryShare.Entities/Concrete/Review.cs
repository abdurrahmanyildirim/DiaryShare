using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class Review : IEntity
    {
        public int ReviewID { get; set; }
        public int DiaryID { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual Diary Diary { get; set; }
    }
}
