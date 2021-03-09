using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkyeCenter
{
    public partial class Form4 : Form
    {
        DateTime a =new DateTime();
        public Form4()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void upd(DataGridView gv)
        {
            dbDataContext db = new dbDataContext();
            var tb = from x in db.coats
                     orderby x.id descending
                     select x;
            gv.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                textBox1.Text.Equals("") &&
                textBox2.Text.Equals("") &&
                textBox3.Text.Equals("") &&
                textBox4.Text.Equals("") &&
                textBox5.Text.Equals("") &&
                textBox6.Text.Equals("") &&
                textBox8.Text.Equals("") &&
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الكوت المراد تعديل بياناته");
                }
                else if (
                textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals("") ||
                textBox5.Text.Equals("") ||
                textBox6.Text.Equals("") ||
                textBox8.Text.Equals("") ||
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الكوت المراد تعديل بياناته");
                }
                else
                {
                    cls_userLinq.UpdateCoats(Convert.ToInt32(textBox1.Text), double.Parse(textBox4.Text), double.Parse(textBox3.Text), double.Parse(textBox6.Text), double.Parse(textBox5.Text), double.Parse(textBox8.Text), richTextBox1.Text, dateTimePicker1.Value.ToString(), Convert.ToInt32(textBox2.Text));
                    MessageBox.Show("تم تعديل بيانات الكوت بنجاح");
                    upd(dataGridView1);
                }

            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                textBox1.Text.Equals("") &&
                textBox2.Text.Equals("") &&
                textBox3.Text.Equals("") &&
                textBox4.Text.Equals("") &&
                textBox5.Text.Equals("") &&
                textBox6.Text.Equals("") &&
                textBox8.Text.Equals("") &&
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الكوت المراد حذفه");
                }
                else if (
                textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals("") ||
                textBox5.Text.Equals("") ||
                textBox6.Text.Equals("") ||
                textBox8.Text.Equals("") ||
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الكوت المراد حذفه");
                }
                else
                {
                    cls_userLinq.DeleteCoats(Convert.ToInt32(textBox1.Text));
                    MessageBox.Show("تم حذف الكوت بنجاح");
                    upd(dataGridView1);
                }

            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                if (
                textBox2.Text.Equals("") &&
                textBox3.Text.Equals("") &&
                textBox4.Text.Equals("") &&
                textBox5.Text.Equals("") &&
                textBox6.Text.Equals("") &&
                textBox8.Text.Equals("") &&
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء ادخال المقاسات الفارغة");
                }
                else if (
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals("") ||
                textBox5.Text.Equals("") ||
                textBox6.Text.Equals("") ||
                textBox8.Text.Equals("") ||
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء ادخال المقاسات الفارغة");
                }
                else 
                {
                    cls_userLinq.InsertCoats(double.Parse(textBox4.Text), double.Parse(textBox3.Text), double.Parse(textBox6.Text), double.Parse(textBox5.Text), double.Parse(textBox8.Text), richTextBox1.Text, dateTimePicker1.Value.ToString(), Convert.ToInt32(textBox2.Text));
                    MessageBox.Show("تم إضافة الكوت الى العميل");
                    fillcoats();
                }

            }
            catch (Exception z) {
                MessageBox.Show(z.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox10.Text = "";
            textBox14.Text = "";
            richTextBox1.Text = "";
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void الاكواتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void الاثوابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            fillcoats();
            a = DateTime.Now;
            //textBox7.Text = a.ToString("dd.MM.yyyy");
            dataGridView1.Columns[0].HeaderCell.Value = "رقم الكوت";
            dataGridView1.Columns[1].HeaderCell.Value = "الطول";
            dataGridView1.Columns[2].HeaderCell.Value = "الكتف";
            dataGridView1.Columns[3].HeaderCell.Value = "طول اليد";
            dataGridView1.Columns[4].HeaderCell.Value = "الصدر";
            dataGridView1.Columns[5].HeaderCell.Value = "البطن";
            dataGridView1.Columns[6].HeaderCell.Value = "التفاصيل";
            dataGridView1.Columns[7].HeaderCell.Value = "التاريخ";
            dataGridView1.Columns[8].HeaderCell.Value = "رقم العميل";
        }

        void fillcoats() {
            cls_userLinq.GetAllCoats(dataGridView1);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

            try
            {
                cls_userLinq.SearchCoatsByCustomerID(dataGridView1, Convert.ToInt32(textBox14.Text));
            }

            catch (Exception z)
            {
                if (textBox14.Text.Equals(""))
                {
                    fillcoats();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string coatID = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                    string tall = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                    string shoulder = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                    string hand = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                    string chest = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                    string abdomen = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                    string details = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                    string date = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                    string customer_id = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;

                    textBox1.Text = coatID;
                    textBox2.Text = customer_id;
                    textBox3.Text = shoulder;
                    textBox4.Text = tall;
                    textBox5.Text = chest;
                    textBox6.Text = hand;
                    dateTimePicker1.Value = Convert.ToDateTime(date);
                    textBox8.Text = abdomen;
                    richTextBox1.Text = details;
                }
            }
            catch (Exception z)
            {

                MessageBox.Show(z.Message);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try {
                cls_userLinq.SearchByBillID22(dataGridView1, textBox10.Text);
            }
            catch (Exception z) {
                MessageBox.Show(z.Message);
            }
        }

        private void إعادةتشغيلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
