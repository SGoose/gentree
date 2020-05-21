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
    public partial class Form3 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=kursovoymdb.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kursovoymdb.mdb;";

        private OleDbConnection myConnection;
        public Form3()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "") return;
            bool T = false;
            string str = "UPDATE BD SET ";
            if(textBox1.Text!="") 
            {
                str += "Name = '" + textBox1.Text + "'";
                T = true;
            }
            if (textBox2.Text != "") 
            {
                
                str += T ? ", " : " ";
                str += "F = '" + textBox2.Text + "' ";
                T = true;
            }

            if (textBox3.Text != "")
            {
                str += T ? "," : "";
                str += "M = '" + textBox3.Text + "' ";
                T = true;

            }
            if (textBox4.Text != "") 
            {
                str += T ? "," : "";
                str += "BS = '" + textBox4.Text + "' ";
                T = true;
            }
            if (textBox5.Text != "") 
            {
                str += T ? "," : "";
                str += "CH = '" + textBox5.Text + "' ";
                T = true;
            }
            if (textBox5.Text != "")
            {
                str += T ? "," : "";
                str += "Data = '" + textBox7.Text + "' ";
                T = true;
            }
            if (textBox5.Text != "")
            {
                str += T ? "," : "";
                str += "dedData = '" + textBox8.Text + "' ";
          
            }

            str += "WHERE id = " + textBox6.Text;
            OleDbCommand command = new OleDbCommand(str, myConnection);
            command.ExecuteNonQuery();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
