
namespace WinForms
{
    partial class FormOrderProduct
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelSum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(13, 13);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(211, 23);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectionChangeCommitted += new System.EventHandler(this.ChangeSum);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(13, 43);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(211, 23);
            this.textBox.TabIndex = 1;
            this.textBox.TextChanged += new System.EventHandler(this.ChangeSum);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(82, 108);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(13, 73);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(37, 15);
            this.labelSum.TabIndex = 3;
            this.labelSum.Text = "Sum: ";
            // 
            // FormOrderProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 143);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.comboBox);
            this.Name = "FormOrderProduct";
            this.Text = "FormOrderProduct";
            this.Load += new System.EventHandler(this.FormOrderProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSum;
    }
}