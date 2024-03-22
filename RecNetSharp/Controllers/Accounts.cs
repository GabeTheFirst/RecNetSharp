using RecNetSharp.Models.RecNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Controllers
{
    // possibly replace the account class returned with the profile one in the RecNetSharp folder eventually
    // for easier usage
    public class AccountController 
    {
        RecNetClient Client;
        public AccountController(RecNetClient C) 
        {
            Client = C;
        }

        public async Task<Account> GetAccountAsync(string Username)
        {
            return await Client.Get<Account>("accounts/?username=" + Username);
        }

        public async Task<Account> GetAccountAsync(long Id)
        {
            return await Client.Get<Account>("accounts/" + Id);
        }

        public async Task<List<Account>> SearchAccountsAsync(string Username)
        {
            return await Client.Get<List<Account>>("accounts/search?name=" + Username);
        }

        public async Task<Bio> GetBioAsync(long Id)
        {
            return await Client.Get<Bio>("accounts/" + Id + "/bio");
        }

        public async Task<Bio> GetBioAsync(string Username)
        {
            Account A = await GetAccountAsync(Username);
            return await Client.Get<Bio>("accounts/" + A.accountId + "/bio");
        }

        public async Task<List<Account>> GetAccountsAsync(List<long> Ids)
        {
            string Query = RequestTools.CreateQueryArray("id", Ids);
            if(Query.Length < 2048)
                return await Client.Get<List<Account>>("accounts/bulk" + Query);
            else
                return await Client.Post<List<Account>>("accounts/bulk", Query.Trim('?'));
        }
    }
}
