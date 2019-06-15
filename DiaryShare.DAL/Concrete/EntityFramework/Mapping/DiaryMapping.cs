using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework.Mapping
{
    public class DiaryMapping : EntityTypeConfiguration<Diary>
    {
        public DiaryMapping()
        {
            Property(x => x.CreatedDate).HasColumnType("datetime2");
        }
    }
}
