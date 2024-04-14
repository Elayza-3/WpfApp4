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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp4
{

    public partial class PlayPage : Page
    {
        List<Test> tests;
        int start = -1;
        int rights = 0;
        int count;
        
        public PlayPage(List<Test> _tests)
        {
            InitializeComponent();
            tests = _tests;
            count = _tests.Count;

            Next();
        }

        private void first_Click(object sender, RoutedEventArgs e)
        {

            if (tests.ElementAt(start).Right == AnswersEnum.First) rights += 1;



            Next();
        }
        private void second_Click(object sender, RoutedEventArgs e)
        {
            if (tests.ElementAt(start).Right == AnswersEnum.Second) rights += 1;


            Next();
        }

        private void third_Click(object sender, RoutedEventArgs e)
        {

            if (tests.ElementAt(start).Right == AnswersEnum.Third) rights += 1;

            Next();
        }
        private void Next()
        {
            if(start < count - 1)
            {
                start++;

                Test test = tests.ElementAt(start);
                title.Text = test.Title;
                definition.Text = test.Definition;

                one.Content = test.First;
                two.Content = test.Second;
                three.Content = test.Third;
                return;
                
            }

            one.Visibility = Visibility.Collapsed;
            two.Visibility = Visibility.Collapsed;
            three.Visibility = Visibility.Collapsed;
            definition.Visibility = Visibility.Hidden;

            title.Text = $"Вы ответили правильно на {rights}/{count}";
                
            
        }
    }
}
