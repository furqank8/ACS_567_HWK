using HWK4.Interfaces;
using HWK4.Models;
using HWK4.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace HWK4.Controllers
{
        [ApiController]
<<<<<<< HEAD
    [Route("[controller]")]
    // // Defining the route for the controller
=======

    [Route("[controller]")]
    // // Defining the route for the controller
        [Route("[controller]")] // // Defining the route for the controller

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

    public class BillsController : ControllerBase //Defining the BillsController class which inherits from ControllerBase
    {

<<<<<<< HEAD
=======

        [Route("[controller]")]

        public class BillsController : ControllerBase
        {

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            private readonly ILogger<BillsController> _logger;
            private readonly IBillsRepository _billsRepository;

            public BillsController(ILogger<BillsController> logger, IBillsRepository billsRepository) //// Defining the constructor for the class and injecting dependencies
        {
<<<<<<< HEAD
=======


            public BillsController(ILogger<BillsController> logger, IBillsRepository billsRepository)
            {

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
                _logger = logger;
                _billsRepository = billsRepository;
            }
        /// <summary>
        /// Get all the bills present in database
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD
            [ProducesResponseType(200, Type = typeof(List<BillsModel>))]
=======

            [ProducesResponseType(200, Type = typeof(List<BillsModel>))]

            [HttpGet]
            [ProducesResponseType(200, Type = typeof(List<Bills>))]

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0

            public IActionResult GetBills()
            {
                _logger.Log(LogLevel.Information, "Get Bills");
                return Ok(_billsRepository.GetBills());
            } 
            /// This method is a GET request that retrieves all bills from the repository.
            


            [HttpGet("{month}")] /// This method is a GET request that retrieves bills for a specific month
<<<<<<< HEAD
            [ProducesResponseType(200, Type = typeof(BillsModel))] /// This attribute indicates that the expected response type is 200 OK and the returned data is of type Bills
=======

            [ProducesResponseType(200, Type = typeof(BillsModel))] /// This attribute indicates that the expected response type is 200 OK and the returned data is of type Bills

            [ProducesResponseType(200, Type = typeof(Bills))] /// This attribute indicates that the expected response type is 200 OK and the returned data is of type Bills

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            [ProducesResponseType(404)] ///  if no bills are found for the specified month, a 404 Not Found response will be returned
            
            public IActionResult GetBill(String month)
            {
                _logger.Log(LogLevel.Information, "Get particular Bill");
<<<<<<< HEAD
            BillsModel bill = _billsRepository.GetBill(month); /// Retrieves the bill for the specified month from the repository
=======

            BillsModel bill = _billsRepository.GetBill(month); /// Retrieves the bill for the specified month from the repository

                Bills bill = _billsRepository.GetBill(month); /// Retrieves the bill for the specified month from the repository

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
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
<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            [HttpPost()]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]

            public IActionResult CreateBills([FromBody] BillsModel bill)
<<<<<<< HEAD
=======

            [HttpPost]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]

            public IActionResult CreateBills([FromBody] Bills bill)

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
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

<<<<<<< HEAD
            public IActionResult UpdateBill([FromBody] BillsModel bill)
=======

            public IActionResult UpdateBill([FromBody] BillsModel bill)

            public IActionResult UpdateBill([FromBody] Bills bill)

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
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
<<<<<<< HEAD
=======




>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
              /// This is a Put request to update the expense
              /// </summary>
              /// 


        /// <summary>
        /// Delete request for removing an entry.
        /// </summary>

<<<<<<< HEAD
=======

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            [HttpDelete("{month}")]
            public IActionResult DeleteBill(string month)
            {
                bool isDeleted = _billsRepository.DeleteBills(month);
<<<<<<< HEAD

                return isDeleted ? Ok() : BadRequest();
=======

                return isDeleted ? Ok() : BadRequest();

            /// This is a Put request to update the expense
            /// </summary>
                   
            [HttpDelete]
            public IActionResult DeleteBill([FromBody] Bills bill)
            {
                bool deleted = _billsRepository.DeleteBills(bill);
                if (!deleted)
                {
                    return NotFound("No matching month");
                }
                else
                {
                    return Ok("Bill deleted");
                }

>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            }


        /// <summary>
        /// //This is a get request to Analyse mean, median and mode.
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD
=======

        
            } /// <summary>
              /// Delete request for removing an entry.
              /// </summary>


>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0
            [HttpGet("Analyse")]
            public IActionResult Analyse()
            {
                return Ok(_billsRepository.analyzeBill());
<<<<<<< HEAD
            } 

=======

            } 



            } 

            } //This is a get request to Analyse mean, median and mode.


>>>>>>> b776ae7e5ece7d902e3d1fa7bc92c408f20110c0


    }
   }



