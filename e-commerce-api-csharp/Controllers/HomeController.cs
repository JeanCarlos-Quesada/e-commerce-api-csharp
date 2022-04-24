using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using models = e_commerce_api_csharp.Models;

namespace e_commerce_api_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public models.User Login()
        {
            models.User user = new models.User();

            using (SqlConnection connection = new SqlConnection(_configuration.GetSection("ConnectionString").Value))
            using (SqlCommand command = new SqlCommand("Login", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", "jquesada"));
                connection.Open();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    user.identification = result["identification"].ToString();
                    user.fistName = result["firstName"].ToString();
                    user.lastName = result["lastName"].ToString();
                    user.phoneOne = result["phoneOne"].ToString();
                    user.phoneTwo = result["phoneTwo"].ToString();
                    user.email = result["email"].ToString();
                    user.isEmployee = Convert.ToBoolean(result["isEmployee"]);
                    user.password = (byte[]) result["password"];
                }

                connection.Close();
            }

            return user;
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
