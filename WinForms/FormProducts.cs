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

            driver.MoveToProductPage = (context, product) =>
            {
                FormProduct form = new FormProduct(context, product);
                form.ShowDialog();
                LoadData();
            };
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
            Type type = typeof(ProductView);

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
            LoadData();
        }
    }
}
