using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xpenser.Models;
using Xpenser.WebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Xpenser.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        // GET: api/<AccountsController>
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public AccountsController(IAccountRepository accountRepository,IConfiguration configuration, ILogger<AccountsController> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _accountRepository.GetAccounts();
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _accountRepository.GetAccountById(id);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            _accountRepository.SaveAccount(account);
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Account account)
        {
            _accountRepository.SaveAccount(account);
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _accountRepository.DeleteAccount(id);
        }
    }
}
