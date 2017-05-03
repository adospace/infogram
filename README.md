# infogr.am .NET Client
This an implementation of infogr.am .REST Api (https://developers.infogr.am/rest/). I've migrated portion of code from official Java sdk (https://github.com/infogram/infogram-java).

Sample code:

```c#
var client = new infogram_net.InfogramClient(Constants.API_KEY, Constants.API_SECRET);
var infographics = await client.GetInfographicsAsync();
```
