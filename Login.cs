﻿using LibraryAutomation.Helpers;
using Microsoft.Win32;
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
    public partial class Login : Form
    {
        private UserCRUD userCrud;
        public Login()
        {
            InitializeComponent();
            userCrud = new UserCRUD();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            this.Visible = false;
            register.ShowDialog();
            this.Visible = true;
        }

        private void linkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPass forgotPass = new ForgotPass();
            this.Visible = false;
            forgotPass.ShowDialog();
            this.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or Password can not be empty!");
            }
            else
            {
                if (!userCrud.Login(userName, password))
                {
                    MessageBox.Show("Username or Password is wrong!");
                }
                else
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                    this.Close();
                }
            }

        }
    }
}
