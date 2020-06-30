using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xpenser.Models;

namespace Xpenser.WebAPI.Repositories
{
    public interface IAccountRepository
    {
        IList<Account> GetAccounts();
        Account GetAccountById(int accountId);
        void SaveAccount(Account account);
        void DeleteAccount(int accountId);
        
    }
}
