using RecNetSharp.Models.RecNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Controllers
{
    public class ImagesController
    {
        RecNetClient Client;
        public ImagesController(RecNetClient C)
        {
            Client = C;
        }

        public async Task<List<Image>> GetImagesFromPlayerAsync(long PlayerId)
        {
            return await Client.Get<List<Image>>("images/player/" + PlayerId);
        }

        public async Task<List<Image>> GetImagesFromPlayerAsync(long PlayerId, int Skip, int Take)
        {
            return await Client.Get<List<Image>>("images/player/" + PlayerId + "?skip=" + Skip + "&take=" + Take);
        }

        public async Task<List<Image>> GetImagesFromPlayerAsync(string Username)
        {
            Account A = await Client.Accounts.GetAccountAsync(Username);
            return await Client.Get<List<Image>>("images/player/" + A.accountId);
        }

        public async Task<List<Image>> GetImagesFromPlayerAsync(string Username, int Skip, int Take)
        {
            Account A = await Client.Accounts.GetAccountAsync(Username);
            return await Client.Get<List<Image>>("images/player/" + A.accountId + "?skip=" + Skip + "&take=" + Take);
        }

        public async Task<List<Image>> GetImagesFromRoomAsync(long RoomId)
        {
            return await Client.Get<List<Image>>("images/room/" + RoomId);
        }

        public async Task<List<Image>> GetImagesFromRoomAsync(long RoomId, int Skip, int Take)
        {
            return await Client.Get<List<Image>>("images/room/" + RoomId + "?skip=" + Skip + "&take=" + Take);
        }

        public async Task<List<Image>> GetImagesFromEventAsync(long EventId)
        {
            return await Client.Get<List<Image>>("images/playerevent/" + EventId);
        }

        public async Task<List<Image>> GetImagesFromEventAsync(long EventId, int Skip, int Take)
        {
            return await Client.Get<List<Image>>("images/playerevent/" + EventId + "?skip=" + Skip + "&take=" + Take);
        }

        public async Task<List<ImageComment>> GetImageCommentsAsync(long ImageId)
        {
            return await Client.Get<List<ImageComment>>("images/" + ImageId + "/comments");
        }

        public async Task<List<Account>> GetImageCheerersAsync(long ImageId)
        {
            long[] AccountIds = await Client.Get<long[]>("images/" + ImageId + "/cheers");
            return await Client.Accounts.GetAccountsAsync(AccountIds);
        }

        public async Task<List<long>> GetRawImageCheerersAsync(long ImageId)
        {
            return await Client.Get<List<long>>("images/" + ImageId + "/cheers");
        }
    }
}
