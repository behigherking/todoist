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
    public partial class AddCommentWindow : Window
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskTracker;Integrated Security=True";

        public AddCommentWindow()
        {
            InitializeComponent();
        }

        // Сохранить комментарий
        private void SaveComment_Click(object sender, RoutedEventArgs e)
        {
            string commentText = CommentText.Text;

            string query = "INSERT INTO Комментарии (Текст) VALUES (@Текст)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Текст", commentText);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Комментарий добавлен!");
                this.Close();
            }
        }
    }
}