using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryAutomation.BookRental
{
    public partial class RentBook : Form
    {
        private readonly BookCRUD bookCRUD;
        private readonly CustomerCRUD customerCRUD;
        private readonly RentCRUD rentCRUD;
        private readonly List<Customer> customers;
        private readonly List<Book> books;

        private Book selectedBook = new Book();
        private Customer selectedCustomer = new Customer();

        public RentBook()
        {
            InitializeComponent();
            bookCRUD = new BookCRUD();
            customerCRUD = new CustomerCRUD();
            rentCRUD = new RentCRUD();

            customers = customerCRUD.GetFormattedCustomerList();
            foreach (var customer in customers)
            {
                dropDownCustomers.Items.Add($"{customer.ID}: {customer.Name} {customer.LastName}");
            }
            if (customers.Count > 0)
                dropDownCustomers.SelectedIndex = 0;

            books = bookCRUD.GetFormattedBookList();
            foreach (var book in books)
            {
                dropDownBooks.Items.Add($"{book.ID}: {book.Name}");
            }
            if (books.Count > 0)
                dropDownBooks.SelectedIndex = 0;
        }

        private void dropDownCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownCustomers.Items.Count > 0 && dropDownCustomers.SelectedIndex >= 0)
                selectedCustomer.ID = int.Parse(dropDownCustomers.SelectedItem.ToString().Split(':')[0]);
        }

        private void dropDownBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownBooks.Items.Count > 0 && dropDownBooks.SelectedIndex >= 0)
                selectedBook.ID = int.Parse(dropDownBooks.SelectedItem.ToString().Split(':')[0]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedBook.ID == 0 || selectedCustomer.ID == 0)
            {
                MessageBox.Show("You have to choose Book and Customer to rent!");
            }
            else if (dtpRentDate.Value.Date > dtpReturnDate.Value.Date)
            {
                MessageBox.Show("You cannot select a date earlier than the Rental Date as the Return Date.!");
            }
            else if (rentCRUD.CheckIfBookRented(selectedBook.ID, selectedCustomer.ID))
            {
                MessageBox.Show("Book already Rented by this customer exist!");
            }
            else
            {
                var rentedDate = dtpRentDate.Value.Date.ToString("dd-MM-yyyy");
                var returnDate = dtpReturnDate.Value.Date.ToString("dd-MM-yyyy");
                bool result = rentCRUD.CreateRent(selectedBook.ID, selectedCustomer.ID, rentedDate, returnDate);

                if (result)
                {
                    MessageBox.Show("Book successfully rented!");
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
