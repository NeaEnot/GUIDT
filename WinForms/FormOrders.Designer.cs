
namespace WinForms
{
    partial class FormOrders
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
            this.buttonToProducts = new System.Windows.Forms.Button();
            this.buttonDeleteOrder = new System.Windows.Forms.Button();
            this.buttonUpdateOrder = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(641, 310);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonToProducts
            // 
            this.buttonToProducts.Location = new System.Drawing.Point(12, 344);
            this.buttonToProducts.Name = "buttonToProducts";
            this.buttonToProducts.Size = new System.Drawing.Size(86, 23);
            this.buttonToProducts.TabIndex = 1;
            this.buttonToProducts.Text = "To products";
            this.buttonToProducts.UseVisualStyleBackColor = true;
            this.buttonToProducts.Click += new System.EventHandler(this.buttonToProducts_Click);
            // 
            // buttonDeleteOrder
            // 
            this.buttonDeleteOrder.Location = new System.Drawing.Point(570, 344);
            this.buttonDeleteOrder.Name = "buttonDeleteOrder";
            this.buttonDeleteOrder.Size = new System.Drawing.Size(82, 23);
            this.buttonDeleteOrder.TabIndex = 2;
            this.buttonDeleteOrder.Text = "Delete order";
            this.buttonDeleteOrder.UseVisualStyleBackColor = true;
            this.buttonDeleteOrder.Click += new System.EventHandler(this.buttonDeleteOrder_Click);
            // 
            // buttonUpdateOrder
            // 
            this.buttonUpdateOrder.Location = new System.Drawing.Point(479, 344);
            this.buttonUpdateOrder.Name = "buttonUpdateOrder";
            this.buttonUpdateOrder.Size = new System.Drawing.Size(85, 23);
            this.buttonUpdateOrder.TabIndex = 3;
            this.buttonUpdateOrder.Text = "Update order";
            this.buttonUpdateOrder.UseVisualStyleBackColor = true;
            this.buttonUpdateOrder.Click += new System.EventHandler(this.buttonUpdateOrder_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(392, 344);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(81, 23);
            this.buttonCreateOrder.TabIndex = 4;
            this.buttonCreateOrder.Text = "Create order";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // FormOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 376);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.buttonUpdateOrder);
            this.Controls.Add(this.buttonDeleteOrder);
            this.Controls.Add(this.buttonToProducts);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormOrders";
            this.Text = "FormOrders";
            this.Load += new System.EventHandler(this.FormOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonToProducts;
        private System.Windows.Forms.Button buttonDeleteOrder;
        private System.Windows.Forms.Button buttonUpdateOrder;
        private System.Windows.Forms.Button buttonCreateOrder;
    }
}