using LibraryAutomation.AuthorManagement;
using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation.BookManagement
{
    public partial class BookManagement : Form
    {
        private AuthorCRUD authorCrud;
        private BookCRUD bookCrud;
        private Book book;
        public BookManagement()
        {
            InitializeComponent();
            authorCrud = new AuthorCRUD();
            bookCrud = new BookCRUD();
        }

        private void AuthorManagement_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            var list = bookCrud.GetBookList();
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("authorId", "AuthorID");

            foreach (var author in list)
            {
                dgv.Rows.Add(author);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                var selectedRow = dgv.SelectedRows[0];
                if (dgv.SelectedRows.Count != 0)
                    book = new Book()
                    {
                        ID = int.Parse(selectedRow.Cells[0].Value.ToString()),
                        Name = selectedRow.Cells[1].Value.ToString(),
                        AuthorId = int.Parse(selectedRow.Cells[2].Value.ToString()),
                    };
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();
            FillDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (book == null)
            {
                MessageBox.Show("You have to choose an Book from list to edit!");
            }
            else
            {
                EditBook editBook = new EditBook(book);
                editBook.ShowDialog();
                FillDataGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (book == null)
            {
                MessageBox.Show("You have to choose an Book from list to edit!");
            }
            else
            {
                DialogResult confirmation = MessageBox.Show($"Do you wanna delete Book {book.Name} ?", "Delete", MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    var result = bookCrud.DeleteBook(book.ID);
                    if (result)
                    {
                        MessageBox.Show("Book successfully deleted!");
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
