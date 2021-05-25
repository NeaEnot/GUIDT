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
    public partial class FormOrder : Form
    {
        private OrderPageDriver driver;

        public FormOrder(UiContext context, OrderView order)
        {
            InitializeComponent();

            driver = new OrderPageDriver(context, order);

            ConfigureDriver();
        }

        private void ConfigureDriver()
        {
            driver.SelectedOrderProduct = () =>
            {
                return (OrderProductView)dataGridView.SelectedRows[0].DataBoundItem;
            };

            driver.ShowInfoMessage = (msg) => { MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            driver.ShowErrorMessage = (msg) => { MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); };

            driver.MoveToOrderProductPage = null;
        }
    }
}
