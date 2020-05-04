using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC.Entity;

namespace TSC.WinForm
{
    public partial class ShowCart : Form
    {
        ShoppingCart ParentForm;
        public ShowCart(ShoppingCart ParentForm)
        {
            this.ParentForm = ParentForm;
            InitializeComponent();
            double miktar = ParentForm.ShoppingCarts.ShoppingCartList.Sum(x => x.Quantity*x.Product.Price);
            gvCoupon.DataSource = ParentForm.CouponList.Where( x=>x.MinProductPurchase<= miktar).ToList();
            FillGrid();
        }

        private void ShowCart_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Show();
        }

        private void brnRemoveProduct_Click(object sender, EventArgs e)
        {
            Product p = ParentForm.ProductList.Single(x => x.Title == gwCart.SelectedRows[0].Cells[0].Value.ToString());
            ParentForm.ShoppingCarts.removeItem(p, Convert.ToInt32(tbRemoveQuantity.Text));
            FillGrid();
        }
        private void FillGrid()
        {
            gwCart.DataSource = null;
            var TotalList = ParentForm.ShoppingCarts.ShoppingCartList.Select(o => new CartQuantityModel
            {
                ProductName = o.Product.Title,
                Quantity = o.Quantity,
                Price = o.Product.Price,
                TotalPrice = o.Quantity * o.Product.Price
            }).ToList();
            gwCart.DataSource = TotalList;

            lblTotalPrice.Text = TotalList.Sum(x => x.TotalPrice).ToString();
        }

        private void AddCoupon_Click(object sender, EventArgs e)
        {
            for (int i = gvCoupon.SelectedRows.Count -1; i >0 ; i--)
            {
                ParentForm.ShoppingCarts.applyCoupon((Coupon)gvCoupon.SelectedRows[i].DataBoundItem);
                ParentForm.CouponList.Remove((Coupon)gvCoupon.SelectedRows[i].DataBoundItem);
                double miktar = ParentForm.ShoppingCarts.ShoppingCartList.Sum(x => x.Quantity * x.Product.Price);
                gvCoupon.DataSource = ParentForm.CouponList.Where(x => x.MinProductPurchase <= miktar).ToList();
            }
        }
    }
}
