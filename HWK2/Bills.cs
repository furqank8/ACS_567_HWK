namespace BillsRestAPI
{
    public class Bills
    {


         public Bills(string month, int expense) 
        {
            Month= month;
            Expense = expense;

        }//This is the constructor for the "Bills" class. It takes in two parameter "month" and "expense".


        public string Month { get;  set; }
        public int Expense { get;  set; }

        //Getter and setters
        
    }
}