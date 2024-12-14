using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation.Authentication
{
    public partial class ForgotPass : Form
    {
        private UserCRUD userCrud;
        public ForgotPass()
        {
            InitializeComponent();
            userCrud = new UserCRUD();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or Password can not be empty!");
            }
            else
            {
                if (!userCrud.CheckIfUserExist(userName))
                {
                    MessageBox.Show("User does not exist!");
                }
                else
                {
                    bool result = userCrud.ResetPassword(userName, password);

                    if (result)
                        MessageBox.Show("Password successfully changed!");
                    else
                        MessageBox.Show("Process failed, Please try again!");
                }

            }


        }
    }
}
