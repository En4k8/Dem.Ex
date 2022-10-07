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
    /// Логика взаимодействия для Widow_client.xaml
    /// </summary>
    public partial class Window_client : Window
    {
        public Window_client()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Клиент добавлен в базу данных.");
            Close();
        }
    }
}
