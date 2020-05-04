using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Entity
{
    public class Discount
    {
        public double DiscountPrice { get; set; }
        public DiscountType Type { get; set; }
 
    }
    public enum DiscountType
    {
        Rate,
        Amount
    }
}
