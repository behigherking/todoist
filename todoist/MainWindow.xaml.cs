using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Page
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TaskTracker;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных в таблицы (Tasks, Projects, Users, Comments)
        private void LoadData()
        {
            LoadTasks();
            LoadProjects();
            LoadUsers();
            LoadComments();
        }

        private void LoadTasks()
        {
            string query = "SELECT * FROM Задачи";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                TasksDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void LoadProjects()
        {
            string query = "SELECT * FROM Проекты";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ProjectsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void LoadUsers()
        {
            string query = "SELECT * FROM Пользователи";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                UsersDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void LoadComments()
        {
            string query = "SELECT * FROM Комментарии";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                CommentsDataGrid.ItemsSource = dt.DefaultView;
            }
        }

        // Добавление задачи
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.ShowDialog();
            LoadTasks();
        }

        // Добавление проекта
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            var addProjectWindow = new AddProjectWindow();
            addProjectWindow.ShowDialog();
            LoadProjects();
        }

        // Добавление пользователя
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            LoadUsers();
        }

        // Добавление комментария
        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            var addCommentWindow = new AddCommentWindow();
            addCommentWindow.ShowDialog();
            LoadComments();
        }
    }
}