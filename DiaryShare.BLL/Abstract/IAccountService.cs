using DiaryShare.DAL.Abstract;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.Abstract
{
    public interface IAccountService
    {
        bool UserExists(string email);
        Account Login(string email, string password);
        void Register(Account account, string password);
        List<Account> GetTrendAccounts();
        Account GetAccount(int id);
    }
}
