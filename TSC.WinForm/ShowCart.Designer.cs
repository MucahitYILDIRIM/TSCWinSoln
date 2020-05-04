namespace TSC.WinForm
{
    partial class ShowCart
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
            this.label1 = new System.Windows.Forms.Label();
            this.gwCart = new System.Windows.Forms.DataGridView();
            this.brnRemoveProduct = new System.Windows.Forms.Button();
            this.tbRemoveQuantity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.gvCoupon = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.AddCoupon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gwCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRemoveQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCoupon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sepetim";
            // 
            // gwCart
            // 
            this.gwCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwCart.Location = new System.Drawing.Point(17, 37);
            this.gwCart.MultiSelect = false;
            this.gwCart.Name = "gwCart";
            this.gwCart.ReadOnly = true;
            this.gwCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gwCart.Size = new System.Drawing.Size(479, 150);
            this.gwCart.TabIndex = 1;
            // 
            // brnRemoveProduct
            // 
            this.brnRemoveProduct.Location = new System.Drawing.Point(148, 203);
            this.brnRemoveProduct.Name = "brnRemoveProduct";
            this.brnRemoveProduct.Size = new System.Drawing.Size(77, 21);
            this.brnRemoveProduct.TabIndex = 2;
            this.brnRemoveProduct.Text = "Çıkar";
            this.brnRemoveProduct.UseVisualStyleBackColor = true;
            this.brnRemoveProduct.Click += new System.EventHandler(this.brnRemoveProduct_Click);
            // 
            // tbRemoveQuantity
            // 
            this.tbRemoveQuantity.Location = new System.Drawing.Point(66, 204);
            this.tbRemoveQuantity.Name = "tbRemoveQuantity";
            this.tbRemoveQuantity.Size = new System.Drawing.Size(76, 20);
            this.tbRemoveQuantity.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Toplam Fiyat:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(418, 210);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(48, 13);
            this.lblTotalPrice.TabIndex = 6;
            this.lblTotalPrice.Text = "DEneme";
            // 
            // gvCoupon
            // 
            this.gvCoupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCoupon.Location = new System.Drawing.Point(17, 284);
            this.gvCoupon.Name = "gvCoupon";
            this.gvCoupon.ReadOnly = true;
            this.gvCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCoupon.Size = new System.Drawing.Size(321, 108);
            this.gvCoupon.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kuponlar";
            // 
            // AddCoupon
            // 
            this.AddCoupon.Location = new System.Drawing.Point(249, 398);
            this.AddCoupon.Name = "AddCoupon";
            this.AddCoupon.Size = new System.Drawing.Size(89, 21);
            this.AddCoupon.TabIndex = 9;
            this.AddCoupon.Text = "Kupon Uygula";
            this.AddCoupon.UseVisualStyleBackColor = true;
            this.AddCoupon.Click += new System.EventHandler(this.AddCoupon_Click);
            // 
            // ShowCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 445);
            this.Controls.Add(this.AddCoupon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gvCoupon);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRemoveQuantity);
            this.Controls.Add(this.brnRemoveProduct);
            this.Controls.Add(this.gwCart);
            this.Controls.Add(this.label1);
            this.Name = "ShowCart";
            this.Text = "ShowCart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowCart_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gwCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRemoveQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCoupon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gwCart;
        private System.Windows.Forms.Button brnRemoveProduct;
        private System.Windows.Forms.NumericUpDown tbRemoveQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.DataGridView gvCoupon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddCoupon;
    }
}