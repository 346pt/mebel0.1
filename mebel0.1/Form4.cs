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

namespace mebel0._1
{
    public partial class Form4 : Form
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            string query = "SELECT * FROM [Orders]";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ID"].Value.ToString(); 
                textBox2.Text = row.Cells["OrderNumber"].Value.ToString();
                textBox3.Text = row.Cells["Structure"].Value.ToString();
                textBox4.Text = row.Cells["DataOfRealization"].Value.ToString();
                textBox5.Text = row.Cells["ClientID"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True"; // Ваша строка подключения
            string ID = textBox1.Text;
            string OrderNumber = textBox2.Text;
            string Structure = textBox3.Text;
            string DataOfRealization = textBox4.Text;
            string ClientID = textBox5.Text;

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(OrderNumber) || string.IsNullOrEmpty(Structure) || string.IsNullOrEmpty(DataOfRealization) || string.IsNullOrEmpty(ClientID))
            {
                MessageBox.Show("Пожалуйста, заполните поля.");
                return;
            }

            string query = "INSERT INTO Orders (ID, OrderNumber, Structure, DataOfRealization, ClientID) VALUES (@ID, OrderNumber, @Structure, @DataOfRealization, @ClientID)"; // Замените на ваши поля

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                    command.Parameters.AddWithValue("@Structure", Structure);
                    command.Parameters.AddWithValue("@DataOfRealization", DataOfRealization);
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Заказ успешно добавлен!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка при добавлении заказа: " + ex.Message);
                    }
                }
            }
            LoadData();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Выберите заказ для удаления.");
                return;
            }

            string ID = textBox1.Text;

            string query = "DELETE FROM Orders WHERE ID = @ID";

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
                            MessageBox.Show("Заказ успешно удалён.");
                        }
                        else
                        {
                            MessageBox.Show("Заказ не найден.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении заказа: " + ex.Message);
                    }
                }
            }
            LoadData();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string OrderNumber = textBox2.Text;
            string Structure = textBox3.Text;
            string DataOfRealization = textBox4.Text;
            string ClientID = textBox5.Text;


            string query = "Update Orders SET OrderNumber = @OrderNumber, Structure = @Structure, DataOfRealization = @DataOfRealization, ClientID = @ClientID WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                    command.Parameters.AddWithValue("@Structure", Structure);
                    command.Parameters.AddWithValue("@DataOfRealization", DataOfRealization);
                    command.Parameters.AddWithValue("@ClientID", ClientID);


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
    }
}
