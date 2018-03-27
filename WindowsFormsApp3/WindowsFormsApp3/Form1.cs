using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        OleDbConnection oleDbConnection;

        public Form1()
        {
            InitializeComponent();
        }



        private  void Form1_Load(object sender, EventArgs e)
        {
            string Kursach_YuraConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Юрий\source\repos\WindowsFormsApp3\WindowsFormsApp3\Kursach_Yura.mdb";
            oleDbConnection = new OleDbConnection(Kursach_YuraConnectionString);
            oleDbConnection.Open();
            OleDbDataReader oleDbReader = null;
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Оклад]", oleDbConnection);

            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter();
                sda.SelectCommand = command;
                DataTable data = new DataTable();
                sda.Fill(data);
                BindingSource binding = new BindingSource();
                binding.DataSource = data;
                dataGridView1.DataSource = binding;
                sda.Update(data);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (oleDbReader != null)
                    oleDbReader.Close();
            }
            oleDbConnection.Close();

        }



        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oleDbConnection != null && oleDbConnection.State != ConnectionState.Closed)
                oleDbConnection.Close();
                
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oleDbConnection != null && oleDbConnection.State != ConnectionState.Closed)
                oleDbConnection.Close();
        }



        private  void button1_Click(object sender, EventArgs e)
        {
            oleDbConnection.Open();
            int num = 0;
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)&&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                int.TryParse(textBox7.Text, out num)&& int.TryParse(textBox2.Text, out num))
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [Оклад] (Id, Должность, Оклад, Мост) VALUES (@Id, @Должность, @Оклад, @Мост)", oleDbConnection);
                command.Parameters.AddWithValue("@Id", textBox7.Text);
                command.Parameters.AddWithValue("@Должность", textBox1.Text);
                command.Parameters.AddWithValue("@Оклад", textBox2.Text);
                command.Parameters.AddWithValue("@Мост", textBox8.Text);


                command.ExecuteNonQuery(); 
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Заполните ВСЕ поля КОРРЕКТНЫМИ данными";
            }
            oleDbConnection.Close();
        }

        

        private  void button2_Click(object sender, EventArgs e)
        {
            oleDbConnection.Open();
            int num=0;
            if (label8.Visible)
                label8.Visible = false;
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)&&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)&&
                 int.TryParse(textBox5.Text, out num) && int.TryParse(textBox3.Text, out num))
            {
                OleDbCommand command = new OleDbCommand("UPDATE [Оклад] SET [Должность]=@Должность, [Оклад]=@Оклад, [Мост]=@Мост WHERE [Id]=@Id", oleDbConnection);

                
                command.Parameters.AddWithValue("@Должность", textBox4.Text);
                command.Parameters.AddWithValue("@Оклад", textBox3.Text);
                command.Parameters.AddWithValue("@Мост", textBox9.Text);
                command.Parameters.AddWithValue("@Id", textBox5.Text);        
                command.ExecuteNonQuery();
            }
            else 
            {
                label8.Visible = true;
                label8.Text = "ВСЕ поля должны быть заполнены КОРРЕКТНЫМИ данными";
            }
           
            oleDbConnection.Close();

        }




        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OleDbDataReader oleDbReader = null;
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Оклад]", oleDbConnection);

            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter();
                sda.SelectCommand = command;
                DataTable data = new DataTable();
                sda.Fill(data);
                BindingSource binding = new BindingSource();
                binding.DataSource = data;
                dataGridView1.DataSource = binding;
                sda.Update(data);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (oleDbReader != null)
                    oleDbReader.Close();
            }
            oleDbConnection.Close();
        }





        private  void button3_Click(object sender, EventArgs e)
        {
            oleDbConnection.Open();
            if (label8.Visible)
                label8.Visible = false;
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                OleDbCommand command = new OleDbCommand("DELETE FROM [Оклад] WHERE [Id]=@Id", oleDbConnection);
                command.Parameters.AddWithValue("Id", textBox6.Text);
                command.ExecuteNonQuery();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Id должен быть заполненным";
            }
            oleDbConnection.Close();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            oleDbConnection.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM [Оклад]", oleDbConnection);

            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter();
                sda.SelectCommand = command;
                DataTable data = new DataTable();
                BindingSource binding = new BindingSource();
                binding.DataSource = data;
                sda.Update(data);

                DataSet ds = new DataSet("New dataset");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                sda.Fill(data);
                ds.Tables.Add(data);
                ExcelLibrary.DataSetHelper.CreateWorkbook("My ExcelFile.xls", ds);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            oleDbConnection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            chart1.Update();
            chart1.Series[0].Points.Clear();

            try
            {
                oleDbConnection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = oleDbConnection;
                string query = "SELECT * FROM Оклад ";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chart1.Series["Оклад"].Points.AddXY(reader["Должность"].ToString(), reader["Оклад"].ToString());
                }

                
                oleDbConnection.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
