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
    public partial class MainWindow : Window
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
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную задачу из DataGrid
            var selectedTask = TasksListView.SelectedItem as Задачи;

            // Проверяем, выбрана ли задача
            if (selectedTask == null)
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления.");
                return;
            }

            // Подтверждаем удаление
            var result = MessageBox.Show("Вы уверены, что хотите удалить эту задачу?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Удаляем задачу из контекста
                    _context.Задачи.Remove(selectedTask);
                    _context.SaveChanges(); // Сохраняем изменения в базе данных
                    MessageBox.Show("Задача удалена!");

                    // Перезагружаем данные
                    LoadTasks(); // Перезагружаем данные таблицы
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении задачи: " + ex.Message);
                }
            }
        }
        private void SaveTaskChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Применяем изменения, сделанные в DataGrid, в базу данных
                _context.SaveChanges();
                MessageBox.Show("Изменения сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            AddProjectWindow addProjectWindow = new AddProjectWindow();
            addProjectWindow.ShowDialog();
            LoadProjects();
        }
        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную задачу из DataGrid
            var selectedTask = ProjectsListView.SelectedItem as Задачи;

            // Проверяем, выбрана ли задача
            if (selectedTask == null)
            {
                MessageBox.Show("Пожалуйста, выберите проект для удаления.");
                return;
            }

            // Подтверждаем удаление
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот проект?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Удаляем задачу из контекста
                    _context.Задачи.Remove(selectedTask);
                    _context.SaveChanges(); // Сохраняем изменения в базе данных
                    MessageBox.Show("Проект удален!");

                    // Перезагружаем данные
                    LoadTasks(); // Перезагружаем данные таблицы
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении проекта: " + ex.Message);
                }
            }
        }
        private void SaveProjectChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Применяем изменения, сделанные в DataGrid, в базу данных
                _context.SaveChanges();
                MessageBox.Show("Изменения сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            LoadUsers();
        }
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную задачу из DataGrid
            var selectedTask = UsersListView.SelectedItem as Задачи;

            // Проверяем, выбрана ли задача
            if (selectedTask == null)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.");
                return;
            }

            // Подтверждаем удаление
            var result = MessageBox.Show("Вы уверены, что хотите удалить эту пользователя?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Удаляем задачу из контекста
                    _context.Задачи.Remove(selectedTask);
                    _context.SaveChanges(); // Сохраняем изменения в базе данных
                    MessageBox.Show("Пользователь удален!");

                    // Перезагружаем данные
                    LoadTasks(); // Перезагружаем данные таблицы
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении пользователя: " + ex.Message);
                }
            }
        }
        private void SaveUserChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Применяем изменения, сделанные в DataGrid, в базу данных
                _context.SaveChanges();
                MessageBox.Show("Изменения сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            AddCommentWindow addCommentWindow = new AddCommentWindow();
            addCommentWindow.ShowDialog();
            LoadComments();
        }
        private void DeleteComment_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную задачу из DataGrid
            var selectedTask = CommentsListView.SelectedItem as Задачи;

            // Проверяем, выбрана ли задача
            if (selectedTask == null)
            {
                MessageBox.Show("Пожалуйста, выберите комментарий для удаления.");
                return;
            }

            // Подтверждаем удаление
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот комментарий?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Удаляем задачу из контекста
                    _context.Задачи.Remove(selectedTask);
                    _context.SaveChanges(); // Сохраняем изменения в базе данных
                    MessageBox.Show("Комментарий удален!");

                    // Перезагружаем данные
                    LoadTasks(); // Перезагружаем данные таблицы
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении комментария: " + ex.Message);
                }
            }
        }
        private void SaveCommentChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Применяем изменения, сделанные в DataGrid, в базу данных
                _context.SaveChanges();
                MessageBox.Show("Изменения сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }
    }
}