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

    public partial class ChangePage : Page
    {
        public ChangePage(List<Test> tests)
        {
            InitializeComponent();

            data.ItemsSource = tests;
        }

        private void data_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            

            if (data.SelectedItem == null)
            {
                (sender as DataGrid).RowEditEnding -= data_RowEditEnding;
                (sender as DataGrid).CommitEdit();
                (sender as DataGrid).Items.Refresh();
                (sender as DataGrid).RowEditEnding += data_RowEditEnding;

                List<Test> list = new List<Test>() { };

                foreach (var item in data.Items)
                {
                    list.Add(item as Test);
                }

                Manager.Serializer(list.Take(list.Count - 1).ToList());
            }

        }

    }
}
