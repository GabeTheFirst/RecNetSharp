# RecNetSharp!
## A c# library for easily accessing data from RecRoom
### (This is currently still very incomplete, it's not done yet and will be improved or changed in the future!)

Using RecNetSharp is easy!

To use it, you must first be ```using RecNetSharp;```, then create an instance of RecNetClient.


example:
```cs

RecNetClient Client = new RecNetClient();

```

before you can do much though, most of RecRoom's public APIs require a Key to be accessible, you should specify yours in the RecNetClient constructor.

for example:
```cs

RecNetClient Client = new RecNetClient("Key");

```
if you provide a key, your requests will be authorized with that key.

There are multiple "Controllers" you can use to access different parts of the rec.net api
(controllers may be a bad name, but I have caught the asp.net curse)

if you want to get account info, use the ```Accounts``` controller in your client, you can do the same for ```Images``` or ```Rooms```

you may want to be ```using RecNetSharp.Models.RecNet``` for access to the models

here's an example of how they work:

```cs

  async void CreateClient(string Key)
  {
    RecNetClient Client = new RecNetClient(Key);

    // (for functions where you specify Username, you could also specify Id, same the otherway around as long as it's account id)

    Account CoachYEAH = await Client.Accounts.GetAccountAsync("Coach");

    List<Room> CoachRooms = await Client.Rooms.GetRoomsByCreatorAsync("Coach");

    List<Image> CoachImages = await Client.Images.GetImagesFromPlayerAsync("Coach");
  }

```

There are many things you can do (with more coming soon!)
## Rooms
### functions within rooms controller used to get data for rooms (all async!)
```List<Room> GetRoomsByCreatorAsync(long AccountId)``` 

```List<Room> GetRoomsByCreatorAsync(string Username)```

```List<Room> GetRoomsOwnedByCreatorAsync(long AccountId)```

```List<Room> GetRoomsOwnedByCreatorAsync(string Username)```

## Accounts
### functions within accounts controller used to get data for accounts (all async!)
```Account GetAccountAsync(string Username)```

```Account GetAccountAsync(long Id)```

```Bio GetBioAsync(long Id)```

```Bio GetBioAsync(string Username)```

// this one's basically accounts bulk

```List<Account> GetAccountsAsync(long[] Ids)```


## Images
### functions within images controller used to get data for images (all async!)
```List<Image> GetImagesFromPlayerAsync(long PlayerId)```

```List<Image> GetImagesFromPlayerAsync(long PlayerId, int Skip, int Take)```

```List<Image> GetImagesFromPlayerAsync(string Username)```

```List<Image> GetImagesFromPlayerAsync(string Username, int Skip, int Take)```

```List<Image> GetImagesFromRoomAsync(long RoomId)```

```List<Image> GetImagesFromRoomAsync(long RoomId, int Skip, int Take)```

```List<Image> GetImagesFromEventAsync(long EventId)```

```List<Image> GetImagesFromEventAsync(long EventId, int Skip, int Take)```

```List<ImageComment> GetImageCommentsAsync(long ImageId)```

```List<Account> GetImageCheerersAsync(long ImageId)```

```List<long> GetRawImageCheerersAsync(long ImageId)```
