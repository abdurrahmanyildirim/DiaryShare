using DiaryShare.Core.DAL;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        List<Account> GetTopAccounts();
        Account GetAccountByEmailWithRole(string email);
        List<Account> GetFollowerAccounts(int id);
        List<Account> GetFollowingAccounts(int id);
        List<Account> GetAccountsHasMostFollowers();
    }
}
