using DiaryShare.Core.DAL.EntityFramework;
using DiaryShare.DAL.Abstract;
using DiaryShare.DAL.Concrete.EntityFramework.Context;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.DAL.Concrete.EntityFramework
{
    public class EfAccountDal : EfEntityRepository<EfContext, Account>, IAccountDal
    {
        public List<Account> GetTopAccounts()
        {
            using (EfContext efContext = new EfContext())
            {
                IQueryable<Account> accounts = efContext.Accounts.OrderByDescending(x => x.Diaries.Count).Take(10);
                return accounts.ToList();
            }
        }

        public Account GetAccountByEmailWithRole(string email)
        {
            using (EfContext context = new EfContext())
            {
                return context.Accounts.Include("Role").FirstOrDefault(x => x.Email == email);
            }
        }

        public List<Account> GetFollowerAccounts(int id)
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<Account> accounts = from a in context.Accounts
                                               join f in context.Followers
                                               on a.AccountID equals f.FromAccountID
                                               where f.ToAccountID == id
                                               select a;
                return accounts.ToList();
            }
        }

        public List<Account> GetFollowingAccounts(int id)
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<Account> accounts = from a in context.Accounts
                                               join f in context.Followers
                                               on a.AccountID equals f.ToAccountID
                                               where f.FromAccountID == id
                                               select a;
                return accounts.ToList();
            }
        }

        public List<Account> GetAccountsHasMostFollowers()
        {
            using (EfContext context = new EfContext())
            {
                IQueryable<Account> accounts = (from a in context.Accounts
                                                orderby a.ToFollowers.Count descending
                                                select a).Take(10);
                return accounts.ToList();
            }
        }
    }
}
