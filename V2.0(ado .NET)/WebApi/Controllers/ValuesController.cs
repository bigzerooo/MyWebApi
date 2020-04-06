using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using DataAccessLayer;
namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        
        //public IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var configuration = GetConfiguration();
            //string con = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            return Ok(new string[] { MyConnection._connectionString });          
            //return new string[] { ConfigurationManager.ConnectionStrings };
            //return new string[] { ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
