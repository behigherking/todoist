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
        private Entities _context;

        public AddUserWindow()
        {
            InitializeComponent();
            _context = new Entities();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UserNameTextBox.Text) && !string.IsNullOrEmpty(UserEmailTextBox.Text))
            {
                var newUser = new Пользователи
                {
                    Имя = UserNameTextBox.Text,
                    Почта = UserEmailTextBox.Text
                };

                _context.Пользователи.Add(newUser);
                _context.SaveChanges();
                MessageBox.Show("Пользователь добавлен!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните имя и почту пользователя.");
            }
        }
    }
}