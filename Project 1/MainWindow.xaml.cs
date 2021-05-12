using System;
using System.Collections.Generic;
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
using System.Data.SQLite;

namespace Project_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string login;
        string password;

        SQLiteConnection connect;

        public MainWindow()
        {
            InitializeComponent();

            connect = new SQLiteConnection("Data Source=mydb.db; Version=3;");
            connect.Open();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = loginBox.Text;
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password = passBox.Password;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loginBox.Text != "" && passBox.Password != "")
                {
                    string cmdStr = "INSERT INTO user (login, password, user_type) VALUES ('" + login + "', '" + password + "', '" + 2 + "');"; // INSERT INTO user (login, password) VALUES ('Roma', '1111');
                    SQLiteCommand cmd = new SQLiteCommand(cmdStr, connect);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Вы успешно зарегистрированы, " + login + "!  :D");
                    Window1 win = new Window1(connect);
                    win.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Поля должны быть заполнены!");
                }
            }
            catch
            {
                MessageBox.Show("Имя пользователя уже занято :( ");
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1(connect);
            win.Show();
            this.Hide();
        }
    }
}
