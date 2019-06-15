using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework.Mapping
{
    public class MessageMapping : EntityTypeConfiguration<Message>
    {
        public MessageMapping()
        {
            Property(x => x.SendDate).HasColumnType("datetime2");
        }
    }
}
