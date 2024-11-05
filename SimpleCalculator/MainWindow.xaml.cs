using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private double _result = 0;
        private string _operator = "";
        private bool _isOperatorPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (_isOperatorPressed)
                {
                    txtDisplay.Text = "";
                    _isOperatorPressed = false;
                }
                txtDisplay.Text += button.Content.ToString();
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double number))
            {
                _result = number;
                if (sender is Button button)
                {
                    _operator = button.Content.ToString();
                    _isOperatorPressed = true;
                }
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double number))
            {
                switch (_operator)
                {
                    case "+":
                        _result += number;
                        break;
                    case "-":
                        _result -= number;
                        break;
                    case "*":
                        _result *= number;
                        break;
                    case "/":
                        if (number != 0)
                            _result /= number;
                        else
                            MessageBox.Show("Cannot divide by zero.");
                        break;
                }
                txtDisplay.Text = _result.ToString();
                _operator = "";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
            _result = 0;
            _operator = "";
        }
    }
}