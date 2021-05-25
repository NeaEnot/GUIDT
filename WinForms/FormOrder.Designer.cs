
namespace WinForms
{
    partial class FormOrder
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDeleteOrderProduct = new System.Windows.Forms.Button();
            this.buttonUpdateOrderProduct = new System.Windows.Forms.Button();
            this.buttonCreateOrderProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 13);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(571, 372);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 395);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDeleteOrderProduct
            // 
            this.buttonDeleteOrderProduct.Location = new System.Drawing.Point(488, 394);
            this.buttonDeleteOrderProduct.Name = "buttonDeleteOrderProduct";
            this.buttonDeleteOrderProduct.Size = new System.Drawing.Size(95, 23);
            this.buttonDeleteOrderProduct.TabIndex = 2;
            this.buttonDeleteOrderProduct.Text = "Delete product";
            this.buttonDeleteOrderProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteOrderProduct.Click += new System.EventHandler(this.buttonDeleteOrderProduct_Click);
            // 
            // buttonUpdateOrderProduct
            // 
            this.buttonUpdateOrderProduct.Location = new System.Drawing.Point(381, 394);
            this.buttonUpdateOrderProduct.Name = "buttonUpdateOrderProduct";
            this.buttonUpdateOrderProduct.Size = new System.Drawing.Size(101, 23);
            this.buttonUpdateOrderProduct.TabIndex = 3;
            this.buttonUpdateOrderProduct.Text = "Update product";
            this.buttonUpdateOrderProduct.UseVisualStyleBackColor = true;
            this.buttonUpdateOrderProduct.Click += new System.EventHandler(this.buttonUpdateOrderProduct_Click);
            // 
            // buttonCreateOrderProduct
            // 
            this.buttonCreateOrderProduct.Location = new System.Drawing.Point(276, 394);
            this.buttonCreateOrderProduct.Name = "buttonCreateOrderProduct";
            this.buttonCreateOrderProduct.Size = new System.Drawing.Size(99, 23);
            this.buttonCreateOrderProduct.TabIndex = 4;
            this.buttonCreateOrderProduct.Text = "Create product";
            this.buttonCreateOrderProduct.UseVisualStyleBackColor = true;
            this.buttonCreateOrderProduct.Click += new System.EventHandler(this.buttonCreateOrderProduct_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 430);
            this.Controls.Add(this.buttonCreateOrderProduct);
            this.Controls.Add(this.buttonUpdateOrderProduct);
            this.Controls.Add(this.buttonDeleteOrderProduct);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormOrder";
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDeleteOrderProduct;
        private System.Windows.Forms.Button buttonUpdateOrderProduct;
        private System.Windows.Forms.Button buttonCreateOrderProduct;
    }
}