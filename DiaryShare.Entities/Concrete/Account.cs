using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class Account : IEntity
    {
        public Account()
        {
            Diaries = new List<Diary>();
            FromFollowers = new List<Follower>();
            ToFollowers = new List<Follower>();
            FromMessageMaps = new List<MessageMap>();
            ToMessageMaps = new List<MessageMap>();
        }

        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime MemberDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }
        public virtual List<Diary> Diaries { get; set; }
        public virtual List<Follower> FromFollowers { get; set; }
        public virtual List<Follower> ToFollowers { get; set; }
        public virtual List<MessageMap> FromMessageMaps { get; set; }
        public virtual List<MessageMap> ToMessageMaps { get; set; }
    }
}
