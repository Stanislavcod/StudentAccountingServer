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
        [HttpGet("GetCustomer")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_customerService.Get());
        }
        [HttpGet("idCustomer/{id}", Name = "GetCustomerId")]
        public IActionResult Get(int id)
        {
            return Ok(_customerService.Get(id));
        }
        [HttpGet("nameCustomer/{name}", Name = "GetCustomerName")]
        public IActionResult Get(string name)
        {
            return Ok(_customerService.Get(name));
        }
        [HttpPost("CreateCustomer")]
        public IActionResult Create(Customer customer)
        {
            _customerService.Create(customer);
            return Ok();
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult Update(Customer customer)
        {
            _customerService.Edit(customer);
            return Ok();
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return Ok();
        }
    }
}
