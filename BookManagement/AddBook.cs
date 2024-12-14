using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryAutomation.BookManagement
{
    public partial class AddBook : Form
    {
        private readonly BookCRUD bookCRUD;
        private readonly AuthorCRUD authorCRUD;
        private readonly List<Author> authors;
        public AddBook()
        {
            InitializeComponent();
            bookCRUD = new BookCRUD();
            authorCRUD = new AuthorCRUD();

            authors = authorCRUD.GetFormattedAuthorList();
            foreach (var author in authors)
            {
                dropDownAuthors.Items.Add($"{author.ID}: {author.Name} {author.LastName}");
            }
            
            dropDownAuthors.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int authorId = int.Parse(dropDownAuthors.SelectedItem.ToString().Split(':')[0]);

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Book Name can not be empty!");
            }
            else
            {
                if (bookCRUD.CheckIfBookExist(name, authorId))
                {
                    MessageBox.Show("Book already exist!");
                }
                else
                {
                    bool result = bookCRUD.CreateBook(name, authorId);

                    if (result)
                    {
                        MessageBox.Show("Book successfully created!");
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
