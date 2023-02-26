using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using HWK4.Interfaces;
using HWK4.Models;

using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HW6.Pages.Bills
{
    /// <summary>
    /// // This is the delete  class for deleting bills .   
    /// </summary>
    public class DeleteModel : PageModel
    {
        public BillsModel bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// This method is called when the page is loaded with an HTTP GET request. 
        /// </summary>
        public async void OnGet()
        {
           // line retrieves the month parameter from the query string of the request.
            string month = Request.Query["month"];
            using (var client = new HttpClient())
            {
                //These lines create an instance of HttpClient, set the base address
                client.BaseAddress = new Uri("http://localhost:5030");
                //HTTP GET
                var responseTask = client.DeleteAsync("Bills/" + month);
                responseTask.Wait();

                //If the response was successful, it sets the Month property of the bill object to the month parameter. 
                if (responseTask.Result.IsSuccessStatusCode)
                {
                    bill.Month = month;

                }

            }
        }
    }
}
