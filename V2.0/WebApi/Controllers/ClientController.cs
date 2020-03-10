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
        public IEnumerable<Client> Get()
        {
            return _clientService.GetAllClients();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return _clientService.GetClientById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Client value)
        {
            _clientService.AddClient(value);
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public void Put(/*int id, */[FromBody]Client value)
        {
            _clientService.UpdateClient(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clientService.DeleteClient(id);
        }
    }
}
