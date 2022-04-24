using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_api_csharp.Models
{
    public class Product
    {
        public Product()
        {
            this.colors = new List<string>();
            this.sizes = new List<string>();
            this.images = new List<int>();
            this.category = new Category();
        }

        public Product(int id, string name, string details, decimal price, int amountInInventory, int subCategoryID, int categoryID, Category category)
        {
            this.id = id;
            this.name = name;
            this.details = details;
            this.price = price;
            this.amountInInventory = amountInInventory;
            this.subCategoryID = subCategoryID;
            this.categoryID = categoryID;
            this.colors = new List<string>();
            this.sizes = new List<string>();
            this.images = new List<int>();
            this.category = category;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public decimal price { get; set; }
        public int amountInInventory { get; set; }
        public int subCategoryID { get; set; }
        public int categoryID { get; set; }
        public List<string> colors { get; set; }
        public List<string> sizes { get; set; }
        public List<int> images { get; set; }
        public Category category { get; set; }
    }
}
