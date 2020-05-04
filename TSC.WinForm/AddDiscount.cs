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
    public partial class AddDiscount : Form
    {
        ShoppingCart ParentForm;
        public AddDiscount(ShoppingCart ParentForm)
        {
            this.ParentForm = ParentForm;
            InitializeComponent();
            cbCategory.DataSource = ParentForm.CategoryList.Select(x => x.Title).ToList();
            cbDiscountType.SelectedIndex = 0;
        }

        private void AddDiscount_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbDiscountType.SelectedIndex == 0)
                ParentForm.CampaignList.Add(new Campaign(ParentForm.CategoryList.SingleOrDefault(x => x.Title == cbCategory.Text), Convert.ToDouble(tbPrice.Text), Convert.ToInt32(tbMinQuantity.Text), (cbType.SelectedIndex == 0 ? DiscountType.Amount : DiscountType.Rate)));
            else
                ParentForm.CouponList.Add(new Coupon(Convert.ToDouble(tbMinQuantity.Text), Convert.ToDouble(tbPrice.Text), (cbType.SelectedIndex == 0 ? DiscountType.Amount : DiscountType.Rate)));
            this.Close();

        }

        private void cbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategory.Visible = cbDiscountType.SelectedIndex == 0 ? true : false;
            label2.Text = cbDiscountType.SelectedIndex == 0 ? "Min Miktar" : "Min Tutar";
        }
    }
}
