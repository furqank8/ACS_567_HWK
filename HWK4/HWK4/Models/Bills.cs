using System.ComponentModel.DataAnnotations;

namespace HWK4.Models
{
        public class BillsModel
    {
            [Key] //Month is the primary key
            public string Month { get; set; }
            public int Expense { get; set; }

        public BillsModel(string month = "", int expense=0)
            {
                Month = month;
                Expense = expense;

            }//This is the constructor for the "Bills" class. It takes in two parameter "month" and "expense"
        }
    

}