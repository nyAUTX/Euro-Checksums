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

namespace EuroPrüfziffern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client(ServiceReference1.Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
            Dictionary<string, string> languages = client.GetAllLanguages();

            languageBox.ItemsSource = languages;
            languageBox.DisplayMemberPath = "Value";
            languageBox.SelectedValuePath = "Key";
        }

        private void oldCheckButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client(ServiceReference1.Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);
            bool test = client.CheckOldSerial(serialNo.Text);
            oldResults.Content = test;
        }
    }
}
