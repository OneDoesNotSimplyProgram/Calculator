using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        string userInput;
        double operand1;
        double operand2;
        string mathOperator;
        double calculatedResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            userInput += button0.Text;
            txtBoxCalculationDisplay.Text += button0.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInput += button1.Text;
            txtBoxCalculationDisplay.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userInput += button2.Text;
            txtBoxCalculationDisplay.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userInput += button3.Text;
            txtBoxCalculationDisplay.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userInput += button4.Text;
            txtBoxCalculationDisplay.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInput += button5.Text;
            txtBoxCalculationDisplay.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userInput += button6.Text;
            txtBoxCalculationDisplay.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userInput += button7.Text;
            txtBoxCalculationDisplay.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userInput += button8.Text;
            txtBoxCalculationDisplay.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userInput += button9.Text;
            txtBoxCalculationDisplay.Text += button9.Text;
        }

        //All of the operator buttons basically follow this process:  1) set the first operand, 2) set the operator, 3) show stuff
        //The equals button is the only event that sets operand2 and then performs the calculation
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonAdd.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(userInput);
            }
            else
            {
                return;
            }
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonSubtract.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(userInput);
            }
            else
            {
                return;
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonMultiply.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(userInput);
            }
            else
            {
                return;
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonDivide.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(userInput);
            }
            else
            {
                return;
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand2 = Double.Parse(userInput);
                txtBoxCalculationDisplay.Text = string.Empty;
                performArithmeticOperation(mathOperator, operand1, operand2);
                userInput = calculatedResult.ToString();
                //Is the below equationDisplay an appropriate location for this?
                equationDisplay.Text += operand2.ToString();
            }
            else
            {
                return;
            }
        }

        private void performArithmeticOperation(string selectedOperator, double number1, double number2)
        {
            switch (selectedOperator)
            {
                case "+":
                    calculatedResult = number1 + number2;
                    txtBoxCalculationDisplay.Text = Convert.ToString(calculatedResult);
                    break;
                case "-":
                    calculatedResult = number1 - number2;
                    txtBoxCalculationDisplay.Text = Convert.ToString(calculatedResult);
                    break;
                case "*":
                    calculatedResult = number1 * number2;
                    txtBoxCalculationDisplay.Text = Convert.ToString(calculatedResult);
                    break;
                case "/":
                    calculatedResult = number1 / number2;
                    txtBoxCalculationDisplay.Text = Convert.ToString(calculatedResult);
                    break;
            }
        }

        private void showEquationAboveCalculationDisplay(string input)
        {
            equationDisplay.Text = input + " " + mathOperator + " ";
            userInput = string.Empty;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            operand1 = 0;
            operand2 = 0;
            userInput = string.Empty;
            mathOperator = string.Empty;
            calculatedResult = 0;
            txtBoxCalculationDisplay.Text = string.Empty;
            equationDisplay.Text = string.Empty;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Deletes the last position in TextBox if there's text in it
            if (!string.IsNullOrEmpty(txtBoxCalculationDisplay.Text))
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text.Remove(txtBoxCalculationDisplay.TextLength - 1);
            }

        }
    }
}

