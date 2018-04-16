using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PokemonCRUD.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {

            using (var client = new HttpClient())
            {
                // add the appropriate properties on top of the client base address.
                client.BaseAddress = new Uri("http://www.zillow.com/webservice/");

                //the .Result is important for us to extract the result of the response from the call
                var response =  await client.GetAsync("GetDeepComps.htm?zws-id=X1-ZWz18nvm8jm80b_1is62&zpid=48749425&count=5").Result;

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                }
            }

            return View();
        }


        public async Task<IActionResult> GetCars()
        {
          




        }





    }//bottom of class
}
