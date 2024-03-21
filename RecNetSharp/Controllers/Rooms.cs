using RecNetSharp.Models.RecNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Controllers
{
    public class RoomsController
    {
        RecNetClient Client;
        public RoomsController(RecNetClient C)
        {
            Client = C;
        }

        public async Task<List<Room>> GetRoomsByCreatorAsync(long AccountId)
        {
            return await Client.Get<List<Room>>("rooms/createdby/" + AccountId);
        }

        public async Task<List<Room>> GetRoomsByCreatorAsync(string Username)
        {
            Account A = await Client.Accounts.GetAccountAsync(Username);
            return await GetRoomsByCreatorAsync(A.accountId);
        }

        public async Task<List<Room>> GetRoomsOwnedByCreatorAsync(long AccountId)
        {
            return await Client.Get<List<Room>>("rooms/ownedby/" + AccountId);
        }

        public async Task<List<Room>> GetRoomsOwnedByCreatorAsync(string Username)
        {
            Account A = await Client.Accounts.GetAccountAsync(Username);
            return await GetRoomsOwnedByCreatorAsync(A.accountId);
        }
    }
}
