using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // path to the input file
        string filePath = "C:\\Users\\Furqan Khan\\OneDrive\\Desktop\\spm1.txt";

        // read all lines from the input file
        string[] lines = File.ReadAllLines(inputFilePath);

        // create a regular expression to match numbers
        Regex numberRegex = new Regex(@"[\d]+(?:[.,]\d+)?");  //matching decimal or int numbers

        // create a list to store the numbers
        List<double> numbers = new List<double>();

        // iterate through each line
        foreach (string line in lines)
        {
            // match all numbers in the line
            MatchCollection matches = numberRegex.Matches(line);

            // iterate through each match
            foreach (Match match in matches)
            {
                // convert the match to a double
                double number = double.Parse(match.Value);

                // add the number to the list
                numbers.Add(number);
            }
        }

        // calculate the mean of the numbers
        double mean = numbers.Average();
        Console.WriteLine("Mean : {0}", mean);
    }
}
