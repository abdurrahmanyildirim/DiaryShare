using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework.Mapping
{
    public class ReviewMapping : EntityTypeConfiguration<Review>
    {
        public ReviewMapping()
        {
            Property(x => x.ReviewDate).HasColumnType("datetime2");
        }
    }
}
