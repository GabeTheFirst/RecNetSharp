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
        // the instance of RecNetClient this controller instance will use
        RecNetClient Client;

        // set up the controller
        public RoomsController(RecNetClient C)
        {
            // store a reference of the RecNetClient
            Client = C;
        }

        // get the list of rooms by a creator's account id
        public async Task<List<Room>> GetRoomsByCreatorAsync(long AccountId)
        {
            // get the result from RecNet
            return await Client.Get<List<Room>>("rooms/createdby/" + AccountId);
        }

        // get the list of rooms by a creator's account username
        public async Task<List<Room>> GetRoomsByCreatorAsync(string Username)
        {
            // get account by the username 
            Account A = await Client.Accounts.GetAccountAsync(Username);
            // get rooms by the creator's id
            return await GetRoomsByCreatorAsync(A.accountId);
        }

        // get the list of rooms by owned a creator's account id
        public async Task<List<Room>> GetRoomsOwnedByCreatorAsync(long AccountId)
        {
            // get the result from RecNet
            return await Client.Get<List<Room>>("rooms/ownedby/" + AccountId);
        }

        // get the list of rooms by owned a creator's account username
        public async Task<List<Room>> GetRoomsOwnedByCreatorAsync(string Username)
        {
            // get account by the username 
            Account A = await Client.Accounts.GetAccountAsync(Username);
            // get rooms owned by the creator's id
            return await GetRoomsOwnedByCreatorAsync(A.accountId);
        }

        // search for rooms by name
        public async Task<List<Room>> SearchRoomsAsync(string Name)
        {
            return await Client.Get<List<Room>>("rooms/search?query=" + Name);
        }

        // get room by name
        public async Task<Room?> GetRoomByNameAsync(string Name)
        {
            // if you search rooms starting with "^" then it should return the room with that name
            List<Room> Result = await SearchRoomsAsync("^" + Name);
            // find it by name in the results just in case :fire: (could be changed to Result[0])
            return Result.FirstOrDefault(A => A.Name == Name);
        }

        // get room by id
        public async Task<Room?> GetRoomAsync(long RoomId)
        {
            // get the room
            Room? Result = await Client.Get<Room?>("rooms/" + RoomId);
            // return the result
            return Result;
        }
    }
}
