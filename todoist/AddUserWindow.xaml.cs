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
    public partial class AddUserWindow : Window
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskTracker;Integrated Security=True";

        public AddUserWindow()
        {
            InitializeComponent();
        }

        // Сохранить пользователя
        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserName.Text;
            string userEmail = UserEmail.Text;

            string query = "INSERT INTO Пользователи (Имя, Почта) VALUES (@Имя, @Почта)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Имя", userName);
                cmd.Parameters.AddWithValue("@Почта", userEmail);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Пользователь добавлен!");
                this.Close();
            }
        }
    }
}