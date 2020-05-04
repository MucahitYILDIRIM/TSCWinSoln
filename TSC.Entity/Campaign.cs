using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Entity
{
    public class Campaign : Discount
    {
        public Campaign(Category Category, double DiscountPrice, int MinProductQuantity, DiscountType Type)
        {
            this.Category = Category;
            this.DiscountPrice = DiscountPrice;
            this.MinProductQuantity = MinProductQuantity;
            this.Type = Type;
        }
        public Category Category { get; set; }
        public int MinProductQuantity { get; set; }
    }
}
