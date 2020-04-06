using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinedController : Controller
    {
        IJoinedService _joinedService;
        public JoinedController(IJoinedService joinedService)
        {
            _joinedService = joinedService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_joinedService.GetAllJoined());
            }
            catch
            {
                return StatusCode(404);
            }            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_joinedService.GetJoinedById(id));
            }
            catch
            {
                return StatusCode(404);
            }            
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Joined value)
        {
            try
            {
                _joinedService.AddJoined(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public IActionResult Put(/*int id, */[FromBody]Joined value)
        {
            try
            {
                _joinedService.UpdateJoined(value);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _joinedService.DeleteJoined(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }
    }
}