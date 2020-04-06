using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clientService.GetAllClients());
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
                return Ok(_clientService.GetClientById(id));
            }
            catch
            {
                return StatusCode(404);
            }            
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Client value)
        {
            try
            {
                _clientService.AddClient(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public IActionResult Put(/*int id, */[FromBody]Client value)
        {            
            try
            {            
                _clientService.UpdateClient(value);
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
                _clientService.DeleteClient(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
        }
    }
}
