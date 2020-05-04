using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Entity
{
    public class Coupon : Discount
    {
        public Coupon(double MinProductPurchase, double DiscountPrice, DiscountType Type)
        {
            this.DiscountPrice = DiscountPrice;
            this.MinProductPurchase = MinProductPurchase;
            this.Type = Type;
        }
        public double MinProductPurchase { get; set; }
    }
}
