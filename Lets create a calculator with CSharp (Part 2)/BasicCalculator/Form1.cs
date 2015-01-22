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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            operand1 = Double.Parse(userInput);
            userInput = string.Empty;
            mathOperator = buttonAdd.Text;
            txtBoxCalculationDisplay.Text = string.Empty;
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            operand1 = Double.Parse(userInput);
            userInput = string.Empty;
            mathOperator = buttonSubtract.Text;
            txtBoxCalculationDisplay.Text = string.Empty;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            operand1 = Double.Parse(userInput);
            userInput = string.Empty;
            mathOperator = buttonMultiply.Text;
            txtBoxCalculationDisplay.Text = string.Empty;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            operand1 = 0;
            operand2 = 0;
            userInput = string.Empty;
            mathOperator = string.Empty;
            calculatedResult = 0;
            txtBoxCalculationDisplay.Text = string.Empty;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Deletes the last position in TextBox if there's text in it
            if (!string.IsNullOrEmpty(txtBoxCalculationDisplay.Text))
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text.Remove(txtBoxCalculationDisplay.TextLength - 1);
            }

        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            operand1 = Double.Parse(userInput);
            userInput = string.Empty;
            mathOperator = buttonDivide.Text;
            txtBoxCalculationDisplay.Text = string.Empty;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            operand2 = Double.Parse(userInput);
            txtBoxCalculationDisplay.Text = string.Empty;
            performArithmeticOperation(mathOperator, operand1, operand2);
            userInput = calculatedResult.ToString();

            ////Old code - what the hell was I thinking?  Why am I trying to parse everything out of 1 large string and reconstruct as a math problem...too many variations in potential errors
            //string equation = txtBoxCalculationDisplay.Text;

            ////if string contains an operator, proceed with finding two values to be calculated
            //if (equation.Contains("+"))
            //{
            //    userInput = equation.Substring(equation.IndexOf("+"), 1);
            //    operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("+"))); //stores all numbers before operator
            //    operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("+") + 1, equation.Length - (equation.IndexOf("+") + 1)));  //stores all numbers after operator
            //    performArithmeticOperation(userInput, operand1, operand2);
            //    return;
            //}
            //else if (equation.Contains("-"))
            //{
            //    userInput = equation.Substring(equation.IndexOf("-"), 1);
            //    //determine if minus is before number (indicating a negative value), or used as an operator in the equation...only computes if minus is being used as an operator
            //    if (equation.IndexOf("-") != 0)
            //    {
            //        operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("-"))); //stores all numbers before operator
            //        operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("-") + 1, equation.Length - (equation.IndexOf("-") + 1)));  //stores all numbers after operator
            //        performArithmeticOperation(userInput, operand1, operand2);
            //        return;
            //    }

            //}
            //else if (equation.Contains("*"))
            //{
            //    /* - This block of commented code helped me think through how to write the uncommented code
            //    int lazyEquationIndex = equation.IndexOf("*");
            //    int lazyEquationLength = equation.Length;
            //    int lazyLength = equation.Length - equation.IndexOf("*");
            //    int lazyIndexPlusOne = equation.IndexOf("*") + 1;
            //    string lazyTest = "6*6";
            //    string lazyResult1 = lazyTest.Substring(0, lazyEquationIndex);
            //    string lazyResult2 = lazyTest.Substring(lazyIndexPlusOne, lazyEquationLength - lazyIndexPlusOne);
            //     * */

            //    userInput = equation.Substring(equation.IndexOf("*"), 1);
            //    operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("*"))); //stores all numbers before operator
            //    operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("*") + 1, equation.Length - (equation.IndexOf("*") + 1)));  //stores all numbers after operator
            //    performArithmeticOperation(userInput, operand1, operand2);
            //    return;
            //}
            //else if (equation.Contains("/"))
            //{
            //    userInput = equation.Substring(equation.IndexOf("/"), 1);
            //    operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("/"))); //stores all numbers before operator
            //    operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("/") + 1, equation.Length - (equation.IndexOf("/") + 1)));  //stores all numbers after operator
            //    performArithmeticOperation(userInput, operand1, operand2);
            //    return;
            //}
            //else
            //{
            //    return;
            //}

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
    }
}

