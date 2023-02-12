using HWK4.Models;

namespace HWK4.Interfaces

{/// <summary>
/// Declaration of all methods in the repository.
/// </summary>
    public interface IBillsRepository
    {

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
