using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SDES SDES = new SDES();  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            BitArray encryptedText = SDES.String_To_Bits(decryptThisString.Text);
            BitArray key = SDES.Key_To_Bits(keyText.Text);

            BitArray decryptedText = SDES.Decrypt(encryptedText, key);

            decryptedString.Text = SDES.Bits_To_String(decryptedText);
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BitArray plainText = SDES.String_To_Bits(encryptThisString.Text);
            Console.WriteLine("Straight from GUI " + SDES.Debug_BTS(plainText));
            BitArray key = SDES.Key_To_Bits(keyText.Text);
            BitArray encryptedText = SDES.Encrypt(plainText, key);
            encryptedString.Text = SDES.Bits_To_String(encryptedText);
            
        }

        private void keyText_TextChanged(object sender, EventArgs e)
        {

        }

        private void keyText_Leave(object sender, EventArgs e)
        {
            if (!SDES.alphabet.IsMatch(keyText.Text))
            {
                MessageBox.Show("Please only enter 1s and 0s", "Input Error");
                keyText.Focus();
            }
            if (keyText.Text.Length != 10 )
            {
                MessageBox.Show("Please enter a key of length 10", "Input Error");
                keyText.Focus();
            }
        }

        private void encryptThisString_TextChanged(object sender, EventArgs e)
        {

        }
        private void encryptThisString_Leave(object sender, EventArgs e)
        {
            if(!SDES.alphabet.IsMatch(encryptThisString.Text))
            {
                MessageBox.Show("Please only enter 1s and 0s", "Input Error");
                encryptThisString.Focus();
            }
            if (encryptThisString.Text.Length != 8)
            {
                MessageBox.Show("Please enter a string of length 8", "Input Error");
                encryptThisString.Focus();
            }
            else
            {
                label6.Text = SDES.Input_String_To_Char_GUI(encryptThisString.Text);
            }
        }

        private void encryptedString_TextChanged(object sender, EventArgs e)
        {
            if(encryptedString.Text.Length == 8 )
            {
                label7.Text = SDES.Input_String_To_Char_GUI(encryptedString.Text);
            }
            
        }

        private void decryptThisString_TextChanged(object sender, EventArgs e)
        {

        }
        private void decryptThisString_Leave(object sender, EventArgs e)
        {
            if (!SDES.alphabet.IsMatch(decryptThisString.Text))
            {
                MessageBox.Show("Please only enter 1s and 0s", "Input Error");
                decryptThisString.Focus();
            }
            if (decryptThisString.Text.Length != 8)
            {
                MessageBox.Show("Please enter a string of length 8", "Input Error");
                decryptThisString.Focus();
            }
            else
            {
                label8.Text = SDES.Input_String_To_Char_GUI(decryptThisString.Text);
            }
        }

        private void decryptedString_TextChanged(object sender, EventArgs e)
        {
            if (decryptedString.Text.Length == 8)
            {
                label9.Text = SDES.Input_String_To_Char_GUI(decryptedString.Text);
            }
        }
    }

    
}

