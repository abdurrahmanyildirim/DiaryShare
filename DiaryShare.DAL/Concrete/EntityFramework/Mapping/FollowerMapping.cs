using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework.Mapping
{
    public class FollowerMapping : EntityTypeConfiguration<Follower>
    {
        public FollowerMapping()
        {
            Property(x => x.FollowDate).HasColumnType("datetime2");


            HasRequired(x => x.FromAccount).WithMany(x => x.FromFollowers).HasForeignKey(x => x.FromAccountID).WillCascadeOnDelete(false);
            HasRequired(x => x.ToAccount).WithMany(x => x.ToFollowers).HasForeignKey(x => x.ToAccountID).WillCascadeOnDelete(false);
        }
    }
}
