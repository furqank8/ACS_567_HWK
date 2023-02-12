using HWK4.Interfaces;
using HWK4.Models;
using HWK4.Data;
using Microsoft.EntityFrameworkCore;


namespace HWK4.Repositories
{
    public class BillsRepository : IBillsRepository
    {
        private DataContext _context;

	    public BillsRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Getting all the bills
        /// </summary>
        /// <returns></returns>

        public ICollection<Bills> GetBills()
        {
            return _context.bill.ToList();
        }

        public Bills GetBill(String month)
        {
            return _context.bill.Where(bills => bills.Month == month).FirstOrDefault();
        }
        public bool BillsExists(String month)
        {
            return _context.bill.Any(bill => bill.Month == month);
        }
        public bool CreateBills(Bills bill)
        {
            _context.Add(bill);
            return Save();
        }

        public bool UpdateBills(Bills bill)
        {
            _context.Update(bill);
            return Save();
        }
        
        /// <summary>
        /// Deleting the bill entry
        /// </summary>
        /// <param name="bill">Passing bill object</param>
        /// <returns></returns>

        public bool DeleteBills(Bills bill)
        {
            _context.Remove(bill);
            return Save();
        }/// <summary>
        /// Delete bill
        /// </summary>
        /// <returns></returns>

        public Dictionary<string, dynamic> analyzeBill()
        {
            List<int> numbers = _context.bill
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
        } /// <summary>
        /// It provides the analysis data, mean , median , max and min
        /// </summary>
        /// <returns></returns>

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }
    }
}
