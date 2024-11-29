using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mebel0._1
{
    public partial class Form6 : Form
    {
        private string correctUsername = "USER";
        private string correctPassword = "Babadzaki";
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == correctUsername && password == correctPassword)
            {
                MessageBox.Show("Вход выполнен успешно");
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
