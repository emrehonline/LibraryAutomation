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
    public partial class EditBook : Form
    {
        private readonly Book book;
        private readonly BookCRUD bookCRUD;
        private readonly AuthorCRUD authorCrud;
        private readonly List<Author> authors;
        public EditBook(Book book)
        {
            InitializeComponent();
            this.book = book;
            txtName.Text = book.Name;

            bookCRUD = new BookCRUD();
            authorCrud = new AuthorCRUD();

            authors = authorCrud.GetFormattedAuthorList();
            foreach (var author in authors)
            {
                dropDownAuthors.Items.Add($"{author.ID}: {author.Name} {author.LastName}");
            }
            var authorData = authors.FirstOrDefault(x => x.ID.Equals(book.AuthorId));
            var authorIndex = dropDownAuthors.Items.IndexOf($"{authorData.ID}: {authorData.Name} {authorData.LastName}");
            dropDownAuthors.SelectedIndex = authorIndex;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            book.Name = txtName.Text;
            var result = bookCRUD.UpdateBook(book);

            if (result)
            {
                MessageBox.Show("Book Successfully Edited!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Process failed, Please try again!");
            }
        }

        private void EditBook_Load(object sender, EventArgs e)
        {

        }

        private void dropDownAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownAuthors.SelectedIndex >= 0)
                book.AuthorId = int.Parse(dropDownAuthors.SelectedItem.ToString().Split(':')[0]);
        }
    }
}
