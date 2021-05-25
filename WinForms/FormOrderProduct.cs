using Core.Models.View;
using System;
using System.Windows.Forms;
using UiDriver;

namespace WinForms
{
    public partial class FormOrderProduct : Form
    {
        private OrderProductPageDriver driver;

        public FormOrderProduct(UiContext context, OrderView order, OrderProductView orderProduct)
        {
            InitializeComponent();

            driver = new OrderProductPageDriver(context, order, orderProduct);

            ConfigureDriver();
        }

        private void ConfigureDriver()
        {
            driver.SelectedProduct = () =>
            {
                return (ProductView)comboBox.SelectedItem;
            };

            driver.Count = () =>
            {
                return int.Parse(textBox.Text);
            };

            driver.ShowInfoMessage = (msg) => { MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            driver.ShowErrorMessage = (msg) => { MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }

        private void FormOrderProduct_Load(object sender, EventArgs e)
        {
            comboBox.Items.AddRange(driver.GetAllProducts().ToArray());

            ProductView selected = driver.GetSelectedProduct();
            if (selected != null)
            {
                comboBox.SelectedItem = selected;
            }
        }

        private void ChangeSum(object sender, EventArgs e)
        {
            labelSum.Text = "Sum: " + driver.GetSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (driver.SaveOrderProduct())
            {
                Close();
            }
        }
    }
}
