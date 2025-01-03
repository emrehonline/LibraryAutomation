﻿using LibraryAutomation.Helpers;
using System;
using System.Windows.Forms;

namespace LibraryAutomation.Authentication
{
    public partial class Register : Form
    {
        private UserCRUD userCrud;
        public Register()
        {
            InitializeComponent();
            userCrud = new UserCRUD();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or Password can not be empty!");
            }
            else
            {
                if (userCrud.CheckIfUserExist(userName))
                {
                    MessageBox.Show("User already exist!");
                }
                else
                {
                    bool result = userCrud.CreateUser(userName, password);

                    if (result)
                        MessageBox.Show("User successfully created!");
                    else
                        MessageBox.Show("Process failed, Please try again!");
                }
            }

        }
    }
}
