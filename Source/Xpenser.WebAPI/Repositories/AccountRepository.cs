
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data;
using System.Linq;
using System.Threading.Tasks;
using Xpenser.Models;
using MySql.Data.MySqlClient;

namespace Xpenser.WebAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public AccountRepository(ILogger<AccountRepository> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }



        public Account GetAccountById(int accountId)
        {
            Account account;
            using (IDbConnection con = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
               account=  con.Get<Account>(accountId);
            }
            return account;
        }

        public IList<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (IDbConnection con = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                accounts = con.GetAll<Account>().ToList();

            }

            return accounts;
        }

        public void SaveAccount(Account account)
        {
            
            using (IDbConnection con = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                if (account.AccountId == 0)
                {
                    con.Insert<Account>(account);
                }
                else
                {
                    con.Update<Account>(account);
                }
               
            }

           
        }
        public void DeleteAccount(int accountId)
        {
            using (IDbConnection con = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                var account = GetAccountById(accountId);
                con.Delete<Account>(account);

            }

        }
    }
}
