﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonCancelReg_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSelectReg_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(Properties.Settings.Default.TestsConnectionString);
            SqlCommand command = new SqlCommand(string.Format("insert into users(Name,SurName,Login,Password,Role) values('{0}','{1}','{2}','{3}',1)",textBoxNameReg.Text,textBoxSurnameReg.Text,textBoxLoginReg.Text,textBoxPasswordReg.Text), connect);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Регистрация прошла успешно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                MessageBox.Show("При регистрации возникла ошибка!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

    }
}
