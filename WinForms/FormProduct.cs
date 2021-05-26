using Core.Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UiDriver;

namespace WinForms
{
    public partial class FormProduct : Form
    {
        private ProductPageDriver driver;

        public FormProduct(UiContext context, ProductView product)
        {
            InitializeComponent();

            driver = new ProductPageDriver(context, product);

            ConfigureDriver();
        }

        private void ConfigureDriver()
        {
            driver.ProductName = () =>
            {
                return textBoxName.Text;
            };
            driver.ProductPrice = () =>
            {
                return int.Parse(textBoxPrice.Text);
            };

            driver.ShowInfoMessage = (msg) => { MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            driver.ShowErrorMessage = (msg) => { MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            textBoxName.Text = driver.GetName();
            textBoxPrice.Text = driver.GetPrice().ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (driver.SaveProduct())
            {
                Close();
            }
        }
    }
}
