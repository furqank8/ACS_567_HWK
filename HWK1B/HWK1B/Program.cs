using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

class Program
{
    // specify file path
    public static string filePath = "..\\..\\..\\spm1.csv";
    
    static void Main(string[] args)
    {

        // read all lines from the input file
        StreamReader file = new StreamReader(filePath);

        string row = string.Empty;
        List<ExpenseModel> data = new List<ExpenseModel>(); 

        var asd = file.ReadLine();
        while((row = file.ReadLine()) != null) {

            string[] rowItems = row.Split(",");

            data.Add(new ExpenseModel()
            {
                Month = rowItems[0].ToString(),
                Expense = ParseInt(rowItems[1]) ?? 0
            });
        }
        file.Close();
        // Switch case - creating Menu console
        while (true)
        {
            Console.WriteLine("\n****** Monthly Electricity Bills ******\n");
            Console.WriteLine("1. Display Data");
            Console.WriteLine("2. Insert Data");
            Console.WriteLine("3. Analyse Data");
            Console.WriteLine("4. Filter Data");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice");
            Console.WriteLine();    

            switch (ReadAnInt())
                //Reading an integer value entered by user and validating if it is a number
            {
                case 1:
                    {
                        Console.WriteLine("Monthly Electricity Bills : ");
                        //Displaying the complete data using forEach loop
                        data.ForEach(item =>
                        {
                            Console.WriteLine(item.Month + " " + item.Expense);
                        });
                        Console.WriteLine();

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Input Data \n");
                        Console.WriteLine("Input Month : ");
                        string month = Console.ReadLine();
                        Console.WriteLine("Input Expense : ");

                        int? expense = ReadAnInt();

                        ExpenseModel newEntry = new ExpenseModel
                        {
                            Month = month,
                            Expense = (int)expense
                        };

                        //Adding a new entry into the csv file entered by the user

                        data.Add(newEntry);

                        WriteToFile(newEntry);
                        Console.WriteLine("Entry Inserted\n");
                        Console.WriteLine();

                        break;
                    }
                case 3:
                    {
                        //Creating a list of expense values to perform analysis
                        List<int> numbers = data
                            .Select(a => a.Expense)
                            .ToList();

                        PrintAverage(numbers);
                        PrintMedian (numbers);
                        PrintExtremes(numbers);
                        Console.WriteLine();

                        break;
                    }
                case 4:
                    { // Provides an filter option to choose
                        int Value1, Value2;
                        Console.WriteLine("Filtering the data");
                        Console.WriteLine("1. Display the months where the bill falls between a range:");
                        Console.WriteLine("2. Display the Expense for the month:");
                        Console.WriteLine("3. Exit ");
                        Console.WriteLine("Enter your choice");


                        int choice = ReadAnInt();
                        bool breakLoop = false;
                        while (true) {
                            switch (choice)
                            {
                                case 1:
                                    {// months where the bill falls between a range
                                        Console.WriteLine("Enter the min: ");
                                        Value1 = ReadAnInt();
                                        Console.WriteLine("Enter the max");
                                        Value2 = ReadAnInt();

                                        data.Where(a => a.Expense >= Value1)
                                            .Where(a => a.Expense <= Value2)
                                            .ToList()
                                            .ForEach(item =>
                                        {
                                            Console.WriteLine(item.Month);
                                            //Returning all the months that fall in the given range
                                        });
                                        breakLoop = true;

                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Select Month : ");
                                        
                                        int counter = 1;
                                        data.ForEach(a =>
                                        {
                                            Console.WriteLine(counter++ + " " + a.Month);
                                        });
                                        //Displaying all the months and taking a number slection from user
                                        Console.WriteLine("Enter your choice");
                                        var monthIndex = ReadAnInt();
                                        while (monthIndex < 1 || monthIndex > --counter)
                                        {
                                            Console.WriteLine("Please Enter from the above List : ");
                                            monthIndex = ReadAnInt();
                                        }

                                        Console.WriteLine(data[monthIndex - 1].Month + " : "+data[monthIndex - 1].Expense);
                                        //Displaying the expense for the selected month
                                        breakLoop = true;

                                        break;
                                    }
                                case 3:
                                    breakLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Please Enter from the above List : "); //To enter a value from the above list
                                    choice = ReadAnInt();
                                    break;
                            }
                            if (breakLoop)
                                break;
                        }
                        Console.WriteLine();

                        break;
                    }

                case 5:
                    {
                        //Breaks out - Exit 
                        Console.WriteLine();

                        return;
                    }
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    private static void PrintAverage(List<int> numbers)
    {
        // calculate the mean of the numbers
        double mean = numbers.Average();
        Console.WriteLine("Mean : {0}", mean);
    }

    private static void PrintMedian(List<int> numbers)
    {
        // calculate the median of the numbers
        int halfIndex = numbers.Count() / 2;
        var sortedNumbers = numbers.OrderBy(n => n);

        int median;

        if ((numbers.Count() % 2) == 0)
            median = (sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2;
        else
            median = sortedNumbers.ElementAt(halfIndex);

        Console.WriteLine(("Median : " + median));
    }
    private static void PrintExtremes(List<int> numbers)
    {
        //Finding the max and min value of Expenses.
        Console.WriteLine("Max : " + numbers.Max());
        Console.WriteLine("Min : " + numbers.Min());
    }

    #region Helper Functions

    private static int ReadAnInt()
    { 
        try
        {//Parsing the input value to check if it is an integer
            int? number = ParseInt(Console.ReadLine());

            while (number == null)
            {
                Console.WriteLine("Please enter a Valid Number : ");
                //If the entered value is not under the selection, user needs to enter a valid number
                number = ParseInt(Console.ReadLine());
            }

            return (int)number;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    private static int? ParseInt(string input)
    // // This method attempts to parse a string input as an integer and returns it, If the parse fails, it returns null
    {
        try
        {
            int number; 
            if(int.TryParse(input,out number))
                return number;
            else
                return null;

        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    


    private static void WriteToFile(ExpenseModel data)
    {// Appends the new data into the csv file.
        try
        {
            var newLine = string.Format("{0},{1}", data.Month, data.Expense.ToString());
            File.AppendAllText(filePath, newLine);
        }
        catch(Exception Ex)
        {
            throw Ex;
        }
    }

    #endregion

}

public class ExpenseModel
{  // This class represents an expense model with properties of Month and Expense
    public string Month { get; set; }
    public int Expense { get; set; }
}




