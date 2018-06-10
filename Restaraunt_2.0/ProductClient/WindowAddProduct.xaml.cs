using LibraryEntities;
using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace ProductClient
{
    /// <summary>
    /// Interaction logic for WindowAddProduct.xaml
    /// </summary>
    public partial class WindowAddProduct : Window
    {
        public WindowAddProduct()
        {
            InitializeComponent();

        }
        public string outMessage;
        Product product;
         bool Start()
        {
            return false;
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Start() == true)
            {
                outMessage = JsonConvert.SerializeObject(product);
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
