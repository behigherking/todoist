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
        private Entities _context;

        public AddProjectWindow()
        {
            InitializeComponent();
            _context = new Entities();
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ProjectNameTextBox.Text))
            {
                var newProject = new Проекты
                {
                    Название = ProjectNameTextBox.Text,
                    Описание = ProjectDescriptionTextBox.Text
                };

                _context.Проекты.Add(newProject);
                _context.SaveChanges();
                MessageBox.Show("Проект добавлен!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните название проекта.");
            }
        }
    }
}