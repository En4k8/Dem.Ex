using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Window_avtorizaciya
{
    /// <summary>
    /// Логика взаимодействия для Window_admin.xaml
    /// </summary>
    public partial class Window_admin : Window
    {
        static int second_counter = 0;
        static int minute_counter = 0;
        System.Timers.Timer timer = new System.Timers.Timer();
        public Window_admin()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            second_counter = 0;
            minute_counter = 0;
            Close();
        }
        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            second_counter++;
            Timer.Dispatcher.Invoke(() =>
            {
                Timer.Text = "Таймер: " + second_counter;
            });
            if (second_counter == 60)
            {
                second_counter = 0;
                minute_counter++;
                Timer.Dispatcher.Invoke(() =>
                {
                    Minute.Text = "Минут(ы): " + minute_counter;
                });
            }
            if (minute_counter == 5 && second_counter == 0)
            {
                MessageBox.Show("Скоро завершится сеанс", "Внимание!");
            }
            if (minute_counter == 10 && second_counter == 0)
            {
                MessageBox.Show("Ваш сеанс завершён!", "Конец");
                timer.Stop();
                second_counter = 0;
                minute_counter = 0;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).Button_enter.IsEnabled = false;
                            Close();
                        }

                    }
                });

            }
            
        }
    } }
