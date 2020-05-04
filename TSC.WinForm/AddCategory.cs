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
    public partial class AddCategory : Form
    {
        ShoppingCart ParentForm;
        public AddCategory(ShoppingCart ParentForm)
        {
            this.ParentForm = ParentForm;
            InitializeComponent();
            cbTopCategory.DataSource = ParentForm.CategoryList.Select(x => x.Title).ToList();
        }

        private void AddCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Show();
        }

        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            ParentForm.CategoryList.Add(new Category(tbCategoryName.Text, ParentForm.CategoryList.SingleOrDefault(x=>x.Title==cbTopCategory.Text)));
            this.Close();
        }
    }
}
