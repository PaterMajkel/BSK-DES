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

namespace bsk
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

        private void Encode(object sender, RoutedEventArgs e)
        {
            
            if(string.IsNullOrEmpty(encodeText.Text) || string.IsNullOrEmpty(encodeKeyText.Text))
            {
                MessageBox.Show("Puste pole", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (encodeKeyText.Text.Length != 8)
            {
                MessageBox.Show("Zła długość klucza", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var strings = Algorithm.Encode(encodeText.Text, encodeKeyText.Text);

            decodeBinText.Text = strings[1];
            decodeText.Text = strings[0];
            decodeKeyText.Text = encodeKeyText.Text;
        }

        private void Decode(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(decodeText.Text) || string.IsNullOrEmpty(decodeKeyText.Text))
            {
                MessageBox.Show("Puste pole", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (decodeKeyText.Text.Length != 8)
            {
                MessageBox.Show("Zła długość klucza", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Nie wiem dlaczego, ale coś takiego działa i tyle xD
            var strings = Algorithm.Encode(decodeText.Text, decodeKeyText.Text, true);
            strings = Algorithm.Encode(strings[0], decodeKeyText.Text);
            strings = Algorithm.Encode(strings[0], decodeKeyText.Text, true);

            //decodeBinText.Text = strings[1];
            encodeText.Text = strings[0];
        }
    }
}
