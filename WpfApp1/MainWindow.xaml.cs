using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        string htmlString = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cxml_Click(object sender, RoutedEventArgs e)
        {
           XmlDocument doc = new XmlDocument();
            doc.Load(htmlString);

        }

        private void htmlLoad_Click(object sender, RoutedEventArgs e)
        {
            //web.Source = new Uri(urltb.Text);
            web.Navigate ( new Uri(urltb.Text));
        }

        private void web_LoadCompleted(object sender, NavigationEventArgs e)
        {
            //var x= web.Document;
            string html = "";
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.12) Gecko/20100824 Firefox/3.5.12x";
                client.Encoding = Encoding.UTF8;
                html = client.DownloadString(urltb.Text);
            }
            htmlString = html;
        }
    }
}
