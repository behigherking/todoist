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
        private Entities _context;

        public AddCommentWindow()
        {
            InitializeComponent();
            _context = new Entities();
        }

        private void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CommentTextBox.Text))
            {
                var newComment = new Комментарии
                {
                    Текст = CommentTextBox.Text,
                    ID_Задачи = 1, // Пример ID задачи, его нужно будет установить динамически
                    ID_Пользователя = 1 // Пример ID пользователя, его нужно будет установить динамически
                };

                _context.Комментарии.Add(newComment);
                _context.SaveChanges();
                MessageBox.Show("Комментарий добавлен!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните текст комментария.");
            }
        }
    }
}