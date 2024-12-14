using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation.BookRental
{
    public partial class BookRentalManagement : Form
    {
        private RentCRUD rentCrud;
        public BookRentalManagement()
        {
            InitializeComponent();
            rentCrud = new RentCRUD();
        }

        private void BookRentalManagement_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RentBook rentBook = new RentBook();
            rentBook.ShowDialog();
            FillDataGridView();
        }  
    }
}
