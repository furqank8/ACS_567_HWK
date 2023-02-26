using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;
using HWK4.Interfaces;
using HWK4.Models;

using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HW6.Pages.Bills
{
    public class IndexModel : PageModel
    {
        public List<BillsModel> Bill = new();

        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5030");
                //HTTP GET
                var responseTask = client.GetAsync("Bills");
                responseTask.Wait();

                if (responseTask.Result.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Result.Content.ReadAsStringAsync();
                    Bill = JsonConvert.DeserializeObject<List<BillsModel>>(readTask);

                }
            }
        }
    }
}