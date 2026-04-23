using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (isOperationPerformed)
            {
                textBox2.Clear();
                isOperationPerformed = false;
            }

            Button btn = (Button)sender;
            textBox2.Text += btn.Text;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SetOperation("+");
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            SetOperation("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            SetOperation("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            SetOperation("/");
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") return;

            double currentNumber = Convert.ToDouble(textBox2.Text);
            double finalAnswer = 0;

            if (operationPerformed == "+")
                finalAnswer = resultValue + currentNumber;
            else if (operationPerformed == "-")
                finalAnswer = resultValue - currentNumber;
            else if (operationPerformed == "*")
                finalAnswer = resultValue * currentNumber;
            else if (operationPerformed == "/")
            {
                if (currentNumber == 0)
                {
                    MessageBox.Show("Cannot divide by zero");
                    return;
                }

                finalAnswer = resultValue / currentNumber;
            }

            textBox2.Text = finalAnswer.ToString();
            resultValue = finalAnswer;
            operationPerformed = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            resultValue = 0;
            operationPerformed = "";
            isOperationPerformed = false;
        }
        private void SetOperation(string op)
        {
            if (textBox2.Text != "")
            {
                resultValue = Convert.ToDouble(textBox2.Text);
                operationPerformed = op;
                isOperationPerformed = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}