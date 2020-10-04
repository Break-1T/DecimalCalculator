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

namespace DecimalCalculator
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

        private void Element_Click(object sender, RoutedEventArgs e)
        {
            Button numberclick = (Button)sender;
            string elements = numberclick.Content.ToString();
            switch (elements)
            {
                case "C":
                    Answer.Text = "";
                    break;
                case "Del":
                    Answer.Text = DeleteLastChar(Answer.Text);
                    break;
                default:
                    Answer.Text += elements;
                    break;
            }
        }
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            switch (Operation(Answer.Text))
            {
                case '+':
                    Answer.Text = $"{Convert.ToDouble(FirstNumber(Answer.Text)) + Convert.ToDouble(SecondNumber(Answer.Text))}";
                    break;
                case '-':
                    Answer.Text = $"{Convert.ToDouble(FirstNumber(Answer.Text)) - Convert.ToDouble(SecondNumber(Answer.Text))}";
                    break;
                case '*':
                    Answer.Text = $"{Convert.ToDouble(FirstNumber(Answer.Text)) * Convert.ToDouble(SecondNumber(Answer.Text))}";
                    break;
                case '/':
                    Answer.Text = $"{Convert.ToDouble(FirstNumber(Answer.Text)) / Convert.ToDouble(SecondNumber(Answer.Text))}";
                    break;
                default:
                    break;
            }
        }

        private string DeleteLastChar(string s)
        {
            if (s.Length > 0)
                return s.Substring(0, s.Length - 1);
            else
                return "";
        }
        private string SecondNumber(string s)
        {
            int number = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i]=='+'|| s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    number = i;
                }
            }
            return s.Substring(number+1,s.Length-number-1);
        }
        private string FirstNumber(string s)
        {
            int number = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    number = i;
                }
            }
            return s.Substring(0,number);
        }
        private char Operation(string s)
        {
            char result =' ';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    result = s[i];
                }
            }
            return result;
        }

    }
}
