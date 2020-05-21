using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Form1 : Form
    {
        
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kursovoymdb.mdb;";
        
        
        private OleDbConnection myConnection;




        public Form1()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);

            myConnection.Open();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();   
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id, Name, F, M, BS, CH, Data, dedData FROM BD ORDER BY id";

        
            OleDbCommand command = new OleDbCommand(query, myConnection);
                
         
            OleDbDataReader reader = command.ExecuteReader();

           
            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add("ID= " + reader[0].ToString() + " " + reader[1].ToString());
                if (reader[2].ToString() !="") listBox1.Items.Add(" Отец: " + reader[2].ToString()); 
                if (reader[3].ToString() !="") listBox1.Items.Add(" Мать: " + reader[3].ToString());
                if (reader[4].ToString() !="") listBox1.Items.Add(" Братья и Сестры: " + reader[4].ToString());
                if (reader[5].ToString() !="") listBox1.Items.Add(" Дети:" + reader[5].ToString());
                if (reader[6].ToString() !="") listBox1.Items.Add(" Дата рождения " + reader[6].ToString());
                if (reader[7].ToString() !="") listBox1.Items.Add(" Дата смерти " + reader[7].ToString());

            }

           
            reader.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            string query = "SELECT Name FROM BD WHERE id = " + textBox1.Text;

           
            OleDbCommand command = new OleDbCommand(query, myConnection);

          
            textBox2.Text = command.ExecuteScalar().ToString();


        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM BD WHERE id =" + textBox1.Text;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Информация удалена");
        }   

        private void Button4_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
