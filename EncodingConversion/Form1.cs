using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncodingConversion
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private byte[] StringToBytes(string TheString)
        {
            Encoding FormEcoding = Encoding.GetEncoding("UTF-8");
            Encoding ToEcoding = Encoding.GetEncoding("gb2312");
            byte[] FormBytes = FormEcoding.GetBytes(TheString);
            byte[] Tobytes = Encoding.Convert(FormEcoding, ToEcoding, FormBytes);
            return Tobytes;
        }
        private string BytesToString(byte[] Bytes)
        {
            string Mystring;
            Encoding FormEcoding = Encoding.GetEncoding("gb2312");
            Encoding ToEcoding = Encoding.GetEncoding("UTF-8");
            byte[] Tobytes = Encoding.Convert(FormEcoding, ToEcoding, Bytes);
            Mystring = ToEcoding.GetString(Tobytes);
            return Mystring;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] StringsToByte = StringToBytes(textBox1.Text);
            textBox2.Text = "";
            foreach (byte MyByte in StringsToByte)
            {
                string Str = MyByte.ToString("x").ToUpper();
                textBox2.Text += "0x" + (Str.Length == 1 ? "0" + Str : Str) + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[textBox3.Text.Length / 2];//两个字节表示一个汉字
            int i;
            try
            {
                string buffer = textBox3.Text;
                buffer = buffer.Replace("0x", string.Empty);
                buffer = buffer.Replace(" ", string.Empty);
                for (i = 0; i < buffer.Length / 2; i++)
                {
                    data[i] = Convert.ToByte(buffer.Substring(i * 2, 2), 16);
                }
                textBox4.Text = BytesToString(data);
            }
            catch 
            {
                MessageBox.Show("数据转换错误，请输入数字。", "错误");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
