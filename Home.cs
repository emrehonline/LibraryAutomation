using LibraryAutomation.BookRental;
using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation
{
    public partial class Home : Form
    {
        private BookCRUD bookCrud;
        private AuthorCRUD authorCrud;
        private CustomerCRUD customerCrud;
        private RentCRUD rentCrud;

        public Home()
        {
            InitializeComponent();
            bookCrud = new BookCRUD();
            authorCrud = new AuthorCRUD();
            customerCrud = new CustomerCRUD();
            rentCrud = new RentCRUD();
        }

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            lblDGV.Text = "Books";
            var list = bookCrud.GetBookListByQuery();
            
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("author", "Author");

            foreach (var book in list)
            {
                dgv.Rows.Add(book);
            }
        }

        private void btnAllCustomers_Click(object sender, EventArgs e)
        {
            lblDGV.Text = "Customers";
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

        private void btnAllAuthors_Click(object sender, EventArgs e)
        {
            lblDGV.Text = "Authors";
            var list = authorCrud.GetAuthorList();

            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("lastName", "LastName");

            foreach (var author in list)
            {
                dgv.Rows.Add(author);
            }
        }

        private void btnManageAuthors_Click(object sender, EventArgs e)
        {
            AuthorManagement.AuthorManagement authorManagement = new AuthorManagement.AuthorManagement();
            this.Visible = false;
            authorManagement.ShowDialog();
            this.Visible = true;
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            BookManagement.BookManagement bookManagement = new BookManagement.BookManagement();
            this.Visible = false;
            bookManagement.ShowDialog(); 
            this.Visible = true;
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            CustomerManagement.CustomerManagement customerManagement = new CustomerManagement.CustomerManagement();
            this.Visible = false;
            customerManagement.ShowDialog();
            this.Visible = true;
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            BookRentalManagement bookRentalManagement = new BookRentalManagement();
            this.Visible = false;
            bookRentalManagement.ShowDialog();
            this.Visible = true;
        }

        private void btnRentedBooks_Click(object sender, EventArgs e)
        {
            lblDGV.Text = "Rented Books";
            var list = rentCrud.GetRentListByQuery();
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add("book", "Book");
            dgv.Columns.Add("customer", "Customer");
            dgv.Columns.Add("rentalDate", "RentalDate");
            dgv.Columns.Add("returnDate", "ReturnDate");

            foreach (var rent in list)
            {
                dgv.Rows.Add(rent);
            }
        }

        private void btnShowRentingGraph_Click(object sender, EventArgs e)
        {
            RentingGraph rentingGraph = new RentingGraph();
            rentingGraph.ShowDialog();
        }
    }
}
