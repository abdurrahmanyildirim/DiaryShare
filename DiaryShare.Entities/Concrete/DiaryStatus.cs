using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class DiaryStatus : IEntity
    {
        public DiaryStatus()
        {
            Diaries = new List<Diary>();
        }

        public int DiaryStatusID { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Diary> Diaries { get; set; }
    }
}
