﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly Logger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, Logger<CustomerController> logger)
        {
            _logger = logger;
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
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
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
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
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
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
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
                
                _logger.LogInformation($"{DateTime.Now}: Create new customer");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
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
                
                _logger.LogInformation($"{DateTime.Now}: Edit customer with {customer.Id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
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
                
                _logger.LogInformation($"{DateTime.Now}: Delete customer with {id}");
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: {ex.Message}");
                
                return BadRequest(ex.Message);
            }
        }
    }
}
