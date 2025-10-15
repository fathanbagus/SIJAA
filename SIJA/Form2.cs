﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIJA
{
    public partial class FormMain : Form
    {
        string name;
        public FormMain(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Welcome, {name}!";
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            Hide();
        }
        private void btnMasterTeacher_Click(object sender, EventArgs e)
        {
            new FormMasterTeacher().Show();
            Hide();
        }
        private void btnMasterStudent_Click(object sender, EventArgs e) 
        {
            new FormMasterStudent().Show();
            Hide();
            
        }
    }
}
