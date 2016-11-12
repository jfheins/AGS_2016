using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace Prolog
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

        private static readonly string[] alphabets = new[] { "1234567890", "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };

        private int Mod(int value, int ringsize)
        {
            if (ringsize <= 0)
                throw new ArgumentOutOfRangeException("ringsize");

            return (value % ringsize + ringsize) % ringsize;
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            PlaintextTxt.Text = EncodeText(CiphertextTxt.Text, -1);
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            CiphertextTxt.Text = EncodeText(PlaintextTxt.Text, 1);
        }

        private string EncodeText(string ciphertext, int bias)
        {
            var plaintext = new StringBuilder();
            foreach (var chr in ciphertext)
            {
                char plainchar = chr;
                foreach (var a in alphabets)
                {
                    if (a.Contains(chr))
                    {
                        // shift it
                        int shifted = Mod(a.IndexOf(chr) + bias, a.Length);
                        plainchar = a[shifted];
                        bias = -bias;
                        break;
                    }
                }
                // punctuation
                plaintext.Append(plainchar);
            }
            return plaintext.ToString();
        }
    }
}
