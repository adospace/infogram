using infogram_net.Elements;
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
            //var res = client.GetInfographicAsync(Guid.Parse("65cb516b-ad61-461f-86f7-e991e00f1cfd")).Result;

            client.UpdateInfographicAsync(Guid.Parse("65cb516b-ad61-461f-86f7-e991e00f1cfd"), 178, new Element[]
            {
                new H1() { Text = "My H1 Title" },
                new Chart() { ChartType = ChartType.pie, Data = new object[]
                {
                    new object[]
                    {
                        new object[] { "sheet 1", "today", "yesterday", "d. bef. yesterday" },
                        new object[] { "John", 4, 6, 7 },
                        new object[] { "Peter", 1, 3, 9 },
                        new object[] { "George", 4, 4, 3 },
                    },
                    new object[]
                    {
                        new object[] { "sheet 2", "today 3", "yesterday", "d. bef. yesterday" },
                        new object[] { "John", 5, 4, 7 },
                        new object[] { "Peter", 3, 5, 9 },
                        new object[] { "George", 7, 6, 3 },
                    }
                } }
            }, title: "new title").Wait();

            //client.DeleteInfographic(Guid.Parse("9f200d38-8803-4153-829a-c827b432de9e")).Wait();


            Console.WriteLine();
        }
    }
}
