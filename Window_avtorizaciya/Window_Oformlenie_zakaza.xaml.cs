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
    /// Логика взаимодействия для Window_Oformlenie_zakaza.xaml
    /// </summary>
    public partial class Window_Oformlenie_zakaza : Window
    {
        public Window_Oformlenie_zakaza()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window_client client = new Window_client();
            client.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заказ добавлен в базу данных.");
        }
    }
}
