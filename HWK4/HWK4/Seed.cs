using HWK4.Data;
using HWK4.Models;
using Microsoft.EntityFrameworkCore;

namespace HWK4
{
    public class Seed
    {
        private readonly DataContext dataContext;
        private List<Bills> bill; /// <summary>
                                  /// Creating a list called bill.
                                  /// </summary>

        public static string filePath = "spm1.csv"; /// <summary>
                                                    /// File path
                                                    /// </summary>
                                                    /// <param name="dataContext"></param>

        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        /// <summary>
        /// data context to read and store data into Db initially
        /// </summary>
        public void SeedDataContext() 
        {
            if (!dataContext.bill.Any())
            {
                bill = new();

                // read all lines from the input file
                StreamReader file = new StreamReader(filePath);

                string row = string.Empty;

                var asd = file.ReadLine();
                while ((row = file.ReadLine()) != null)
                {
                    string[] rowItems = row.Split(",");
                    bill.Add(new Bills(rowItems[0].ToString(), ParseInt(rowItems[1]) ?? 0));
                    Console.WriteLine(bill);
                }

                dataContext.bill.AddRange(bill);//Saving contents into the database
                dataContext.SaveChanges();
                
            }



        }

        /// <summary>
        ///This method attempts to parse a string input as an integer and returns it, If the parse fails, it returns null
        /// </summary>
        /// <param name="input"> Converts to Int</param>
        /// <returns></returns>
        private static int? ParseInt(string input) 
        {
            try
            {
                int number;
                if (int.TryParse(input, out number))
                    return number;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


