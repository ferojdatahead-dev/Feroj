using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPracticeApp
{
    public partial class Calculator : Form
    {
        double fristNumber = 0;
        double secoundNumber = 0;
        double result = 0;
        string operand = "";
        bool isOperationClicked = false;
        bool isEqualClicked = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void Digit_Click(object sender, EventArgs e)
        {
            if (isOperationClicked)
            {
                resultBox.Clear();
                isOperationClicked = false;
            }
            resultBox.Text += ((Button)sender).Text;
        }

        private void Oparend_Click(object sender, EventArgs e)
        {
            fristNumber = Double.Parse(resultBox.Text);
            operand = ((Button)sender).Text;
            isOperationClicked = true;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            if (isEqualClicked)
            {
                fristNumber = secoundNumber;
                isEqualClicked = false;
            }
            secoundNumber = Double.Parse(resultBox.Text);
            switch (operand)
            {
                case "+":
                    result = fristNumber + secoundNumber;
                    break;
                case "-":
                    result = fristNumber - secoundNumber;
                    break;
                case "*":
                    result = fristNumber * secoundNumber;
                    break;
                case "/":
                    result = fristNumber / secoundNumber;
                    break;
            }
            resultBox.Text = result.ToString();
            isEqualClicked = true;
        }

        private void allClear_Click(object sender, EventArgs e)
        {
            fristNumber = 0;
            secoundNumber = 0;
            result = 0;
            operand = "";
            isOperationClicked = false;
            resultBox.Clear();
        }

        private void screenClear_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
        }
    }
}
