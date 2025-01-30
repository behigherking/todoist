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
        private Entities _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new Entities();

            // Загружаем данные в ListView
            LoadTasks();
            LoadProjects();
            LoadUsers();
            LoadComments();
        }

        private void LoadTasks()
        {
            // Загрузка задач в ListView
            var tasks = _context.Задачи.ToList();
            TasksListView.ItemsSource = tasks;
        }

        private void LoadProjects()
        {
            // Загрузка проектов в ListView
            var projects = _context.Проекты.ToList();
            ProjectsListView.ItemsSource = projects;
        }

        private void LoadUsers()
        {
            // Загрузка пользователей в ListView
            var users = _context.Пользователи.ToList();
            UsersListView.ItemsSource = users;
        }

        private void LoadComments()
        {
            // Загрузка комментариев в ListView
            var comments = _context.Комментарии.ToList();
            CommentsListView.ItemsSource = comments;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {

            AddTaskWindow addTaskWindow = new AddTaskWindow(null);
            addTaskWindow.ShowDialog();
            LoadTasks();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            AddProjectWindow addProjectWindow = new AddProjectWindow();
            addProjectWindow.ShowDialog();
            LoadProjects();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            LoadUsers();
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            AddCommentWindow addCommentWindow = new AddCommentWindow();
            addCommentWindow.ShowDialog();
            LoadComments();
        }
    }
}