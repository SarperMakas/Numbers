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

namespace NumberConverter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NumberWindow : Window {
        private string bin = "";

        public NumberWindow() {
            InitializeComponent();
        }

        #region EvenOrOdd
        private void EvenOrOddState(object sender, RoutedEventArgs e) {
            try {
                // Check even or odd
                int num = Convert.ToInt32(EvenOrOddText.Text);
                if (num % 2 == 0) EvenOrOddText.Text = $"{num} Is Even";
                else EvenOrOddText.Text = $"{num} Is Odd";
            } catch { MessageBox.Show("An Error Riase"); }
        }
        #endregion

        #region Prime
        private string IsPrimeNumber(int num) {
            // Check if number is prime

            bool found = true;
            for (int i = 3; i < num; i += 2) {
                // Check divisions
                if (Convert.ToInt32(num / i) * i == num) {
                    return $"{num} Is Not Prime";
                }
            }
            if (found == true)
                return $"{num} Is Prime";
            return "";
        }

        private void IsPrimeState(object sender, RoutedEventArgs e) {
            try {
                // Check if it is Prime
                int num = Convert.ToInt32(IsPrimeText.Text);
                IsPrimeText.Text = IsPrimeNumber(num);
            } catch { MessageBox.Show("An Error Riase"); }
        }
        #endregion

        #region Emirp
        private string Reverse(string text) {
            // Reverse imput
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }


        private string IsEmirpNumber(int num) {
            if (IsPrimeNumber(num) == $"{num} Is Prime" && IsPrimeNumber(Convert.ToInt32(Reverse(num.ToString()))) == $"{Reverse(num.ToString())} Is Prime")
                return $"{num} Is Emirp";
            else return $"{num} Is Not Emirp";
        }

        private void IsEmirpState(object sender, RoutedEventArgs e) {
            try {
                // Check if it is Emirp
                int num = Convert.ToInt32(IsEmirpText.Text);
                IsEmirpText.Text = IsEmirpNumber(num);
            } catch { MessageBox.Show("An Error Riase"); }
        }
        #endregion

        #region Hex
        private void NumToHex(object sender, RoutedEventArgs e) {
            try {
                // Convert to hexadecimal
                string num = Convert.ToInt32(HexadecimalText.Text).ToString("X");
                if (num.Length == 1) num = $"0{num}";
                HexadecimalText.Text = $"0x{num}";
            } catch { MessageBox.Show("An Error Riase"); }
        }

        private void HexToNum(object sender, RoutedEventArgs e) {
            try {
                // Convert to normal int
                if (HexadecimalText.Text.Substring(0, 2) == "0x")
                    HexadecimalText.Text = int.Parse(HexadecimalText.Text.Substring(2), System.Globalization.NumberStyles.HexNumber).ToString();
                else HexadecimalText.Text = int.Parse(HexadecimalText.Text, System.Globalization.NumberStyles.HexNumber).ToString();
            } catch { MessageBox.Show("An Error Riase"); }
        }
        #endregion

        private void BinaryToNum(object sender, RoutedEventArgs e) {
            string num = BinaryText.Text;
            int decimalNum = 0;
            for (int i = 0; i < num.Length; i++) {
                decimalNum = decimalNum * 2 + Convert.ToInt32(num[i] - '0');
            }
            BinaryText.Text = decimalNum.ToString();
        }

        #region Binary
        private void DecimalToBinary(int num) {
            // converting decimal to binary
            if (num >= 1) {
                DecimalToBinary(num / 2);
                bin += (num % 2).ToString();
            }
        }

        private void NumToBinary(object sender, RoutedEventArgs e) {
            bin = "";
            DecimalToBinary(Convert.ToInt32(BinaryText.Text));
            BinaryText.Text = bin;
        }
        #endregion

        #region Happy
        static bool IsHappy(int num) {
            while (num != 0 && num != 4) {
                num = SqrtNum(num);
                if (num == 1) {
                    return true;
                } else {
                    return IsHappy(num);
                }
            }
            return false;
        }

        static int SqrtNum(int num) {
            char[] arr = num.ToString().ToCharArray();
            num = 0;
            foreach (var item in arr) {
                num += Convert.ToInt32(item - '0') * Convert.ToInt32(item - '0');
            }
            return num;
        }

        private void IsHappyState(object sender, RoutedEventArgs e) {
            try {
                int num = Convert.ToInt32(IsHappyText.Text);
                bool state = IsHappy(num);

                // Happy number
                if (state == true)
                    IsHappyText.Text = $"{num} Is Happy Number";
                else
                    IsHappyText.Text = $"{num} Is NOT Happy Number";
            } catch { MessageBox.Show("An Error Riase"); }
        }
        #endregion
    }
}
