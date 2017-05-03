using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var client = new infogram_net.InfogramClient(Constants.API_KEY, Constants.API_SECRET);

            //var res = client.GetAsync("infographics").Result;
            //var res = client.GetInfographicAsync(Guid.Parse("9f200d38-8803-4153-829a-c827b432de9e")).Result;
            //client.UpdateInfographicAsync(Guid.Parse("9f200d38-8803-4153-829a-c827b432de9e"), 178, title: "new title").Wait();

            client.DeleteInfographic(Guid.Parse("9f200d38-8803-4153-829a-c827b432de9e")).Wait();


            Console.WriteLine();
        }
    }
}
