using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        private OleDbConnection oleDbConnection = new OleDbConnection();
        public Form2()
        {
            InitializeComponent();
            oleDbConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Юрий\source\repos\WindowsFormsApp3\WindowsFormsApp3\Kursach_Yura.mdb;
            Persist Security Info =False;"; 
           
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            oleDbConnection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = oleDbConnection;
            command.CommandText = "SELECT * FROM Вход WHERE Логин= '" + txt_UserName.Text + "' AND Пароль='" + txt_Password.Text + "'";
            OleDbDataReader reader= command.ExecuteReader();
            int count = 0;

            while(reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
                MessageBox.Show("Successful entry");
                oleDbConnection.Close();
                oleDbConnection.Dispose();
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show("No");
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
            oleDbConnection.Close();
        }
    }
}
