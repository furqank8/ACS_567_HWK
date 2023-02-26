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

<<<<<<< HEAD
        public ICollection<BillsModel> GetBills()
=======

        public ICollection<BillsModel> GetBills()

        public ICollection<Bills> GetBills()

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        {
            return _context.bill.ToList();
        }

<<<<<<< HEAD
=======




>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        /// <summary>
        ///  returns a bill object for that month.
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>

<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        public BillsModel GetBill(String month)
        {
            return _context.bill.Where(bills => bills.Month == month).FirstOrDefault();
        }

<<<<<<< HEAD
=======

        public Bills GetBill(String month)
        {
            return _context.bill.Where(bills => bills.Month == month).FirstOrDefault();
        }

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        /// <summary>
        /// returns a boolean value indicating whether a bill exists for that month or not
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        public bool BillsExists(String month)
        {
            return _context.bill.Any(bill => bill.Month == month);
        }

        /// <summary>
        /// creates a new bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
<<<<<<< HEAD
        public bool CreateBills(BillsModel bill)
=======

        public bool CreateBills(BillsModel bill)


        public bool CreateBills(Bills bill)

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        {
            _context.Add(bill);
            return Save();
        }

<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        /// <summary>
        /// updates the corresponding bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
<<<<<<< HEAD
        public bool UpdateBills(BillsModel bill)
=======

        public bool UpdateBills(BillsModel bill)


        public bool UpdateBills(Bills bill)

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        {
            _context.Update(bill);
            return Save();
        }
        
        /// <summary>
        /// Deleting the bill entry
        /// </summary>
        /// <param name="bill">Passing bill object</param>
        /// <returns></returns>

<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
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
<<<<<<< HEAD
=======

        public bool DeleteBills(Bills bill)
        {
            _context.Remove(bill);
            return Save();
           }
        

        /// <summary>
        /// It provides the analysis data, mean , median , max and min

        }/// <summary>
        /// Delete bill


>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
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
<<<<<<< HEAD
=======


        } /// <summary>
        /// It provides the analysis data, mean , median , max and min
        /// </summary>
        /// <returns></returns>


>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }
    }
}
