using DiaryShare.Entities.Concrete;
using System.Collections.Generic;

namespace DiaryShare.BLL.Abstract
{
    public interface IAccountService
    {
        bool UserExists(string email);
        Account Login(string email, string password);
        void Register(Account account, string password);
        List<Account> GetTrendAccounts();
        Account GetAccount(int id);
        void Update(Account account);
        Account GetAccountByEmailWithRole(string email);
        List<Account> GetFollowerAccounts(int id);
        List<Account> GetFollowingAccounts(int id);
        List<Account> GetAccountsBySearchKey(string key);
        List<Account> GetAccountsHasMostFollowers();
        bool ChangePassword(Account account, string password);
    }
}
