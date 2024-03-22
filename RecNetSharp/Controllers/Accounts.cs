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
        // the instance of RecNetClient this controller instance will use
        RecNetClient Client;

        // set up the controller
        public AccountController(RecNetClient C) 
        {
            // store a reference to the RecNetClient
            Client = C;
        }

        // get an account by username
        public async Task<Account> GetAccountAsync(string Username)
        {
            // get account by username from the rec room api
            return await Client.Get<Account>("accounts/?username=" + Username);
        }

        // get an account by id
        public async Task<Account> GetAccountAsync(long Id)
        {
            // get account by id from the rec room api
            return await Client.Get<Account>("accounts/" + Id);
        }

        // search for accounts by name
        public async Task<List<Account>> SearchAccountsAsync(string Username)
        {
            // searches for accounts from the rec room api
            return await Client.Get<List<Account>>("accounts/search?name=" + Username);
        }

        // get account's bio by id
        public async Task<Bio> GetBioAsync(long Id)
        {
            // get account bio by someone's id
            return await Client.Get<Bio>("accounts/" + Id + "/bio");
        }

        // get account's bio by username
        public async Task<Bio> GetBioAsync(string Username)
        {
            // get the account this username is for
            Account A = await GetAccountAsync(Username);
            // then get the bio by that account's id
            return await GetBioAsync(A.accountId);
        }

        // get accounts bulk
        public async Task<List<Account>> GetAccountsAsync(List<long> Ids)
        {
            // convert the longs into a Query string (such as '?id=1&id=2')
            string Query = RequestTools.CreateQueryArray("id", Ids);

            // check the length to see if it should be post or get
            if(Query.Length < 2048)
            {
                // gets the accounts as a get request, using the Query
                return await Client.Get<List<Account>>("accounts/bulk" + Query);
            }
            else
            {
                /*
                   this gets accounts bulk as POST, and trim the ? from the query as content so RecNet doesn't ignore it
                   form data could be used here (that's what it really is) but it's easier to just send the modified
                   query string, since it's the same end product
                */
                return await Client.Post<List<Account>>("accounts/bulk", Query.Trim('?'));
            }
        }
    }
}
