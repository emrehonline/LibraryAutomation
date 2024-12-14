using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryAutomation.CustomerManagement
{
    public partial class EditCustomer : Form
    {
        private Customer customer;
        private CustomerCRUD customerCRUD;
        public EditCustomer(Customer customer)
        {
            InitializeComponent();
            customerCRUD = new CustomerCRUD();

            this.customer = customer;
            txtName.Text = customer.Name;
            txtLastName.Text = customer.LastName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Customer Name or Last Name can not be empty!");
            }
            else
            {
                customer.Name = txtName.Text;
                customer.LastName = txtLastName.Text;
                var result = customerCRUD.UpdateCustomer(customer);

                if (result)
                {
                    MessageBox.Show("Customer Successfully Edited!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Process failed, Please try again!");
                }
            }
        }
    }
}
