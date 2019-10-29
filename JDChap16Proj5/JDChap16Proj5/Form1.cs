//Josh DePauw
//Chapter 16 Project 5
//Pig Latin Translator
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDChap16Proj5
{
    public partial class Form1 : Form
    {

        //create variables
        private string pig = "ay";
        private string userInput;

        public Form1()
        {
            InitializeComponent();
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            GetPigLatin();
        }

        private void GetPigLatin()
        {
            // only allows user to enter letters and spaces
            if (!(System.Text.RegularExpressions.Regex.IsMatch(userTextBox.Text, "^[a-zA-Z ]*$")))
            {
                MessageBox.Show("Only enter letters and spaces please re-enter: ");
                return;
            }

            userInput = userTextBox.Text; //assigns variable userInput to the text entered in by the user
            StringBuilder buffer = new StringBuilder();
            string[] words = userInput.Split(' ');//puts user input into an array seperated by white spaces

            //translate each word individually
            foreach (var word in words)
            {
                try
                {
                    //takes the first letter of each word and adds "ay" to the end
                    string addAy = word[0].ToString() + pig;

                    //takes whats in index 0 and removes it 
                    string minusFirst = word.Remove(0, 1);

                    //takes the word without first letter and adds 1st letter and "ay" to the end
                    string pigLatin = minusFirst + addAy;

                    //add to the buffer with space after
                    buffer.Append(pigLatin + " ");
                }
                //catch extra whitespace
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Please delete the extra whitespaces and try again:");
                    return;
                }
            }

            //display whats in the buffer onto the textbox
            displayTextBox.Text += buffer.ToString() + System.Environment.NewLine;
        }
    }
}
