using DiaryShare.BLL.Abstract;
using DiaryShare.DAL.Abstract;
using DiaryShare.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DiaryShare.BLL.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDAL;

        public AccountManager(IAccountDal accountDAL)
        {
            _accountDAL = accountDAL;
        }

        public Account GetAccountByEmailWithRole(string email)
        {
            return _accountDAL.GetAccountByEmailWithRole(email);
        }

        public void Update(Account account)
        {
            _accountDAL.Update(account);
        }

        public Account GetAccount(int id)
        {
            return _accountDAL.Get(x => x.AccountID == id);
        }

        public List<Account> GetTrendAccounts()
        {
            return _accountDAL.GetTopAccounts().ToList();
        }

        public void Register(Account account, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            _accountDAL.Add(account);

        }

        public Account Login(string email, string password)
        {
            var account = _accountDAL.Get(x => x.Email == email);
            if (account == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return null;
            }

            return account;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public bool UserExists(string email)
        {
            if (_accountDAL.Get(x => x.Email == email) != null)
            {
                return true;
            }
            return false;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
