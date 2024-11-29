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
    public partial class Form3 : Form
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            string query = "SELECT * FROM [Materials]";

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
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();
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
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Quantity"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
                textBox5.Text = row.Cells["ProductID"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\mebel0.1\\mebel0.1\\Database1.mdf;Integrated Security=True"; // Ваша строка подключения
            string ID = textBox1.Text;
            string Name = textBox2.Text;
            string Quantity = textBox3.Text;
            string Price = textBox4.Text;
            string ProductID = textBox5.Text;
   
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Quantity) || string.IsNullOrEmpty(Price) || string.IsNullOrEmpty(ProductID))
            {
                MessageBox.Show("Пожалуйста, заполните поля.");
                return;
            }

            string query = "INSERT INTO Materials (ID, Name, Quantity, Price, ProductID) VALUES (@ID, @Name, @Quantity, @Price, @ProductID)"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Материал успешно добавлен!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка при добавлении материала: " + ex.Message);
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
                MessageBox.Show("Выберите материал для удаления.");
                return;
            }

            string ID = textBox1.Text;

            string query = "DELETE FROM Materials WHERE ID = @ID";

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
                            MessageBox.Show("Материал успешно удалён.");
                        }
                        else
                        {
                            MessageBox.Show("Материал не найден.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении материала: " + ex.Message);
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
            string Name = textBox2.Text;
            string Quantity = textBox3.Text;
            string Price = textBox4.Text;
            string ProductID = textBox5.Text;


            string query = "Update Materials SET Name = @Name, Quantity = @Quantity, Price = @Price, ProductID = @ProductID WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@ProductID", ProductID);


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
