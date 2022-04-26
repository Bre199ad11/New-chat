using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }
        
        byte[] output;
        //Form2 form2 = new Form2();
         
        public void TxtChanged(byte[] input)
        {
           
            //InitializeComponent();
            richTextBox2.Text = "kdkdk"; //BitConverter.ToString(input).Replace("-", String.Empty).ToLower();
            
           
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //byte[] input = form2.output;
        }

        public void richTextBox2_TextChanged(object sender, EventArgs e)
        {
           // richTextBox2.Text = BitConverter.ToString(input).Replace("-", String.Empty).ToLower();
        }
    }
}
