﻿using Microsoft.AspNetCore.Mvc;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet("GetPosition")]
        public ActionResult<IEnumerable<Position>> Get()
        {
            try
            {
                return Ok(_positionService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("idPosition/{id}", Name = "GetPositionId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_positionService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("namePosition/{name}", Name = "GetPositionName")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(_positionService.Get(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreatePosition")]
        public IActionResult Create(Position position)
        {
            try
            {
                _positionService.Create(position);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdatePosition")]
        public IActionResult Update(Position position)
        {
            try
            {
                _positionService.Edit(position);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletePosition")]
        public IActionResult Delete(int id)
        {
            try
            {
                _positionService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
