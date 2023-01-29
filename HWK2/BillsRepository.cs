using BillsRestAPI;

namespace HWK2
{
    public class BillsRepository
    {
        public static BillsRepository instance;
        private List<Bills> bill; // Creating a list called bill.

        public static string filePath = "spm1.csv"; // File path
        private BillsRepository()
        {

            bill = new();
            //bill.Add(new Bills("Jan", 342));
            // read all lines from the input file
            StreamReader file = new StreamReader(filePath);

            string row = string.Empty;

            var asd = file.ReadLine();
            while ((row = file.ReadLine()) != null)
            {
                string[] rowItems = row.Split(",");
                bill.Add(new Bills(rowItems[0].ToString(), ParseInt(rowItems[1]) ?? 0));
            }
            file.Close(); 
        }

        public static BillsRepository getInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        } //creating an instance


        public List<Bills> getBills()
        {
            return bill;
        } //Gets complete list

        public Bills GetBill(String month)
        {
            return bill.FirstOrDefault(a => a.Month == month);
        } // Get value for a particular month

        public bool addBill(Bills bills)
        {
            bool isAdded = true;

            foreach (Bills b in bill)
            {
                if (b.Month == bills.Month)
                {
                    isAdded = false;
                    break;
                }
            }
            if (isAdded)
            {
                bill.Add(bills);
            }
            return isAdded;
        }// It is used to add new data. 

        public bool editBill(Bills updated)
        {
            bool isEdited = false;

            foreach (Bills b in bill)
            {
                if (b.Month == updated.Month)
                {
                    b.Expense = updated.Expense;

                    isEdited = true;
                    break;
                }
            }
            return isEdited;
        } // Expense value for a month can be changed by giving the month and new value

        public bool deleteBill(String month)
        {
            Bills delete = null;

            delete = bill.FirstOrDefault(a => month == a.Month);


            if (delete != null)
            {
                bill.Remove(delete);
            }

            return delete == null;
        } // bill existing in the .csv file can be deleted.
        //New
        public Dictionary<string,dynamic> analyzeBill()
        {
            List<int> numbers = bill
                            .Select(a => a.Expense)
                            .ToList();

            Dictionary<string, dynamic> analysis = new();
            // calculate the mean of the numbers
            double mean = numbers.Average();

            // calculate the median of the numbers
            int halfIndex = numbers.Count() / 2;
            var sortedNumbers = numbers.OrderBy(n => n);

            int median;

            if ((numbers.Count() % 2) == 0)
                median = (sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2;
            else
                median = sortedNumbers.ElementAt(halfIndex);


            analysis.Add("Mean", mean);
            analysis.Add("Median", median);
            analysis.Add("Max", numbers.Max());
            analysis.Add("Min", numbers.Min());

            return analysis;
        } // It provides the analysis data, mean , median , max and min

        private static int? ParseInt(string input)
        // // This method attempts to parse a string input as an integer and returns it, If the parse fails, it returns null
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




