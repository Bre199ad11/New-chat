using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Chat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        byte[] input;
        public byte[] output;
        public void RSAHash()
        {
            
            string txt = richTextBox1.Text;
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] textData = ByteConverter.GetBytes(richTextBox1.Text);
            
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAParameters public_key= RSA.ExportParameters(false);
            RSAParameters private_key = RSA.ExportParameters(true);
            RSA.ImportParameters(public_key);
            output = RSA.Encrypt(textData, false);
            Form4 form4 = new Form4();
            //RSA.ImportParameters(private_key);

            //input=RSA.Decrypt(output, false);
            //string s = ByteConverter.GetString(input);
            form4.TxtChanged(output);
            //form4.Message=output;
            // public_key = rsa.ExportParameters(false);
            // byte[] hash = System(textData, public_key);
            // textBox1.Text = BitConverter.ToString(hash).Replace("-", String.Empty).ToLower();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = Application.OpenForms[0];

            Form1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSAHash();
        }
    }
}
