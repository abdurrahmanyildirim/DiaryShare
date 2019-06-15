using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework.Mapping
{
    public class MessageMapMapping : EntityTypeConfiguration<MessageMap>
    {
        public MessageMapMapping()
        {

            HasRequired(x => x.FromAccount).WithMany(x => x.FromMessageMaps).HasForeignKey(x => x.FromAccountID).WillCascadeOnDelete(false);
            HasRequired(x => x.ToAccount).WithMany(x => x.ToMessageMaps).HasForeignKey(x => x.ToAccountID).WillCascadeOnDelete(false);
        }           
    }
}
