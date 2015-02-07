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

        //TODO:  look in to asynchronous synthesizer and threading for improved performance (currently, calculator locks up when speaking)
        //TODO:  figure out how voice recognition can handle many words or entire sentences rather than just 0-9 and the operators/clear/delete

        public Form1()
        {
            InitializeComponent();
        }

        private void removeButtonFocus()
        {
            //TODO:  Figure out if there's a better way to handle button focus while trying to maintain 'Enter' key as same behavior as equals key
            //Need this method to remove the button focus, otherwise whenever the user
            //clicks a button and hits 'enter' to calculate, it just inputs the 'focused' number button
            //instead of performing the calculation via 'enter' or 'equals'.
            this.ActiveControl = label_equationDisplay;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            userInput += button0.Text;
            txtBoxCalculationDisplay.Text += button0.Text;
            removeButtonFocus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInput += button1.Text;
            txtBoxCalculationDisplay.Text += button1.Text;
            removeButtonFocus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userInput += button2.Text;
            txtBoxCalculationDisplay.Text += button2.Text;
            removeButtonFocus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userInput += button3.Text;
            txtBoxCalculationDisplay.Text += button3.Text;
            removeButtonFocus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userInput += button4.Text;
            txtBoxCalculationDisplay.Text += button4.Text;
            removeButtonFocus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInput += button5.Text;
            txtBoxCalculationDisplay.Text += button5.Text;
            removeButtonFocus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userInput += button6.Text;
            txtBoxCalculationDisplay.Text += button6.Text;
            removeButtonFocus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userInput += button7.Text;
            txtBoxCalculationDisplay.Text += button7.Text;
            removeButtonFocus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userInput += button8.Text;
            txtBoxCalculationDisplay.Text += button8.Text;
            removeButtonFocus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userInput += button9.Text;
            txtBoxCalculationDisplay.Text += button9.Text;
            removeButtonFocus();
        }

        //All of the operator buttons basically follow this process:  1) set the first operand, 2) set the operator, 3) show #1 and #2 above textbox
        //The equals button is the only event that sets operand2 and then performs the calculation
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonAdd.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(operand1);
            }
            else
            {
                return;
            }
            removeButtonFocus();
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonSubtract.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(operand1);
            }
            else
            {
                return;
            }
            removeButtonFocus();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonMultiply.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(operand1);
            }
            else
            {
                return;
            }
            removeButtonFocus();
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand1 = Double.Parse(userInput);
                mathOperator = buttonDivide.Text;
                txtBoxCalculationDisplay.Text = string.Empty;
                showEquationAboveCalculationDisplay(operand1);
            }
            else
            {
                return;
            }
            removeButtonFocus();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                operand2 = Double.Parse(userInput);
                txtBoxCalculationDisplay.Text = string.Empty;
                performArithmeticOperation(mathOperator, operand1, operand2);
                // TODO:  Determine if userInput is needed given the above performArithmeticOperation method and calculatedResult variable.
                userInput = calculatedResult.ToString();
                label_equationDisplay.Text += operand2.ToString();
            }
            else
            {
                return;
            }
            removeButtonFocus();
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

        private void showEquationAboveCalculationDisplay(double input)
        {
            label_equationDisplay.Text = input.ToString() +" " + mathOperator + " ";
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
            label_equationDisplay.Text = string.Empty;
            removeButtonFocus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Deletes the last position in TextBox if there's text in it
            if (!string.IsNullOrEmpty(txtBoxCalculationDisplay.Text))
            {
                txtBoxCalculationDisplay.Text = txtBoxCalculationDisplay.Text.Remove(txtBoxCalculationDisplay.TextLength - 1);
            }
            removeButtonFocus();
        }

        private void buttonSpeech_Click(object sender, EventArgs e)
        {
            //TODO:  Figure out why speechSynthesize says some numbers weird.  E.g. "five thousand five hundred and eighty four" vs "fifty five eighty four"
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
            removeButtonFocus();
        }

        //TODO:  Determine design option for enhanced number dictionary (e.g. "one hundred", "one hundred and one", "five hundred and fifty three thousand, four hundred and twenty two")
        private void buttonListen_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine speechRecognize = new SpeechRecognitionEngine();
            Choices choiceList = new Choices();
            //TODO:  Determine if an array is most appropriate here.  Consider a list?
            choiceList.Add(new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "times", "multiplied", "divide", "divided by", "minus", "add", "plus", "equals", "delete", "clear", "exit", "speak", "play back" });
            Grammar calculatorGrammer = new Grammar(new GrammarBuilder(choiceList));

            //TODO:  Make the try/catch/finally portion more meaningful
            try
            {
                speechRecognize.RequestRecognizerUpdate();
                speechRecognize.LoadGrammar(calculatorGrammer);
                speechRecognize.SpeechRecognized += speechRecognize_SpeechRecognized;
                speechRecognize.SetInputToDefaultAudioDevice();
                speechRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
            removeButtonFocus();
        }

        private void speechRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "exit")
            {
                Application.Exit();
            }
            else if (e.Result.Text == "one")
            {
                button1.PerformClick();
            }
            else if (e.Result.Text == "two")
            {
                button2.PerformClick();
            }
            else if (e.Result.Text == "three")
            {
                button3.PerformClick();
            }
            else if (e.Result.Text == "four")
            {
                button4.PerformClick();
            }
            else if (e.Result.Text == "five")
            {
                userInput += button5.Text;
                txtBoxCalculationDisplay.Text += button5.Text;
                removeButtonFocus();
            }
            else if (e.Result.Text == "six")
            {
                button6.PerformClick();
            }
            else if (e.Result.Text == "seven")
            {
                button7.PerformClick();
            }
            else if (e.Result.Text == "eight")
            {
                button8.PerformClick();
            }
            else if (e.Result.Text == "nine")
            {
                button9.PerformClick();
            }
            else if (e.Result.Text == "zero")
            {
                button0.PerformClick();
            }
            else if (e.Result.Text == "times" || e.Result.Text == "multiplied")
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    buttonMultiply.PerformClick();
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
                    buttonDivide.PerformClick();
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
                    buttonSubtract.PerformClick();
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
                    buttonAdd.PerformClick();
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
                    buttonEquals.PerformClick();
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
                buttonClear.PerformClick();
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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TODO:  Add KeyChar for 'Delete' key
            //TODO:  Decide if this should be a switch statement
            if (e.KeyChar == 48)
            {
                button0.PerformClick();
            }
            else if (e.KeyChar == 49)
            {
                button1.PerformClick();
            }
            else if (e.KeyChar == 50)
            {
                button2.PerformClick();
            }
            else if (e.KeyChar == 51)
            {
                button3.PerformClick();
            }
            else if (e.KeyChar == 52)
            {
                button4.PerformClick();
            }
            else if (e.KeyChar == 53)
            {
                button5.PerformClick();
            }
            else if (e.KeyChar == 54)
            {
                button6.PerformClick();
            }
            else if (e.KeyChar == 55)
            {
                button7.PerformClick();
            }
            else if (e.KeyChar == 56)
            {
                button8.PerformClick();
            }
            else if (e.KeyChar == 57)
            {
                button9.PerformClick();
            }
            else if (e.KeyChar == 43)
            {
                buttonAdd.PerformClick();
            }
            else if (e.KeyChar == 45)
            {
                buttonSubtract.PerformClick();
            }
            else if (e.KeyChar == 42)
            {
                buttonMultiply.PerformClick();
            }
            else if (e.KeyChar == 47)
            {
                buttonDivide.PerformClick();
            }
            else if (e.KeyChar == 61 || e.KeyChar == 13)
            {
                buttonEquals.PerformClick();
            }
        }
    }
}