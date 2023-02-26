using HWK4.Models;

namespace HWK4.Interfaces

{/// <summary>
/// Declaration of all methods in the repository.
/// </summary>
    public interface IBillsRepository
    {
        /// <summary>
        /// returns a collection of all bills
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD
        ICollection<BillsModel> GetBills();
=======

        ICollection<BillsModel> GetBills();

        ICollection<Bills> GetBills();

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

        /// <summary>
        ///  returns a bill object for that month.
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
<<<<<<< HEAD
        BillsModel GetBill(string Month);
=======

        BillsModel GetBill(string Month);

        Bills GetBill(string Month);

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

        /// <summary>
        /// returns a boolean value indicating whether a bill exists for that month or not
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
        bool BillsExists(string Month);

        /// <summary>
        /// creates a new bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
<<<<<<< HEAD
        bool CreateBills(BillsModel bill);
=======

        bool CreateBills(BillsModel bill);

        bool CreateBills(Bills bill);

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

        /// <summary>
        /// updates the corresponding bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
<<<<<<< HEAD
        bool UpdateBills(BillsModel bill);
=======

        bool UpdateBills(BillsModel bill);

        bool UpdateBills(Bills bill);

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

        /// <summary>
        /// deletes the corresponding bill from the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
<<<<<<< HEAD
        bool DeleteBills(string month);
=======

        bool DeleteBills(string month);

        bool DeleteBills(Bills bill);

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

        /// <summary>
        /// returns a dictionary of string and dynamic objects with the analysis results.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, dynamic> analyzeBill();

        /// <summary>
        /// saves any changes made to the bills repository.
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD
=======



        ICollection<Bills> GetBills();

        Bills GetBill(string Month);
        bool BillsExists(string Month);
        bool CreateBills(Bills bill);
        bool UpdateBills(Bills bill);
        bool DeleteBills(Bills bill);
        Dictionary<string, dynamic> analyzeBill();
>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
        bool Save();
    }
}
