using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class Follower : IEntity
    {
        public int FollowerID { get; set; }
        [ForeignKey("FromAccount")]
        public int FromAccountID { get; set; }
        [ForeignKey("ToAccount")]
        public int ToAccountID { get; set; }
        public DateTime FollowDate { get; set; }

        public virtual Account FromAccount { get; set; }
        public virtual Account ToAccount { get; set; }
    }
}
