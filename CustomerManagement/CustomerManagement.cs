using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation.CustomerManagement
{
    public partial class CustomerManagement : Form
    {
        private CustomerCRUD customerCrud;
        private Customer customer;
        public CustomerManagement()
        {
            InitializeComponent();
            customerCrud = new CustomerCRUD();
        }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            var list = customerCrud.GetCustomerList();
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("lastName", "LastName");

            foreach (var customer in list)
            {
                dgv.Rows.Add(customer);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                var selectedRow = dgv.SelectedRows[0];
                if (dgv.SelectedRows.Count != 0)
                    customer = new Customer()
                    {
                        ID = int.Parse(selectedRow.Cells[0].Value.ToString()),
                        Name = selectedRow.Cells[1].Value.ToString(),
                        LastName = selectedRow.Cells[2].Value.ToString(),
                    };
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.ShowDialog();
            FillDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                MessageBox.Show("You have to choose an Customer from list to edit!");
            }
            else
            {
                EditCustomer editCustomer = new EditCustomer(customer);
                editCustomer.ShowDialog();
                FillDataGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                MessageBox.Show("You have to choose an Customer from list to edit!");
            }
            else
            {
                DialogResult confirmation = MessageBox.Show($"Do you wanna delete Customer {customer.Name} {customer.LastName} ?", "Delete", MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    var result = customerCrud.DeleteCustomer(customer.ID);
                    if (result)
                    {
                        MessageBox.Show("Customer successfully deleted!");
                        FillDataGridView();
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
