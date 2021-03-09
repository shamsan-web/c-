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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
           
            
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void fillCustomer() {
            cls_userLinq.GetAllCustomers(dataGridView1);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fillCustomer();
            dataGridView1.Columns[0].HeaderCell.Value = "الرقم التعريفي";
            dataGridView1.Columns[1].HeaderCell.Value = "اسم العميل";
            dataGridView1.Columns[2].HeaderCell.Value = "رقم التلفون";
            dataGridView1.Columns[3].HeaderCell.Value = "العنوان";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string customerID = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                    string CustomerName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                    string CustomerPhone = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                    string CustomerAddress = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;

                    textBox1.Text = customerID;
                    textBox2.Text = CustomerName;
                    textBox3.Text = CustomerPhone;
                    textBox4.Text = CustomerAddress;
                }
            }
            catch (Exception z) {

                MessageBox.Show(z.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (textBox1.Text.Equals("") && textBox2.Text.Equals("") && textBox3.Text.Equals("") && textBox4.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء ملئ البيانات");
                }
                else if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء ملئ البيانات");
                }
                else
                {
                    cls_userLinq.InsertCustomers(Convert.ToInt32(textBox1.Text),textBox2.Text.Trim(), Convert.ToInt32(textBox3.Text.Trim()), textBox4.Text.Trim());
                    MessageBox.Show("تم إضافة العميل بنجاح");
                    fillCustomer();
                }
            }
            catch (Exception z) {
                MessageBox.Show(z.Message);
            }
        }

        private void الاكواتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void الاثوابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("الرجاء تحديد العميل المراد حذفة من القائمة");
                }
                else {
                    cls_userLinq.DeleteCustomer(Convert.ToInt32(textBox1.Text));
                    MessageBox.Show("تم حذف العميل بنجاح");
                    fillCustomer();
                }
            }
            catch (Exception z) {
                MessageBox.Show(z.Message); 
            }

            
        }

        public void upd(DataGridView gv)
        {
            dbDataContext db = new dbDataContext();
            var tb = from x in db.customers
                     orderby x.id descending
                     select x;
            gv.DataSource = tb;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {

               
                if (
              textBox1.Text.Equals("") &&
              textBox2.Text.Equals("") &&
              textBox3.Text.Equals("") &&
              textBox4.Text.Equals("") 
              )
                {
                    MessageBox.Show("الرجاء تحديد العميل المراد تعديل بياناته");
                }
                else if (
                textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals("") 
                )
                {
                    MessageBox.Show("الرجاء تحديد العميل المراد تعديل بياناته");
                }
                else
                {
                    cls_userLinq.UpdateCustomers(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), textBox4.Text);
                    MessageBox.Show("تم تعديل بيانات العميل بنجاح");
                    upd(dataGridView1);
                }
            }
            catch (Exception z) {
                MessageBox.Show(z.Message);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try {
                cls_userLinq.SearchByCustomerName(dataGridView1, textBox10.Text);
            }
            catch (Exception z) {
                MessageBox.Show(z.Message);
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
           try
          {
                cls_userLinq.SearchByCustomerID(dataGridView1,Convert.ToInt32(textBox14.Text));

          }
          catch (Exception z) {

                if (textBox14.Text.Equals(""))
                {
                    upd(dataGridView1);
                }
            }
         
        }

        private void إعادةتشغيلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
