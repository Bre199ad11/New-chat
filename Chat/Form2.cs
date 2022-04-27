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
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    public partial class Form2 : Form
    {
        
        
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            Data_From_User2ToUser1.EventHandler = new Data_From_User2ToUser1.MyEvent(TxtChange);
        }


        private void TxtChange(byte[] data, RSAParameters key)
        {
            RSAHashDecrypt(data, key);
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
            Data_From_User1ToUser2.EventHandler(output, private_key);


        }
        public void RSAHashDecrypt(byte[] data, RSAParameters key)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(key);
            byte[] msg = RSA.Decrypt(data, false);
            richTextBox2.Text = ByteConverter.GetString(msg) + richTextBox2.Text;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = Application.OpenForms[0];
            Form1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg= DateTime.Now.ToLongTimeString() + ": " + richTextBox1.Text + "\r\n";
            RSAHashEncrypt(msg);
            richTextBox1.Text = null;
        }



        public void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
