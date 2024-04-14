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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string pass = "hello";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            auth.Visibility = Visibility.Visible;

        }

        private void auth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(auth.Text == pass)
            {
                ShowWindow(true);
            }
        }
        private void ShowWindow(bool admin = false)
        {
            

            ( new TestWindow(admin)).Show();
            Close();
        }
    }
}
