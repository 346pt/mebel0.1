using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mebel0._1
{
    public partial class Form2 : Form
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            string query = "SELECT * FROM [Clients]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button1_click(object sender, EventArgs e)
        {

        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True"; // Ваша строка подключения
            string ID = textBox1.Text;
            string FIO = textBox2.Text;
            string clientAdress = textBox3.Text;
            string orderNumber = textBox4.Text;

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(FIO) || string.IsNullOrEmpty(clientAdress) || string.IsNullOrEmpty(orderNumber))
            {
                MessageBox.Show("Пожалуйста, заполните поля.");
                return;
            }

            string query = "INSERT INTO Clients (ID, FIO, clientAdress, orderNumber) VALUES (@ID, @FIO, @clientAdress, @orderNumber)"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@FIO", FIO);
                    command.Parameters.AddWithValue("@clientAdress", clientAdress);
                    command.Parameters.AddWithValue("@orderNumber", orderNumber);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Продукция успешно добавлена!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка при добавлении продукции: " + ex.Message);
                    }
                }
            }
            LoadData();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Выберите клиента для удаления.");
                return;
            }

            string ID = textBox1.Text;

            string query = "DELETE FROM Clients WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery(); 

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Клиент успешно удалён.");
                        }
                        else
                        {
                            MessageBox.Show("Клиент не найден.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении клиента: " + ex.Message);
                    }
                }
            }
            LoadData();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string FIO = textBox2.Text;
            string clientAdress = textBox3.Text;
            string orderNumber = textBox4.Text;


            string query = "Update Products SET FIO = @FIO, clientAdress = @clientAdress, orderNumber = @orderNumber WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@FIO", FIO);
                    command.Parameters.AddWithValue("@clientAdress", clientAdress);
                    command.Parameters.AddWithValue("@orderNumber", orderNumber);


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery(); 
                        MessageBox.Show("Данные успешно обновлены!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
                    }
                }
            }

            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ID"].Value.ToString(); 
                textBox2.Text = row.Cells["FIO"].Value.ToString();
                textBox3.Text = row.Cells["clientAdress"].Value.ToString();
                textBox4.Text = row.Cells["orderNumber"].Value.ToString();
            }
        }

        private void продукцияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void материалыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void заказыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void поставщикиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }
    }
}
