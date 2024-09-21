using RecNetSharp.Models.RecNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Controllers
{
    public class ImagesController
    {
        // the instance of RecNetClient this controller instance will use
        RecNetClient Client;

        // set up the controller
        public ImagesController(RecNetClient C)
        {
            // store a reference of the RecNetClient
            Client = C;
        }

        // get the images from a player by id
        public async Task<List<Image>> GetImagesFromPlayerAsync(long PlayerId)
        {
            // return the result from the request
            return await Client.Get<List<Image>>("images/player/" + PlayerId);
        }

        // get the images from a player by id with skip and take values to get the desired amount
        public async Task<List<Image>> GetImagesFromPlayerAsync(long PlayerId, int Skip, int Take)
        {
            // return the result from the request
            return await Client.Get<List<Image>>("images/player/" + PlayerId + "?skip=" + Skip + "&take=" + Take);
        }

        // get the images from a player by username
        public async Task<List<Image>> GetImagesFromPlayerAsync(string Username)
        {
            // get the account associated with the username
            Account A = await Client.Accounts.GetAccountAsync(Username);
            // get that player's images using the id of the account we got
            return await GetImagesFromPlayerAsync(A.accountId);
        }

        // get the images from a player by username with skip and take values to get the desired amount
        public async Task<List<Image>> GetImagesFromPlayerAsync(string Username, int Skip, int Take)
        {
            // get the account associated with the username
            Account A = await Client.Accounts.GetAccountAsync(Username);
            // get that player's images using the id of the account we got, using Skip and Take too this time :fire:
            return await GetImagesFromPlayerAsync(A.accountId, Skip, Take);
        }

        // get the images from a room by the room's id
        public async Task<List<Image>> GetImagesFromRoomAsync(long RoomId)
        {
            // return the result from the request
            return await Client.Get<List<Image>>("images/room/" + RoomId);
        }

        // get the images from a room by the room's id with skip and take values to get the desired amount
        public async Task<List<Image>> GetImagesFromRoomAsync(long RoomId, int Skip, int Take)
        {
            // return the result from the request
            return await Client.Get<List<Image>>("images/room/" + RoomId + "?skip=" + Skip + "&take=" + Take);
        }

        // get the images from an event by the event's id
        public async Task<List<Image>> GetImagesFromEventAsync(long EventId)
        {
            // return the result from the request
            return await Client.Get<List<Image>>("images/playerevent/" + EventId);
        }

        // get the images from an event by the event's id with skip and take values to get the desired amount
        public async Task<List<Image>> GetImagesFromEventAsync(long EventId, int Skip, int Take)
        {
            // return the result from the request
            return await Client.Get<List<Image>>("images/playerevent/" + EventId + "?skip=" + Skip + "&take=" + Take);
        }

        // get comments on an image by the image's id
        public async Task<List<ImageComment>> GetImageCommentsAsync(long ImageId)
        {
            // return the result from the request
            return await Client.Get<List<ImageComment>>("images/" + ImageId + "/comments");
        }

        // get accounts cheering an image by the image's id
        public async Task<List<Account>> GetImageCheerersAsync(long ImageId)
        {
            // get the list of accounts ids cheering the image from rec.net
            List<long> AccountIds = await Client.Get<List<long>>("images/" + ImageId + "/cheers");
            // get the accounts of those ids
            return await Client.Accounts.GetAccountsAsync(AccountIds);
        }

        // get an image by id
        public async Task<Image> GetImageAsync(long ImageId)
        {
            // return the result from the request
            return await Client.Get<Image>("images/" + ImageId);
        }

        // get bulk images by id
        public async Task<List<Image>> GetImagesAsync(List<long> ImageIds)
        {
            string FormData = RequestTools.CreateQueryArray("ids", ImageIds);
            // return the result from the request
            return await Client.Post<List<Image>>("images/bulk/id", FormData.Trim('?'));
        }

        // get the ids of players cheering an image
        public async Task<List<long>> GetRawImageCheerersAsync(long ImageId)
        {
            // get ids of cheerers from RecNet
            return await Client.Get<List<long>>("images/" + ImageId + "/cheers");
        }
    }
}
