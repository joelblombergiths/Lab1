using System.Numerics;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {            
            ParseInput(txtInput.Text);
        }

        private void ParseInput(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) return;

            txtOutput.Clear();
            for (int startIndex = 0; startIndex < inputString.Length - 1; startIndex++)
            {
                if (!char.IsDigit(inputString[startIndex])) continue;

                for (int next = startIndex + 1; next < inputString.Length; next++)
                {
                    if (char.IsDigit(inputString[next]))
                    {
                        if (inputString[startIndex].Equals(inputString[next]))
                        {
                            string matchingNumber = inputString[startIndex..(next + 1)];

                            txtOutput.AppendText(inputString[0..startIndex]);

                            txtOutput.AppendText(matchingNumber, Color.Red);

                            txtOutput.AppendText(inputString[(startIndex + matchingNumber.Length)..], newLine: true);

                            break;
                        }
                    }
                    else break;
                }
            }
        }      
    }
}