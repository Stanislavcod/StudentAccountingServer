﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        [Authorize]
        [HttpGet("GetOrganization")]
        public ActionResult<IEnumerable<Organization>> Get()
        {
            try
            {
                return Ok(_organizationService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("idOrganization/{id}", Name = "GetOrganizationId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_organizationService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("nameOrganization/{name}", Name = "GetOrganizationName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_organizationService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateOrganization")]
        public IActionResult Create(Organization organization)
        {
            try
            {
                _organizationService.Create(organization);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateOrganization")]
        public IActionResult Update(Organization organization)
        {
            try
            {
                _organizationService.Edit(organization);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteOrganization")]
        public IActionResult Delete(int id)
        {
            try
            {
                _organizationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
