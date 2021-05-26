using Core.Attributes;
using Core.Models.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            driver.SelectedProduct = () =>
            {
                return (ProductView)dataGridView.SelectedRows[0].DataBoundItem;
            };

            driver.ShowInfoMessage = (msg) => { MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            driver.ShowErrorMessage = (msg) => { MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); };

            driver.MoveToProductPage = null;
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<ProductView> list = driver.GetAllProducts();
            dataGridView.DataSource = list;
            ConfigureDataGrid();
        }

        private void ConfigureDataGrid()
        {
            dataGridView.Columns.Clear();

            Type type = typeof(ProductView);

            foreach (PropertyInfo prop in type.GetProperties().Where(rec => rec.GetCustomAttributes<ColumnAttribute>().Count() > 0))
            {
                dataGridView.Columns.Add(prop.Name, prop.GetCustomAttribute<ColumnAttribute>().Title);
                dataGridView.Columns[dataGridView.Columns.Count - 1].Visible = prop.GetCustomAttribute<ColumnAttribute>().Visible;
            }
        }

        private void buttonCreateProduct_Click(object sender, EventArgs e)
        {
            driver.AddProduct();
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            driver.UpdateProduct();
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            driver.DeleteProduct();
        }
    }
}
