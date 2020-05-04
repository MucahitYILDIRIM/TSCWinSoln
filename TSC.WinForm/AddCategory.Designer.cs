namespace TSC.WinForm
{
    partial class AddCategory
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.cbTopCategory = new System.Windows.Forms.ComboBox();
            this.btnCategorySave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategori Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Üst Kategori:";
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Location = new System.Drawing.Point(110, 60);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(119, 20);
            this.tbCategoryName.TabIndex = 2;
            // 
            // cbTopCategory
            // 
            this.cbTopCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTopCategory.FormattingEnabled = true;
            this.cbTopCategory.Location = new System.Drawing.Point(108, 86);
            this.cbTopCategory.Name = "cbTopCategory";
            this.cbTopCategory.Size = new System.Drawing.Size(121, 21);
            this.cbTopCategory.TabIndex = 3;
            // 
            // btnCategorySave
            // 
            this.btnCategorySave.Location = new System.Drawing.Point(154, 139);
            this.btnCategorySave.Name = "btnCategorySave";
            this.btnCategorySave.Size = new System.Drawing.Size(75, 23);
            this.btnCategorySave.TabIndex = 4;
            this.btnCategorySave.Text = "Kaydet";
            this.btnCategorySave.UseVisualStyleBackColor = true;
            this.btnCategorySave.Click += new System.EventHandler(this.btnCategorySave_Click);
            // 
            // AddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 219);
            this.Controls.Add(this.btnCategorySave);
            this.Controls.Add(this.cbTopCategory);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddCategory";
            this.Text = "AddCategory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCategory_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.ComboBox cbTopCategory;
        private System.Windows.Forms.Button btnCategorySave;
    }
}