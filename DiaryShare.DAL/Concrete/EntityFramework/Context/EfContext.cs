using DiaryShare.DAL.Concrete.EntityFramework.Mapping;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework.Context
{
    public class EfContext : DbContext
    {
        public EfContext() : base("server = . ; database = DiaryShareDb ; uid = sa ; pwd = 123")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<DiaryStatus> DiaryStatuses { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageMap> MessageMaps { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMapping());
            modelBuilder.Configurations.Add(new DiaryMapping());
            modelBuilder.Configurations.Add(new FollowerMapping());
            modelBuilder.Configurations.Add(new MessageMapping());
            modelBuilder.Configurations.Add(new MessageMapMapping());
            modelBuilder.Configurations.Add(new ReviewMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
