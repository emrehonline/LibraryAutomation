using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryAutomation.AuthorManagement
{
    public partial class EditAuthor : Form
    {
        private Author author;
        private AuthorCRUD authorCRUD;
        public EditAuthor(Author author)
        {
            InitializeComponent();
            authorCRUD = new AuthorCRUD();

            this.author = author;
            txtName.Text = author.Name;
            txtLastName.Text = author.LastName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Author Name or Last Name can not be empty!");
            }
            else
            {
                author.Name = txtName.Text;
                author.LastName = txtLastName.Text;
                var result = authorCRUD.UpdateAuthor(author);

                if (result)
                {
                    MessageBox.Show("Author Successfully Edited!");
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
