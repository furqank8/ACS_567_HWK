using BillsRestAPI;
using Microsoft.AspNetCore.Mvc;

namespace HWK2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BillsController : ControllerBase
    {

        public BillsController()
        {
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Bills>))]

        public IActionResult GetBills()
        {
            return Ok(BillsRepository.getInstance().getBills());
        } // This method is a GET request that retrieves all bills from the repository.


        [HttpGet("{month}")] // This method is a GET request that retrieves bills for a specific month
        [ProducesResponseType(200, Type = typeof(Bills))] // // This attribute indicates that the expected response type is 200 OK and the returned data is of type Bills
        [ProducesResponseType(404)] // t if no bills are found for the specified month, a 404 Not Found response will be returned

        public IActionResult GetBill(String month)
        {
            Bills bill = BillsRepository.getInstance().GetBill(month); // Retrieves the bill for the specified month from the repository
            if (bill == null)
            {
                return NotFound(); 
            }
            else
            {
                return Ok(bill);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateBills([FromBody] Bills bill)
        {
            if (bill == null)
            {
                return BadRequest("Bills is null");
            }
            bool result = BillsRepository.getInstance().addBill(bill);

            if (result)
            {
                return Ok("Successfully added");
            }
            else
            {
                return BadRequest("Bill not added");
            }
        } // This is a post request to add new bills


        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]



        public IActionResult UpdateBill([FromBody] Bills bill)
        {
            if (bill == null)
            {
                return BadRequest("Bill is null");
            }
            bool isUpdated = BillsRepository.getInstance().editBill(bill);

            if (!isUpdated)
            {
                return NotFound("No matching Bill");
            }
            else
            {
                return Ok("Successfully updated");
            }
        } // This is a Put request to update the expense

        [HttpDelete]

        public IActionResult DeleteBill(String month)
        {
            bool deleted = BillsRepository.getInstance().deleteBill(month);
            if (!deleted)
            {
                return NotFound("No matching month");
            }
            else
            {
                return Ok("Bill deleted");
            }
        } // Delete request for removing an entry.

        [HttpGet("Analyse")]
        public IActionResult Analyse()
        {
            return Ok(BillsRepository.getInstance().analyzeBill());
        } //This is a get request to Analyse mean, median and mode.

    }
}

            