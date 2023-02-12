using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [Authorize]
        [HttpGet("GetCustomer")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            try
            {
                return Ok(_customerService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idCustomer/{id}", Name = "GetCustomerId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_customerService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("nameCustomer/{name}", Name = "GetCustomerName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_customerService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm")]
        [HttpPost("CreateCustomer")]
        public IActionResult Create(Customer customer)
        {
            try
            {
                _customerService.Create(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin,GlobalPm")]
        [HttpPut("UpdateCustomer")]
        public IActionResult Update(Customer customer)
        {
            try
            {
                _customerService.Edit(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCustomer")]
        public IActionResult Delete(int id)
        {
            try
            {
                _customerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
