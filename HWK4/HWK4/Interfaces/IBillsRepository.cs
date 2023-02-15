﻿using HWK4.Models;

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
        ICollection<Bills> GetBills();

        /// <summary>
        ///  returns a bill object for that month.
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
        Bills GetBill(string Month);

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
        bool CreateBills(Bills bill);

        /// <summary>
        /// updates the corresponding bill in the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        bool UpdateBills(Bills bill);

        /// <summary>
        /// deletes the corresponding bill from the repository.
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        bool DeleteBills(Bills bill);

        /// <summary>
        /// returns a dictionary of string and dynamic objects with the analysis results.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, dynamic> analyzeBill();

        /// <summary>
        /// saves any changes made to the bills repository.
        /// </summary>
        /// <returns></returns>


        ICollection<Bills> GetBills();

        Bills GetBill(string Month);
        bool BillsExists(string Month);
        bool CreateBills(Bills bill);
        bool UpdateBills(Bills bill);
        bool DeleteBills(Bills bill);
        Dictionary<string, dynamic> analyzeBill();
        bool Save();
    }
}
