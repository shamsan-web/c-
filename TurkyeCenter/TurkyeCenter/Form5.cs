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
    public partial class Form5 : Form
    {
        DateTime a = new DateTime();
        dbDataContext db = new dbDataContext();
        public Form5()
        {
            InitializeComponent();
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
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            fillAllCoats();
            a = DateTime.Now;
           // textBox13.Text = a.ToString("dd.MM.yyyy");
            dataGridView1.Columns[0].HeaderCell.Value = "رقم الثوب";
            dataGridView1.Columns[1].HeaderCell.Value = "الطول";
            dataGridView1.Columns[2].HeaderCell.Value = "الكتف";
            dataGridView1.Columns[3].HeaderCell.Value = "اليد 1";
            dataGridView1.Columns[4].HeaderCell.Value = "اليد 2";
            dataGridView1.Columns[5].HeaderCell.Value = "اليد 3";
            dataGridView1.Columns[6].HeaderCell.Value = "الرقبة";
            dataGridView1.Columns[7].HeaderCell.Value = "الصدر";
            dataGridView1.Columns[8].HeaderCell.Value = "الجبزور";
            dataGridView1.Columns[9].HeaderCell.Value = "الدور";
            dataGridView1.Columns[10].HeaderCell.Value = "التفاصيل";
            dataGridView1.Columns[11].HeaderCell.Value = "التاريخ";
            dataGridView1.Columns[12].HeaderCell.Value = "رقم العميل";

        }

        void fillAllCoats()
        {
            cls_userLinq.GetAllDress(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
            richTextBox1.Text = "";
        }
        void upda(DataGridView gv) {
            
            var tb = from x in db.dresses
                     orderby x.id descending
                     select x;
            gv.DataSource = tb;

        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try {
                cls_userLinq.SearchDressByCustomerID(dataGridView1, Convert.ToInt32(textBox14.Text));

            }
            catch (Exception z) {
                if (textBox14.Text.Equals(""))
                {
                    upda(dataGridView1);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string dressID = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                    string tall = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                    string shoulder = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                    string hand1 = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                    string hand2 = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                    string hand3 = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                    string neck = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                    string chest = dataGridView1.SelectedRows[0].Cells[7].Value + string.Empty;
                    string gbzor = dataGridView1.SelectedRows[0].Cells[8].Value + string.Empty;
                    string dowr = dataGridView1.SelectedRows[0].Cells[9].Value + string.Empty;
                    string details = dataGridView1.SelectedRows[0].Cells[10].Value + string.Empty;
                    string date = dataGridView1.SelectedRows[0].Cells[11].Value + string.Empty;
                    string customer_id = dataGridView1.SelectedRows[0].Cells[12].Value + string.Empty;

                    textBox1.Text = dressID;
                    textBox2.Text = customer_id;
                    textBox3.Text = shoulder;
                    textBox4.Text = tall;
                    textBox5.Text = hand2;
                    textBox6.Text = hand1;
                    textBox9.Text = hand3;
                    textBox7.Text = chest;
                    textBox8.Text = neck;
                    dateTimePicker1.Value = Convert.ToDateTime(date);
                    textBox11.Text = gbzor;
                    textBox12.Text = dowr;
                    richTextBox1.Text = details;
                }
            }
            catch (Exception z)
            {

                MessageBox.Show(z.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                
                textBox2.Text.Equals("") &&
                textBox3.Text.Equals("") &&
                textBox4.Text.Equals("") &&
                textBox5.Text.Equals("") &&
                textBox6.Text.Equals("") &&
                textBox7.Text.Equals("") &&
                textBox8.Text.Equals("") &&
                textBox9.Text.Equals("") &&
                textBox11.Text.Equals("") &&
                textBox12.Text.Equals("") &&
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
              textBox7.Text.Equals("") ||
              textBox8.Text.Equals("") ||
              textBox9.Text.Equals("") ||
              textBox11.Text.Equals("") ||
              textBox12.Text.Equals("") ||
              richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء ادخال المقاسات الفارغة");
                }
                else
                {
                    cls_userLinq.InsertDress(double.Parse(textBox4.Text), double.Parse(textBox3.Text), double.Parse(textBox6.Text), double.Parse(textBox5.Text), double.Parse(textBox9.Text), double.Parse(textBox8.Text), double.Parse(textBox7.Text), double.Parse(textBox11.Text), double.Parse(textBox12.Text), richTextBox1.Text, dateTimePicker1.Value.ToString(), Convert.ToInt32(textBox2.Text));
                    MessageBox.Show("تم إضافة الثوب بنجاح");
                    fillAllCoats();
                }

            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (

                textBox2.Text.Equals("") &&
                textBox3.Text.Equals("") &&
                textBox4.Text.Equals("") &&
                textBox5.Text.Equals("") &&
                textBox6.Text.Equals("") &&
                textBox7.Text.Equals("") &&
                textBox8.Text.Equals("") &&
                textBox9.Text.Equals("") &&
                textBox11.Text.Equals("") &&
                textBox12.Text.Equals("") &&
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الثوب المراد تعديل بياناته");
                }
                else if (

              textBox2.Text.Equals("") ||
              textBox3.Text.Equals("") ||
              textBox4.Text.Equals("") ||
              textBox5.Text.Equals("") ||
              textBox6.Text.Equals("") ||
              textBox7.Text.Equals("") ||
              textBox8.Text.Equals("") ||
              textBox9.Text.Equals("") ||
              textBox11.Text.Equals("") ||
              textBox12.Text.Equals("") ||
              richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الثوب المراد تعديل بياناته");
                }
                else
                {
                    cls_userLinq.UpdateDress(Convert.ToInt32(textBox1.Text), double.Parse(textBox4.Text), double.Parse(textBox3.Text), double.Parse(textBox6.Text), double.Parse(textBox5.Text), double.Parse(textBox9.Text), double.Parse(textBox8.Text), double.Parse(textBox7.Text), double.Parse(textBox11.Text), double.Parse(textBox12.Text), richTextBox1.Text, dateTimePicker1.Value.ToString(), Convert.ToInt32(textBox2.Text));
                    MessageBox.Show("تم تعديل الثوب بنجاح");
                    upda(dataGridView1);

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

                textBox2.Text.Equals("") &&
                textBox3.Text.Equals("") &&
                textBox4.Text.Equals("") &&
                textBox5.Text.Equals("") &&
                textBox6.Text.Equals("") &&
                textBox7.Text.Equals("") &&
                textBox8.Text.Equals("") &&
                textBox9.Text.Equals("") &&
                textBox11.Text.Equals("") &&
                textBox12.Text.Equals("") &&
                richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الثوب المراد حذف بياناته");
                }
                else if (

              textBox2.Text.Equals("") ||
              textBox3.Text.Equals("") ||
              textBox4.Text.Equals("") ||
              textBox5.Text.Equals("") ||
              textBox6.Text.Equals("") ||
              textBox7.Text.Equals("") ||
              textBox8.Text.Equals("") ||
              textBox9.Text.Equals("") ||
              textBox11.Text.Equals("") ||
              textBox12.Text.Equals("") ||
              richTextBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد الثوب المراد حذف بياناته");
                }
                else
                {
                    cls_userLinq.DeleteDress(Convert.ToInt32(textBox1.Text));
                    MessageBox.Show("تم حذف الثوب بنجاح");
                    upda(dataGridView1);
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
                cls_userLinq.SearchByBillID(dataGridView1, textBox10.Text);
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
