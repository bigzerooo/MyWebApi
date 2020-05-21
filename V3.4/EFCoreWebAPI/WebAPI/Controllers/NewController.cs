using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class NewController : Controller
    {
        INewService _newService;
        public NewController(INewService newService)
        {
            _newService = newService;
        }


        // GET: api/<controller>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _newService.GetAllNewsAsync());
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // GET api/<controller>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _newService.GetNewByIdAsync(id));
            }
            catch
            {
                return StatusCode(404);
            }
        }



        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _newService.AddNewAsync(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]NewDTO value)
        {
            try
            {
                await _newService.UpdateNewAsync(value);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _newService.DeleteNewAsync(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }
    }
}
