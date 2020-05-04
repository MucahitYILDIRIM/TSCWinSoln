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
    public partial class AddProduct : Form
    {
        ShoppingCart ParentForm;
        public AddProduct(ShoppingCart ParentForm)
        {
            this.ParentForm = ParentForm;
            InitializeComponent();
            cbCategory.DataSource = ParentForm.CategoryList.Select(x => x.Title).ToList();
        }


        private void AddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (ParentForm.CategoryList.Where(x => x.Title == cbCategory.Text).Count() == 0)
                MessageBox.Show("Kategori Seçniz");
            else
            {
                ParentForm.ProductList.Add(new Product(tbName.Text, Convert.ToDouble(tbPrice.Text), ParentForm.CategoryList.SingleOrDefault(x => x.Title == cbCategory.Text)));
                this.Close();
            }
        }
    }
}
