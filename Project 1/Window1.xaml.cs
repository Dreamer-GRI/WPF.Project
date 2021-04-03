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
using System.Windows.Shapes;
using System.Data.SQLite;

namespace Project_1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string login;
        string password;
        SQLiteConnection data;
        public Window1(SQLiteConnection db)
        {
            InitializeComponent();

            data = db;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            login = loginBox2.Text;
        }

        private void PassBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password = passBox2.Password;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loginBox2.Text != "" && passBox2.Password != "")
                {
                    string cmdStr = "SELECT id,login FROM user WHERE login='" + login +  "';";
                    SQLiteCommand cmd = new SQLiteCommand(cmdStr, data);
                    var reader = cmd.ExecuteReader();

                    int db_id = 0;
                    string db_login = "";
                    while (reader.Read())
                    {
                        try
                        {
                            db_id = Convert.ToInt32(reader.GetValue(0));
                            db_login = reader.GetValue(1).ToString();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    reader.Close();

                    cmdStr = "SELECT password FROM user WHERE id='" + db_id + "';";// SELECT login FROM user WHERE login='Roma';
                    cmd = new SQLiteCommand(cmdStr, data);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.GetValue(0).ToString() == password)
                        {
                            MessageBox.Show("Вы успешно вошли, " + db_login + "!");
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели неверный пароль!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Поля должны быть заполнены!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
