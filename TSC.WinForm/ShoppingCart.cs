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
    public partial class ShoppingCart : Form
    {
        public List<Category> CategoryList;
        public List<Product> ProductList;
        public List<Campaign> CampaignList;
        public List<Coupon> CouponList;
        public Cart ShoppingCarts;

        public ShoppingCart()
        {
            InitializeComponent();
            DefineLists();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddProduct(this).Show();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddCategory(this).Show();
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            Product p = ProductList.Single(x=>x.Title == dgProduct.SelectedRows[0].Cells[0].Value.ToString());
            ShoppingCarts.addItem(p, Convert.ToInt32(tbQuantity.Text));
            MessageBox.Show("Başarıyla Eklendi");

        }
        public void DefineLists()
        {
            CategoryList = new List<Category>();
            ProductList = new List<Product>();
            CampaignList = new List<Campaign>();
            CouponList = new List<Coupon>();
            ShoppingCarts = new Cart();
            CategoryList.Add(new Category("Deneme", null)); // TODO :sil
        }
    
        private void ShoppingCart_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                FillDT();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product p = ProductList.Single(x => x.Title == dgProduct.SelectedRows[0].Cells[0].Value.ToString());
            ProductList.Remove(p);
            FillDT();
        }

        private void FillDT()
        {
            dgProduct.DataSource = null;

            dgProduct.DataSource = ProductList.Select(o => new ShowProductModel
            {
                Title = o.Title,
                Price = o.Price,
                Category = o.Category.Title
            }).ToList();
        }

        private void btnShowCart_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ShowCart(this).Show();
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddDiscount(this).Show();
        }
    }
}
