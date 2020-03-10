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
        public IEnumerable<Joined> Get()
        {
            return _joinedService.GetAllJoined();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Joined Get(int id)
        {
            return _joinedService.GetJoinedById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Joined value)
        {
            _joinedService.AddJoined(value);
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public void Put(/*int id, */[FromBody]Joined value)
        {
            _joinedService.UpdateJoined(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _joinedService.DeleteJoined(id);
        }
    }
}