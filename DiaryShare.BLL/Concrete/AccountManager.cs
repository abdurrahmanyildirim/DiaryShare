using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryShare.BLL.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDAL;

        public AccountManager(IAccountDal accountDAL)
        {
            _accountDAL = accountDAL;
        }
    }
}
