using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsumeTheAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

/*
 Need to consume an API.  Use the following code as a baseline:

    using (var client = new HttpClient())
	{
		// add the appropriate properties on top of the client base address.
		client.BaseAddress = new Uri("http://www.zillow.com/webservice/"); // Use my own To Do List on Azure.

		//the .Result is important for us to extract the result of the response from the call
		var response = client.GetAsync("GetDeepComps.htm?zws-id=X1-ZWz18nvm8jm80b_1is62&zpid=48749425&count=5").Result;

		if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
		{
			var stringResult = await response.Content.ReadAsStringAsync();
		}
	}
 */
