using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        string userInput;
        double operand1;
        double operand2;
        string mathOperator;
        double calculatedResult;
        SpeechRecognitionEngine speechRecognize = new SpeechRecognitionEngine();

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

        private void buttonSpeech_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer speechSynthesize = new SpeechSynthesizer();
            speechSynthesize.SelectVoiceByHints(VoiceGender.Male);
            speechSynthesize.Rate = -2;
            speechSynthesize.Volume = 100;

            switch (mathOperator)
            {
                case "+":
                    speechSynthesize.Speak(operand1 + "plus " + operand2 + "equals " + calculatedResult);
                    break;
                case "-":
                    speechSynthesize.Speak(operand1 + "minus " + operand2 + "equals " + calculatedResult);
                    break;
                case "*":
                    speechSynthesize.Speak(operand1 + "times " + operand2 + "equals " + calculatedResult);
                    break;
                case "/":
                    speechSynthesize.Speak(operand1 + "divided by " + operand2 + "equals " + calculatedResult);
                    break;
            }
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            Choices choiceList = new Choices();
            choiceList.Add(new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "times", "multiplied", "divide", "divided by", "minus", "add", "plus", "equals", "delete", "clear", "exit", "speak", "play back" });
            Grammar stuff = new Grammar(new GrammarBuilder(choiceList));

            try
            {
                speechRecognize.RequestRecognizerUpdate();
                speechRecognize.LoadGrammar(stuff);
                speechRecognize.SpeechRecognized += speechRecognize_SpeechRecognized;
                speechRecognize.SetInputToDefaultAudioDevice();
                speechRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }

        private void speechRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "exit")
            {
                Application.Exit();
            }
            else if (e.Result.Text == "one")
            {
                userInput += button1.Text;
                txtBoxCalculationDisplay.Text += button1.Text;
            }
            else if (e.Result.Text == "two")
            {
                userInput += button2.Text;
                txtBoxCalculationDisplay.Text += button2.Text;
            }
            else if (e.Result.Text == "three")
            {
                userInput += button3.Text;
                txtBoxCalculationDisplay.Text += button3.Text;
            }
            else if (e.Result.Text == "four")
            {
                userInput += button4.Text;
                txtBoxCalculationDisplay.Text += button4.Text;
            }
            else if (e.Result.Text == "five")
            {
                userInput += button5.Text;
                txtBoxCalculationDisplay.Text += button5.Text;
            }
            else if (e.Result.Text == "six")
            {
                userInput += button6.Text;
                txtBoxCalculationDisplay.Text += button6.Text;
            }
            else if (e.Result.Text == "seven")
            {
                userInput += button7.Text;
                txtBoxCalculationDisplay.Text += button7.Text;
            }
            else if (e.Result.Text == "eight")
            {
                userInput += button8.Text;
                txtBoxCalculationDisplay.Text += button8.Text;
            }
            else if (e.Result.Text == "nine")
            {
                userInput += button9.Text;
                txtBoxCalculationDisplay.Text += button9.Text;
            }
            else if (e.Result.Text == "zero")
            {
                userInput += button0.Text;
                txtBoxCalculationDisplay.Text += button0.Text;
            }
            else if (e.Result.Text == "times" || e.Result.Text == "multiplied")
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
            else if (e.Result.Text == "divide" || e.Result.Text == "divided by" )
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
            else if (e.Result.Text == "minus")
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
            else if (e.Result.Text == "add" || e.Result.Text == "plus")
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
            else if (e.Result.Text == "equals")
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
            else if (e.Result.Text == "delete")
            {
                //Deletes the last position in TextBox if there's text in it
                if (!string.IsNullOrEmpty(txtBoxCalculationDisplay.Text))
                {
                    txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text.Remove(txtBoxCalculationDisplay.TextLength - 1);
                }
            }
            else if (e.Result.Text == "clear")
            {
                operand1 = 0;
                operand2 = 0;
                userInput = string.Empty;
                mathOperator = string.Empty;
                calculatedResult = 0;
                txtBoxCalculationDisplay.Text = string.Empty;
                equationDisplay.Text = string.Empty;
            }
            else if (e.Result.Text == "speak" || e.Result.Text == "play back")
            {
                SpeechSynthesizer speechSynthesize = new SpeechSynthesizer();
                speechSynthesize.SelectVoiceByHints(VoiceGender.Male);
                speechSynthesize.Rate = -2;
                speechSynthesize.Volume = 100;

                switch (mathOperator)
                {
                    case "+":
                        speechSynthesize.Speak(operand1 + "plus " + operand2 + "equals " + calculatedResult);
                        break;
                    case "-":
                        speechSynthesize.Speak(operand1 + "minus " + operand2 + "equals " + calculatedResult);
                        break;
                    case "*":
                        speechSynthesize.Speak(operand1 + "times " + operand2 + "equals " + calculatedResult);
                        break;
                    case "/":
                        speechSynthesize.Speak(operand1 + "divided by " + operand2 + "equals " + calculatedResult);
                        break;
                }
            }
            else
            {
                labelSpeech.Text = labelSpeech.Text + " " + e.Result.Text.ToString();
            }
        }
    }
}

