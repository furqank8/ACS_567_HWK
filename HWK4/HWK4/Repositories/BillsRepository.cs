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

        public ICollection<BillsModel> GetBills()

        {
            return _context.bill.ToList();
        }


        /// <summary>
        ///  returns a bill object for that month.
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>

        public BillsModel GetBill(String month)
        {
            return _context.bill.Where(bills => bills.Month == month).FirstOrDefault();
        }


        /// <summary>
        /// returns a boolean value indicating whether a bill exists for that month or not
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>

        public bool BillsExists(String month)
        {
            return _context.bill.Any(bill => bill.Month == month);
        }

        /// <summary>
        /// creates a new bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public bool CreateBills(BillsModel bill)

        {
            _context.Add(bill);
            return Save();
        }


        /// <summary>
        /// updates the corresponding bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public bool UpdateBills(BillsModel bill)

        {
            _context.Update(bill);
            return Save();
        }
        
        /// <summary>
        /// Deleting the bill entry
        /// </summary>
        /// <param name="bill">Passing bill object</param>
        /// <returns></returns>


        public bool DeleteBills(string month)
        {
            var items = _context.bill.Where(item=> item.Month.Trim() == month.Trim());
            foreach (var item in items)
            {
                _context.Remove(item);

            }
            return Save();
        }

        /// <summary>
        /// It provides the analysis data, mean , median , max and min

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
        }

        /// <summary>
        /// saves any changes made to the bills repository.
        /// </summary>
        /// <returns></returns>

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }
    }
}
