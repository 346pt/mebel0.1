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
    public partial class Form1 : Form
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            string query = "SELECT * FROM [Products]";

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


            string ID = textBox1.Text;
            string Name = textBox2.Text;
            string Quantity = textBox3.Text;
            string Price = textBox4.Text;
            string orderNumber = textBox5.Text;


            string query = "Update Products SET Name = @Name, Quantity = @Quantity, Price = @Price, OrderNumber = @orderNumber WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@OrderNumber", orderNumber);


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ID"].Value.ToString(); 
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                textBox5.Text = row.Cells["OrderNumber"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Выберите продукцию для удаления.");
                return;
            }

            string ID = textBox1.Text;

            string query = "DELETE FROM Products WHERE ID = @ID";

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
                            MessageBox.Show("Продукция успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Продукция не найдена.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении продукции: " + ex.Message);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True"; // Ваша строка подключения
            string ID = textBox1.Text;
            string Name = textBox2.Text;
            string Quantity = textBox3.Text;
            string Price = textBox4.Text;
            string orderNumber = textBox5.Text;

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Quantity) || string.IsNullOrEmpty(Price) || string.IsNullOrEmpty(orderNumber))
            {
                MessageBox.Show("Пожалуйста, заполните поля.");
                return;
            }

            string query = "INSERT INTO Products (ID, Name, Quantity, Price, OrderNumber) VALUES (@ID, @Name, @Quantity, @Price, @orderNumber)"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@OrderNumber", orderNumber);
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
            textBox5.Clear();
        }
    }
}
