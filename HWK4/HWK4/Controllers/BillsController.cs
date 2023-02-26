using HWK4.Interfaces;
using HWK4.Models;
using HWK4.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace HWK4.Controllers
{
        [ApiController]
    [Route("[controller]")]
    // // Defining the route for the controller

    public class BillsController : ControllerBase //Defining the BillsController class which inherits from ControllerBase
    {

            private readonly ILogger<BillsController> _logger;
            private readonly IBillsRepository _billsRepository;

            public BillsController(ILogger<BillsController> logger, IBillsRepository billsRepository) //// Defining the constructor for the class and injecting dependencies
        {
                _logger = logger;
                _billsRepository = billsRepository;
            }
        /// <summary>
        /// Get all the bills present in database
        /// </summary>
        /// <returns></returns>
            [ProducesResponseType(200, Type = typeof(List<BillsModel>))]

            public IActionResult GetBills()
            {
                _logger.Log(LogLevel.Information, "Get Bills");
                return Ok(_billsRepository.GetBills());
            } 
            /// This method is a GET request that retrieves all bills from the repository.
            


            [HttpGet("{month}")] /// This method is a GET request that retrieves bills for a specific month
            [ProducesResponseType(200, Type = typeof(BillsModel))] /// This attribute indicates that the expected response type is 200 OK and the returned data is of type Bills
            [ProducesResponseType(404)] ///  if no bills are found for the specified month, a 404 Not Found response will be returned
            
            public IActionResult GetBill(String month)
            {
                _logger.Log(LogLevel.Information, "Get particular Bill");
            BillsModel bill = _billsRepository.GetBill(month); /// Retrieves the bill for the specified month from the repository
                if (bill == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(bill);
                }
            }
        /// <summary>
        /// Creating new bills 
        /// </summary>
        /// <param name="bill">using the bill object</param>
        /// <returns></returns>
            [HttpPost()]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]

            public IActionResult CreateBills([FromBody] BillsModel bill)
            {
                if (bill == null)
                {
                    return BadRequest("Bills is null");
                }
                bool result = _billsRepository.CreateBills(bill);

                if (result)
                {
                    return Ok("Successfully added");
                }
                else
                {
                    return BadRequest("Bill not added");
                }
            } 
            

        /// <summary>
        /// Updating the bill data
        /// </summary>
        /// <param name="bill"> passing the bill object</param>
        /// <returns></returns>
            [HttpPut]
            [ProducesResponseType(400)]
            [ProducesResponseType(200)]
            [ProducesResponseType(404)]

            public IActionResult UpdateBill([FromBody] BillsModel bill)
            {
                if (bill == null)
                {
                    return BadRequest("Bill is null");
                }
                bool isUpdated = _billsRepository.UpdateBills(bill);

                if (!isUpdated)
                {
                    return NotFound("No matching Bill");
                }
                else
                {
                    return Ok("Successfully updated");
                }
            } /// <summary>
              /// This is a Put request to update the expense
              /// </summary>
              /// 


        /// <summary>
        /// Delete request for removing an entry.
        /// </summary>

            [HttpDelete("{month}")]
            public IActionResult DeleteBill(string month)
            {
                bool isDeleted = _billsRepository.DeleteBills(month);

                return isDeleted ? Ok() : BadRequest();
            }


        /// <summary>
        /// //This is a get request to Analyse mean, median and mode.
        /// </summary>
        /// <returns></returns>
            [HttpGet("Analyse")]
            public IActionResult Analyse()
            {
                return Ok(_billsRepository.analyzeBill());
            } 



    }
   }



