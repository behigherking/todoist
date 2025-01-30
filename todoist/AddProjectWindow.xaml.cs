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
    public partial class AddProjectWindow : Window
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskTracker;Integrated Security=True";

        public AddProjectWindow()
        {
            InitializeComponent();
        }

        // Сохранить проект
        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            string projectName = ProjectName.Text;
            string projectDescription = ProjectDescription.Text;

            string query = "INSERT INTO Проекты (Название, Описание) VALUES (@Название, @Описание)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Название", projectName);
                cmd.Parameters.AddWithValue("@Описание", projectDescription);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Проект добавлен!");
                this.Close();
            }
        }
    }
}