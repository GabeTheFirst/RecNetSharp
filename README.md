# RecNetSharp!
## A c# library for easily accessing data from RecRoom
### (This is currently still very incomplete, it's not done yet and will be improved or changed in the future!)

Using RecNetSharp is easy!

To use it, you must first be ```using RecNetSharp;```, then create an instance of RecNetClient.


example:
```cs

  async void CreateClient()
  {
    RecNetClient Client = new RecNetClient();
  }

```

before you can do much though, most of RecRoom's public APIs require a Key to be accessible, you should specify yours in the RecNetClient constructor.

for example:
```cs

  async void CreateClient(string Key)
  {
    RecNetClient Client = new RecNetClient(Key);
  }

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


