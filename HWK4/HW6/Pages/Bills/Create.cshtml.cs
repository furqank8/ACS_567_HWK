using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using HWK4.Interfaces;
using HWK4.Models;
using System.Text.Json;

namespace HW6.Pages.Bills
{
    /// <summary>
    /// // This is the Create page model class for creating new bills.
    /// </summary>
    public class CreateModel : PageModel
    {
        public BillsModel bill = new();
        public string errorMessage = "";
        public string successMessage = "";

        /// <summary>
        /// This method is called when the form is submitted with an HTTP POST request to create a new bill
        /// </summary>
        public async void OnPost()
        {
            // retrieve the values of the month and expense fields from the form data and set the corresponding properties of the bill object.
            bill.Month = Request.Form["month"];
            bill.Expense = int.Parse(Request.Form["expense"]);

            // check if the Month property of the bill object is empty, and if so, sets the errorMessage property.
            if (bill.Month.Length == 0)
                errorMessage = "Month is required";
            else
            {
                string json = JsonSerializer.Serialize<BillsModel>(bill, new JsonSerializerOptions() { WriteIndented = true });

                using (var client = new HttpClient())
                {
                    //create an instance of HttpClient, sets the base address to "http://localhost:5030"
                    client.BaseAddress = new Uri("http://localhost:5030");

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PostAsync("Bills", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    //sets the errorMessage or successMessage property based on the result of the request.
                    if (!result.IsSuccessStatusCode)
                        errorMessage = "Error Adding";
                    else
                        successMessage = "Successfully Added";

                }
            }
        }
    }
}
