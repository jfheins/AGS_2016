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

namespace Tag16
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

        private static readonly string[] alphabets = new[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "abcdefghijklmnopqrstuvwxyz" };

        private int Mod(int value, int ringsize)
        {
            if (ringsize <= 0)
                throw new ArgumentOutOfRangeException(nameof(ringsize));

            return (value % ringsize + ringsize) % ringsize;
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            PlaintextTxt.Text = DecodeText(CiphertextTxt.Text);
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
        }

        private string DecodeText(string ciphertext)
        {
            int shift = 0;

            var plaintext = new StringBuilder();
            foreach (var chr in ciphertext)
            {
                char cipherchar = chr;
                var pos = alphabets[0].IndexOf(cipherchar);
                pos = Mod(pos + shift++, 26);

                var plainchar = alphabets[1][pos];

                plaintext.Append(plainchar);
            }
            return plaintext.ToString();
        }
    }
}