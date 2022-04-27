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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(800, 100);
            Data_From_User1ToUser2.EventHandler = new Data_From_User1ToUser2.MyEvent(TxtChanged);


        }
        private void TxtChanged(byte[] data, RSAParameters key)
        {
            RSAHashDecrypt(data, key);
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void richTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string msg = DateTime.Now.ToLongTimeString() + ": " + richTextBox1.Text + "\r\n";
            RSAHashEncrypt(msg);
            richTextBox1.Text = null;

        }
        public void RSAHashEncrypt(string txt)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAParameters public_key = RSA.ExportParameters(false);
            RSAParameters private_key = RSA.ExportParameters(true);
            RSA.ImportParameters(public_key);
            byte[] textData = ByteConverter.GetBytes(txt);
            byte[] output = RSA.Encrypt(textData, false);
            Data_From_User2ToUser1.EventHandler(output, private_key);
        }
        public void RSAHashDecrypt(byte[] data, RSAParameters key)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(key);
            byte[] msg = RSA.Decrypt(data, false);
            richTextBox2.Text = ByteConverter.GetString(msg) + richTextBox2.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = Application.OpenForms[0];
            Form1.Close();
        }
    }
}
