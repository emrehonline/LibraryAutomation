using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation.CustomerManagement
{
    public partial class AddCustomer : Form
    {
        private readonly CustomerCRUD customerCrud;
        public AddCustomer()
        {
            InitializeComponent();
            customerCrud = new CustomerCRUD();  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastName.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Customer Name or Last Name can not be empty!");
            }
            else
            {
                if (customerCrud.CheckIfCustomerExist(name, lastName))
                {
                    MessageBox.Show("Customer already exist!");
                }
                else
                {
                    bool result = customerCrud.CreateCustomer(name, lastName);

                    if (result)
                    {
                        MessageBox.Show("Customer successfully created!");
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
}
