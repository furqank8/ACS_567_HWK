using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace HW6.Pages.Bills
    
{/// <summary>
/// // This page model is responsible for analyzing the bills data and displaying the results
/// </summary>
    public class AnalyseModel : PageModel
    {
        /// <summary>
        /// It declares a public BillsModel object named bill.
        /// </summary>
        public BillsModel bill = new();
        /// <summary>
        /// It declares a public dictionary named dictionary, which will store the analysis data.
        /// </summary>
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        /// <summary>
        /// It declares a public asynchronous method named OnGet.
        /// </summary>
        public async void OnGet()
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5030");
               // creates a new HttpClient GET request to the "Bills/Analyse" API endpoint.
                //HTTP GET
                var responseTask = client.GetAsync("Bills/Analyse");
                responseTask.Wait();

                var readTask = await responseTask.Result.Content.ReadAsStringAsync();
                //The dictionary object is then used in the Razor Page to display the analysis data.
                dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(readTask);


            }
        }
    }
}
