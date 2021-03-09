using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkyeCenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
                Thread f = new Thread(new ThreadStart(startSplash));
                f.Start();
                Thread.Sleep(5000);
                InitializeComponent();
                f.Abort();
           
            
        }
        public void startSplash()
        {
            Application.Run(new splash());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") && textBox2.Text.Equals(""))
            {
                MessageBox.Show("الرجاء ادخال بيانات الدخول");
            }
            else if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("الرجاء ادخال بيانات الدخول");
            }
            else {
                cls_userLinq.login(textBox1.Text.Trim(), textBox2.Text.Trim());
                if (cls_userLinq.ran == true)
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else if (cls_userLinq.ran == false)
                {
                    MessageBox.Show("خطأ في الاسم او كلمة المرور");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
