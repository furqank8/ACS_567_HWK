using System.ComponentModel.DataAnnotations;

namespace HWK4.Models
{
<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        public class BillsModel
    {
            [Key] //Month is the primary key
            public string Month { get; set; }
            public int Expense { get; set; }

        public BillsModel(string month = "", int expense=0)
<<<<<<< HEAD
=======

        public class Bills
        {
            [Key] //Month is the primary key
            public string Month { get; set; }
            public int Expense { get; set; } = 0;

        public Bills(string month, int expense)

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            {
                Month = month;
                Expense = expense;

            }//This is the constructor for the "Bills" class. It takes in two parameter "month" and "expense"
        }
    

}