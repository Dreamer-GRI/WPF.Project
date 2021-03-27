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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = textBox1.Text;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           password = textBox2.Password;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно зарегистрированы, " + login + "!");

            Window1 win = new Window1();
            win.Show();
            this.Hide();
        }
    }
}
