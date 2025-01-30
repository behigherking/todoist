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
        private Задачи _task;
        private Entities _context;

        public AddTaskWindow(Задачи task)
        {
            InitializeComponent();
            _task = task;
            _context = new Entities();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TaskNameTextBox.Text))
            {
                var newTask = new Задачи
                {
                    Название = TaskNameTextBox.Text,
                    Описание = TaskDescriptionTextBox.Text,
                    Статус = "Новая" // по умолчанию
                };

                _context.Задачи.Add(newTask);
                _context.SaveChanges();
                MessageBox.Show("Задача добавлена!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните название задачи.");
            }
        }
    }
}