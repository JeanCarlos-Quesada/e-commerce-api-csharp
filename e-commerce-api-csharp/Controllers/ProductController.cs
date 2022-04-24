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
    public class ProductController : ControllerBase
    {
        private IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<models.Product> GetAll()
        {
            List<models.Product> products = new List<models.Product>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetSection("ConnectionString").Value))
            using (SqlCommand command = new SqlCommand("GetAllProducts", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    models.Product product = new models.Product();
                    product.id = Convert.ToInt32(result["id"]);
                    product.name = result["name"].ToString();
                    product.details = result["details"].ToString();
                    product.price = Convert.ToDecimal(result["price"]);
                    product.amountInInventory = Convert.ToInt32(result["amountInInventory"]);
                    product.subCategoryID = Convert.ToInt32(result["subCategory"]);
                    product.categoryID = Convert.ToInt32(result["category"]);

                    products.Add(product);
                }

                connection.Close();
            }

            return products;
        }

        [HttpGet]
        [Route("GetMostPopular")]
        public IEnumerable<models.Product> GetMostPopular()
        {
            List<models.Product> products = new List<models.Product>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetSection("ConnectionString").Value))
            using (SqlCommand command = new SqlCommand("GetMostPopularProducts", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    models.Product product = new models.Product();
                    product.id = Convert.ToInt32(result["id"]);
                    product.name = result["name"].ToString();
                    product.details = result["details"].ToString();
                    product.price = Convert.ToDecimal(result["price"]);
                    product.amountInInventory = Convert.ToInt32(result["amountInInventory"]);
                    product.subCategoryID = Convert.ToInt32(result["subCategory"]);
                    product.categoryID = Convert.ToInt32(result["category"]);

                    products.Add(product);
                }

                connection.Close();
            }

            return products;
        }

        [HttpGet]
        [Route("GetOne")]
        public models.Product GetOne(int id)
        {
            models.Product product = new models.Product();

            using (SqlConnection connection = new SqlConnection(_configuration.GetSection("ConnectionString").Value))
            using (SqlCommand command = new SqlCommand("GetOneProduct", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();

                var result = command.ExecuteReader();
                while (result.Read())
                {
                    product.id = Convert.ToInt32(result["id"]);
                    product.name = result["name"].ToString();
                    product.details = result["details"].ToString();
                    product.price = Convert.ToDecimal(result["price"]);
                    product.amountInInventory = Convert.ToInt32(result["amountInInventory"]);
                    product.subCategoryID = Convert.ToInt32(result["subCategory"]);
                    product.categoryID = Convert.ToInt32(result["category"]);
                }

                connection.Close();
            }

            return product;
        }

        [HttpPost]
        [Route("Insert")]
        public void Post([FromBody] models.Product product)
        {

        }

        [HttpPut]
        [Route("Update")]
        public void Put([FromBody] models.Product product)
        {
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
        }
    }
}
