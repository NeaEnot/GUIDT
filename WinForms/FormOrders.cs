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
        private UiContext context;
        private OrdersPageDriver driver;

        public FormOrders(UiContext context)
        {
            InitializeComponent();

            this.context = context;
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

            driver.MoveToOrderPage = null;
            driver.MoveToProductsPage = null;
        }

        private void ConfigureDataGrid()
        {
            dataGridView.Columns.Clear();

            Type type = typeof(OrderView);

            foreach (PropertyInfo prop in type.GetProperties().Where(rec => rec.GetCustomAttributes<ColumnAttribute>().Count() > 0))
            {
                dataGridView.Columns.Add(prop.Name, prop.GetCustomAttribute<ColumnAttribute>().Title);
                dataGridView.Columns[dataGridView.Columns.Count - 1].Visible = prop.GetCustomAttribute<ColumnAttribute>().Visible;
            }
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

        private void buttonToProducts_Click(object sender, EventArgs e)
        {
            driver.ToProducts();
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            driver.UpdateOrder();
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
