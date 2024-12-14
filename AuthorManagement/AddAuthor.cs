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

namespace LibraryAutomation.AuthorManagement
{
    public partial class AddAuthor : Form
    {
        private readonly AuthorCRUD authorCrud;
        public AddAuthor()
        {
            InitializeComponent();
            authorCrud = new AuthorCRUD();  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string lastName = txtLastName.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Author Name or Last Name can not be empty!");
            }
            else
            {
                if (authorCrud.CheckIfAuthorExist(name, lastName))
                {
                    MessageBox.Show("Author already exist!");
                }
                else
                {
                    bool result = authorCrud.CreateAuthor(name, lastName);

                    if (result)
                        MessageBox.Show("Author successfully created!");
                    else
                        MessageBox.Show("Process failed, Please try again!");
                }
            }
        }
    }
}
