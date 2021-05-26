using Core.Attributes;
using Core.Models.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

            driver.MoveToOrderProductPage = (context, order, orderProduct) =>
            {
                FormOrderProduct form = new FormOrderProduct(context, order, orderProduct);
                form.ShowDialog();
                LoadData();
            };
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<OrderProductView> list = driver.GetAllOrderProducts();
            dataGridView.DataSource = list;
            ConfigureDataGrid();
        }

        private void ConfigureDataGrid()
        {
            Type type = typeof(OrderProductView);

            foreach (PropertyInfo prop in type.GetProperties().Where(rec => rec.GetCustomAttributes<ColumnAttribute>().Count() > 0))
            {
                DataGridViewColumn column = null;
                foreach (DataGridViewColumn c in dataGridView.Columns)
                {
                    if (c.Name == prop.Name)
                    {
                        column = c;
                        break;
                    }
                }

                if (column != null)
                {
                    column.HeaderText = prop.GetCustomAttribute<ColumnAttribute>().Title;
                    column.Visible = prop.GetCustomAttribute<ColumnAttribute>().Visible;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (driver.SaveOrder())
            {
                Close();
            }
        }

        private void buttonCreateOrderProduct_Click(object sender, EventArgs e)
        {
            driver.AddOrderProduct();
        }

        private void buttonUpdateOrderProduct_Click(object sender, EventArgs e)
        {
            driver.UpdateOrderProduct();
        }

        private void buttonDeleteOrderProduct_Click(object sender, EventArgs e)
        {
            driver.DeleteOrderProduct();
            LoadData();
        }
    }
}
