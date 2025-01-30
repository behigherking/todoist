using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace todoist
{
    public partial class AddTaskWindow : Window
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskTracker;Integrated Security=True";

        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskName.Text;
            string taskDescription = TaskDescription.Text;
            string taskStatus = ((ComboBoxItem)TaskStatus.SelectedItem).Content.ToString();

            string query = "INSERT INTO Задачи (Название, Описание, Статус) VALUES (@Название, @Описание, @Статус)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Название", taskName);
                cmd.Parameters.AddWithValue("@Описание", taskDescription);
                cmd.Parameters.AddWithValue("@Статус", taskStatus);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Задача добавлена!");
                this.Close();
            }
        }
    }
}