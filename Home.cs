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

namespace LibraryAutomation
{
    public partial class Home : Form
    {
        private BookCRUD bookCrud;
        private AuthorCRUD authorCrud;

        public Home()
        {
            InitializeComponent();
            bookCrud = new BookCRUD();
            authorCrud = new AuthorCRUD();
        }

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            lblDGV.Text = "Books";
            var list = bookCrud.GetBookList();
            
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add("id", "ID");
            dgv.Columns.Add("name", "Name");
            dgv.Columns.Add("authorId", "AuthorID");

            foreach (var book in list)
            {
                dgv.Rows.Add(book);
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
    }
}
