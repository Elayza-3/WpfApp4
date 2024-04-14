using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using Path = System.IO.Path;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private List<Test> tests = new List<Test>() { };
        public TestWindow(bool Admin)
        {
            InitializeComponent();

            edit.IsEnabled = Admin;
            try
            {
                tests = Manager.Deserializer<List<Test>>();
            }
            catch {}
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            ( new MainWindow()).Show();

            Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ChangePage(tests);
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (tests.Count == 0)
            {
                PageFrame.Content = new EmptyPage();
            }
            else
            {
                PageFrame.Content = new PlayPage(tests);
            }

        }
    }
    

    static class Manager
    {
        static private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Questions.json");

        static public T Deserializer<T>()
        {
            string json = File.ReadAllText(path);
            T data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }

        static public void Serializer<T>(T records)
        {
            string json = JsonConvert.SerializeObject(records);

            File.WriteAllText(path, json);

        }

        
    }

    public class Test
    {
        public string Title { get; set; }
        public string Definition { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public AnswersEnum? Right { get; set; }

        public Test(string title, string definition, string first, string second, string third, AnswersEnum right)
        {
            Title = title;
            Definition = definition;
            First = first;
            Second = second;
            Third = third;
            Right = right;
        }
        public Test()
        {
            Title = "";
            Definition = "";
            First = "";
            Second = "";
            Third = "";
            Right = null;
        }
    }
    public enum AnswersEnum
    {
        First,
        Second,
        Third
    }

}



