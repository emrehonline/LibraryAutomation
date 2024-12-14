using LibraryAutomation.Entities;
using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation.AuthorManagement
{
    public partial class AuthorManagement : Form
    {
        private AuthorCRUD authorCrud;
        private Author author;
        public AuthorManagement()
        {
            InitializeComponent();
            authorCrud = new AuthorCRUD();
        }

        private void AuthorManagement_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
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

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                var selectedRow = dgv.SelectedRows[0];
                if (dgv.SelectedRows.Count != 0)
                    author = new Author()
                    {
                        ID = int.Parse(selectedRow.Cells[0].Value.ToString()),
                        Name = selectedRow.Cells[1].Value.ToString(),
                        LastName = selectedRow.Cells[2].Value.ToString(),
                    };
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAuthor addAuthor = new AddAuthor();
            addAuthor.ShowDialog();
            FillDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (author == null)
            {
                MessageBox.Show("You have to choose an Author from list to edit!");
            }
            else
            {
                EditAuthor editAuthor = new EditAuthor(author);
                editAuthor.ShowDialog();
                FillDataGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (author == null)
            {
                MessageBox.Show("You have to choose an Author from list to edit!");
            }
            else
            {
                DialogResult confirmation = MessageBox.Show($"Do you wanna delete Author {author.Name} {author.LastName} ?", "Delete", MessageBoxButtons.YesNo);

                if (confirmation == DialogResult.Yes)
                {
                    var result = authorCrud.DeleteAuthor(author.ID);
                    if (result)
                    {
                        MessageBox.Show("Author successfully deleted!");
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
