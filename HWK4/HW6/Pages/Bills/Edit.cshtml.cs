using HWK4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace HW6.Pages.Bills
{
    /// <summary>
    /// Edit class for editing bills.
    /// </summary>
    public class EditModel : PageModel
    {
        /// <summary>
        /// Bill is an instance of Bill Model class
        /// </summary>
        public BillsModel bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// sends an HTTP GET request to the specified URL with the month.
        /// </summary>
        public async void OnGet()
        {
            string month = Request.Query["month"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5030");
                //HTTP GET
                var responseTask = client.GetAsync("Bills/" + month);
                responseTask.Wait();

                var result= responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    bill = JsonConvert.DeserializeObject<BillsModel>(readTask);

                }
            }
        }

        /// <summary>
        ///it retrieves the expense and month fields from the form, updates the bill with new values
        /// </summary>
        public async void OnPost()
        {
            //retrieve the expense and month fields from the form and assign them to the Expense and Month properties of the bill object.
            bill.Expense = int.Parse(Request.Form["expense"]); 
            bill.Month = Request.Form["month"];

            //creates a new instance of JsonSerializerOptions with WriteIndented property set to true
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize<BillsModel>(bill, opt);

            using (var client = new HttpClient())
            {
                //create an instance of HttpClient, set the base address to localhost.
                client.BaseAddress = new Uri("http://localhost:5030");
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var result = await client.PutAsync("Bills", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
                //If the response is successful, it sets the successMessage property; otherwise, it sets the errorMessage property.
                if (!result.IsSuccessStatusCode)
                {
                    errorMessage = "error editing";

                }
                else
                {
                    successMessage = "Successfully edited";
                }
            }
        }


    }

   
}
