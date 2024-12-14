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

        public Home()
        {
            InitializeComponent();
            bookCrud = new BookCRUD();
        }

        private void btnAllBooks_Click(object sender, EventArgs e)
        {
            var list = bookCrud.GetBookList();

            dgvBooks.Columns.Add("id", "ID");
            dgvBooks.Columns.Add("name", "Name");
            dgvBooks.Columns.Add("authorId", "AuthorID");

            foreach (var book in list)
            {
                dgvBooks.Rows.Add(book);
            }
        }
    }
}
