using ClientConnection;
using LibraryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace ProductClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }
        static string adress = "192.168.0.102";
        static int port = 1024;
        static TcpClient tcpClient = new TcpClient(adress, port);
        static NetworkStream stream = Client.Start(tcpClient);
        string answer = null;
        string Message(string message)
        {
            try
            {
                return  Client.ClientMessageForServer(message, stream, tcpClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        void AllProduct()
        {
            List<Product> products = new List<Product>();
            string temp = MethodsClient<Product>.MessageOutpoot("Product");
            products = MethodsClient<Product>.AnswerOutpot(temp).ToList();
            ListProduct.ItemsSource = products;
        }

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            WindowAddProduct window = new WindowAddProduct();
            if (window.ShowDialog() == true)
            {
                MessageBox.Show(answer = Message(window.outMessage));
         
            }
            AllProduct();
        }
    }
}
