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
    }
}
