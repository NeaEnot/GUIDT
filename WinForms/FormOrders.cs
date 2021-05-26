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
    public partial class FormOrders : Form
    {
        private OrdersPageDriver driver;

        public FormOrders(UiContext context)
        {
            InitializeComponent();

            driver = new OrdersPageDriver(context);

            ConfigureDriver();
        }

        private void ConfigureDriver()
        {
            driver.SelectedOrder = () =>
            {
                return (OrderView)dataGridView.SelectedRows[0].DataBoundItem;
            };

            driver.ShowInfoMessage = (msg) => { MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            driver.ShowErrorMessage = (msg) => { MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); };

            driver.MoveToOrderPage = (context, order) =>
            {
                FormOrder form = new FormOrder(context, order);
                form.ShowDialog();
                LoadData();
            };

            driver.MoveToProductsPage = (context) =>
            {
                FormProducts form = new FormProducts(context);
                form.ShowDialog();
                LoadData();
            };
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<OrderView> list = driver.GetAllOrders();
            dataGridView.DataSource = list;
            ConfigureDataGrid();
        }

        private void ConfigureDataGrid()
        {
            Type type = typeof(OrderView);

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

        private void buttonToProducts_Click(object sender, EventArgs e)
        {
            driver.ToProducts();
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            driver.DeleteOrder();
            LoadData();
        }

        private void buttonUpdateOrder_Click(object sender, EventArgs e)
        {
            driver.UpdateOrder();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            driver.AddOrder();
        }
    }
}
