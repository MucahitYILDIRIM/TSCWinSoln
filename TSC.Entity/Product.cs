using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Entity
{
    public class Product
    {

        public Product(string Title, double Price, Category Category)
        {
            this.Title = Title;
            this.Price = Price;
            this.Category = Category;
        }
        public string Title { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }

    public class ShowProductModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
