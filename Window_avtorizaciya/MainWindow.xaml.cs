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

namespace Window_avtorizaciya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int second_count = 0;
        int minute_count = 3;
        System.Timers.Timer block = new System.Timers.Timer();


        public MainWindow()
        {
            InitializeComponent();
            block.Interval = 1000;
            block.Elapsed += OnButtonElapsed;
            block.Start();
        }

        private void OnButtonElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        if (Button_enter.IsEnabled == false)
                        {
                            second_count++;
                            Timer_block.Dispatcher.Invoke(() =>
                            {

                                Timer_block.Text = "Блокировка: " + minute_count + " минут(ы)";
                                Timer_block.Visibility = Visibility.Visible;
                            });

                            if (second_count == 60 & minute_count != 0)
                            {
                                second_count = 0;
                                minute_count--;
                            }
                            if (minute_count == 0)
                            {
                                (window as MainWindow).Button_enter.IsEnabled = true;
                                block.Stop();
                                minute_count = 0;
                                second_count = 0;
                                Timer_block.Visibility = Visibility.Hidden;

                            }

                        }

                    }

                } });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные для входа\nАдмин: Логин - Admin, Пароль - Admin\nСтарший смены: Логин - Smena123, Пароль - Smena123\nПродавец: Логин - Tovar123, Пароль - Tovar123","Помощь");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string[] logins = new string[3] { "Admin", "Smena123", "Tovar123" };
            string[] password = new string[3] { "Admin", "Smena123", "Tovar123" };
            if (Text_login.Text.Equals(logins[0]) & Text_password.Text.Equals(password[0]))
            {
                MessageBox.Show("Вы зашли за Администратора");
                Window_admin winadmin = new Window_admin();
                winadmin.Show();
            }
            else if (Text_login.Text.Equals(logins[1]) & Text_password.Text.Equals(password[1]))
            {
                MessageBox.Show("Вы зашли за Старшего смены");
                Window_starshsmeni winstarshsmeny = new Window_starshsmeni();
                winstarshsmeny.Show();
            }
            else if (Text_login.Text.Equals(logins[2]) & Text_password.Text.Equals(password[2]))
            {
                MessageBox.Show("Вы зашли за продавца");
                Window_prodavec winprodavec = new Window_prodavec();
                winprodavec.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Попробуйте снова.");
            }

        }
    }
}
