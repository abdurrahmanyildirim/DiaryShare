using DiaryShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.Entities.Concrete
{
    public class Role : IEntity
    {
        public Role()
        {
            Accounts = new List<Account>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}
