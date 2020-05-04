namespace TSC.WinForm
{
    partial class ShoppingCart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.dgProduct = new System.Windows.Forms.DataGridView();
            this.btnShowCart = new System.Windows.Forms.Button();
            this.btnAddCart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.NumericUpDown();
            this.brnDeleteProduct = new System.Windows.Forms.Button();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddDiscount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(102, 12);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(84, 23);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Ürün Ekle";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(12, 12);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(84, 23);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Kategori Ekle";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // dgProduct
            // 
            this.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduct.Location = new System.Drawing.Point(12, 53);
            this.dgProduct.MultiSelect = false;
            this.dgProduct.Name = "dgProduct";
            this.dgProduct.ReadOnly = true;
            this.dgProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProduct.Size = new System.Drawing.Size(493, 192);
            this.dgProduct.TabIndex = 2;
            // 
            // btnShowCart
            // 
            this.btnShowCart.Location = new System.Drawing.Point(391, 12);
            this.btnShowCart.Name = "btnShowCart";
            this.btnShowCart.Size = new System.Drawing.Size(99, 23);
            this.btnShowCart.TabIndex = 3;
            this.btnShowCart.Text = "Sepetimi Göster";
            this.btnShowCart.UseVisualStyleBackColor = true;
            this.btnShowCart.Click += new System.EventHandler(this.btnShowCart_Click);
            // 
            // btnAddCart
            // 
            this.btnAddCart.Location = new System.Drawing.Point(430, 251);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(75, 23);
            this.btnAddCart.TabIndex = 4;
            this.btnAddCart.Text = "Spete Ekle";
            this.btnAddCart.UseVisualStyleBackColor = true;
            this.btnAddCart.Click += new System.EventHandler(this.btnAddCart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Adet :";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(349, 251);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(75, 20);
            this.tbQuantity.TabIndex = 6;
            // 
            // brnDeleteProduct
            // 
            this.brnDeleteProduct.Location = new System.Drawing.Point(12, 251);
            this.brnDeleteProduct.Name = "brnDeleteProduct";
            this.brnDeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.brnDeleteProduct.TabIndex = 7;
            this.brnDeleteProduct.Text = "Ürün Sil";
            this.brnDeleteProduct.UseVisualStyleBackColor = true;
            this.brnDeleteProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.Location = new System.Drawing.Point(192, 12);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(91, 23);
            this.btnAddDiscount.TabIndex = 8;
            this.btnAddDiscount.Text = "İndirimEkle";
            this.btnAddDiscount.UseVisualStyleBackColor = true;
            this.btnAddDiscount.Click += new System.EventHandler(this.btnAddDiscount_Click);
            // 
            // ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 286);
            this.Controls.Add(this.btnAddDiscount);
            this.Controls.Add(this.brnDeleteProduct);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCart);
            this.Controls.Add(this.btnShowCart);
            this.Controls.Add(this.dgProduct);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnAddProduct);
            this.Name = "ShoppingCart";
            this.Text = "ShoppingCart";
            this.VisibleChanged += new System.EventHandler(this.ShoppingCart_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.DataGridView dgProduct;
        private System.Windows.Forms.Button btnShowCart;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Button btnAddCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tbQuantity;
        private System.Windows.Forms.Button brnDeleteProduct;
        private System.Windows.Forms.Button btnAddDiscount;
    }
}