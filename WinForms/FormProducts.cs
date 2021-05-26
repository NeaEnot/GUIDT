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
    public partial class FormProducts : Form
    {
        private ProductsPageDriver driver;

        public FormProducts(UiContext context)
        {
            InitializeComponent();

            driver = new ProductsPageDriver(context);

            ConfigureDriver();
        }

        private void ConfigureDriver()
        {

        }
    }
}
