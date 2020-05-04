using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Entity
{
    public class Cart
    {
        public Cart()
        {
            ShoppingCartList = new List<ShoppingChartItem>();
            UsedCoupon = new List<Coupon>();
        }
        public List<ShoppingChartItem> ShoppingCartList { get; set; }
        public List<Coupon> UsedCoupon { get; set; }

        public void addItem(Product Product, int Quantity)
        {
            if (ShoppingCartList.Where(x => x.Product == Product).Count() > 0)
            {
                ShoppingCartList.Single(x => x.Product == Product).Quantity += Quantity;
            }
            else
            {
                ShoppingCartList.Add(new ShoppingChartItem(Product, Quantity));
            }
        }
        public void removeItem(Product Product, int Quantity)
        {
            if (ShoppingCartList.Single(x => x.Product == Product).Quantity > Quantity)
            {
                ShoppingCartList.Single(x => x.Product == Product).Quantity -= Quantity;
            }
            else
            {
                ShoppingCartList.Remove(ShoppingCartList.Single(x => x.Product == Product));
            }
        }

        public void applyCoupon(Coupon coupon)
        {
            if (coupon.MinProductPurchase <= ShoppingCartList.Sum(x => x.Product.Price * x.Quantity))
                UsedCoupon.Add(coupon);
        }
        public double getTotalAmountAfterDiscounts(List<Campaign> campaigns)
        {
            return getCouponDiscount() + getCampaignDiscount(campaigns);
        }
        public double getCouponDiscount()
        {
            double CouponDiscount = 0;
            foreach (var item in UsedCoupon)
            {
                if (ShoppingCartList.Sum(x => x.Quantity * x.Product.Price) >= item.MinProductPurchase)
                {
                    if (item.Type == DiscountType.Amount)
                    {
                        CouponDiscount += item.DiscountPrice;
                    }
                    else
                    {
                        CouponDiscount += ShoppingCartList.Sum(x => x.Quantity * x.Product.Price) * item.DiscountPrice / 100;
                    }
                }
            }
            return CouponDiscount;
        }
        public double getCampaignDiscount(List<Campaign> campaigns)
        {
            double CampaignDiscount = 0;
            foreach (var item in campaigns)
            {
                if (ShoppingCartList.Count(x => x.Product.Category == item.Category) >= item.MinProductQuantity)
                {
                    if (item.Type == DiscountType.Amount)
                    {
                        CampaignDiscount += item.DiscountPrice;
                    }
                    else
                    {
                        CampaignDiscount += ShoppingCartList.Where(x => x.Product.Category == item.Category).Sum(x => x.Quantity * x.Product.Price) * item.DiscountPrice / 100;
                    }
                }
            }
            return CampaignDiscount;
        }
        public double getDeliveryCost(List<Campaign> campaigns)
        {
            return ShoppingCartList.Sum(x => x.Quantity * x.Product.Price) - getTotalAmountAfterDiscounts(campaigns);
        }

    }

    public class ShoppingChartItem
    {
        public ShoppingChartItem(Product Product, int Quantity)
        {
            this.Product = Product;
            this.Quantity = Quantity;
        }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }

    public class CartQuantityModel
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }


}
