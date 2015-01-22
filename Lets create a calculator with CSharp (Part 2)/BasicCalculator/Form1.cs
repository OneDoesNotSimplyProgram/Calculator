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
        double tempNumber;
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
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            operand1 = Double.Parse(userInput);
            userInput = string.Empty;
            mathOperator = buttonSubtract.Text;

            int countOfMinusSigns = 0;

            for (int i = 0; i < txtBoxCalculationDisplay.Text.Length; i++)
            {
                if (txtBoxCalculationDisplay.Text.Substring(i, 1) == "-")
                {
                    countOfMinusSigns = countOfMinusSigns + 1;
                }
            }

            if (!txtBoxCalculationDisplay.Text.Contains("-"))
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text + "-";
            }
            else if (txtBoxCalculationDisplay.Text.Substring(0, 1).Contains("-") && countOfMinusSigns < 2)
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text + "-";
            }
            else if (countOfMinusSigns > 2)
            {
                return;
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (!txtBoxCalculationDisplay.Text.Contains("*"))
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text + "*";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtBoxCalculationDisplay.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Deletes the last position in TextBox
            txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text.Remove(txtBoxCalculationDisplay.TextLength - 1);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (!txtBoxCalculationDisplay.Text.Contains("/"))
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text + "/";
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {

            string equation = txtBoxCalculationDisplay.Text;

            //if string contains an operator, proceed with finding two values to be calculated
            if (equation.Contains("+"))
            {
                userInput = equation.Substring(equation.IndexOf("+"), 1);
                operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("+"))); //stores all numbers before operator
                operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("+") + 1, equation.Length - (equation.IndexOf("+") + 1)));  //stores all numbers after operator
                performArithmeticOperation(userInput, operand1, operand2);
                return;
            }
            else if (equation.Contains("-"))
            {
                userInput = equation.Substring(equation.IndexOf("-"), 1);
                //determine if minus is before number (indicating a negative value), or used as an operator in the equation...only computes if minus is being used as an operator
                if (equation.IndexOf("-") != 0)
                {
                    operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("-"))); //stores all numbers before operator
                    operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("-") + 1, equation.Length - (equation.IndexOf("-") + 1)));  //stores all numbers after operator
                    performArithmeticOperation(userInput, operand1, operand2);
                    return;
                }

            }
            else if (equation.Contains("*"))
            {
                /* - This block of commented code helped me think through how to write the uncommented code
                int lazyEquationIndex = equation.IndexOf("*");
                int lazyEquationLength = equation.Length;
                int lazyLength = equation.Length - equation.IndexOf("*");
                int lazyIndexPlusOne = equation.IndexOf("*") + 1;
                string lazyTest = "6*6";
                string lazyResult1 = lazyTest.Substring(0, lazyEquationIndex);
                string lazyResult2 = lazyTest.Substring(lazyIndexPlusOne, lazyEquationLength - lazyIndexPlusOne);
                 * */

                userInput = equation.Substring(equation.IndexOf("*"), 1);
                operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("*"))); //stores all numbers before operator
                operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("*") + 1, equation.Length - (equation.IndexOf("*") + 1)));  //stores all numbers after operator
                performArithmeticOperation(userInput, operand1, operand2);
                return;
            }
            else if (equation.Contains("/"))
            {
                userInput = equation.Substring(equation.IndexOf("/"), 1);
                operand1 = Convert.ToDouble(equation.Substring(0, equation.IndexOf("/"))); //stores all numbers before operator
                operand2 = Convert.ToDouble(equation.Substring(equation.IndexOf("/") + 1, equation.Length - (equation.IndexOf("/") + 1)));  //stores all numbers after operator
                performArithmeticOperation(userInput, operand1, operand2);
                return;
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
    }
}

