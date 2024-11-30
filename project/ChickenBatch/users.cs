using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.ChickenBatch
{
    public partial class users : Form
    {
        DataTable dt = new DataTable();
        public users()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void users_Load(object sender, EventArgs e)
        {
            db.view_all(Link.link.url_select_users, dt, dataGridView2);
            db.view_combox_job(combox_job, Link.link.url_select_job);
            db.view_combox_city(combox_city_users, Link.link.url_select_city);
        }

        private async void combox_city_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Delay(100);
            db.view_combox_provinces(combox_provinces_users, Convert.ToInt16(combox_city_users.SelectedValue));
            //MessageBox.Show("" + Convert.ToInt16(combox_city_users.SelectedValue));
        }

        private async void combox_provinces_users_SelectedIndexChanged(object sender, EventArgs e)
        {
                await Task.Delay(50);
                db.view_combox_arare_id(combox_arera_users, Convert.ToInt16(combox_provinces_users.SelectedValue));
        }

        private async void combox_provinces_users_Click(object sender, EventArgs e)
        {
            
        }
        private async void users_Shown(object sender, EventArgs e)
        {
            await Task.Delay(200);
            dataGridView2.Columns[0].HeaderText = "رقم المستخدم ";
            dataGridView2.Columns[1].HeaderText = "اسم المستخدم";
            dataGridView2.Columns[2].HeaderText = "الوظية";
            dataGridView2.Columns[3].HeaderText = "كلمة المرور ";
            dataGridView2.Columns[4].HeaderText = "تاكيد كلمة المرور ";
            dataGridView2.Columns[5].HeaderText = "الايميل";
            dataGridView2.Columns[6].HeaderText = "الهاتف ";
            dataGridView2.Columns[7].HeaderText = "المدينة";
            dataGridView2.Columns[8].HeaderText = "المحافظة";
            dataGridView2.Columns[9].HeaderText = "المنطقة";
            dataGridView2.Columns[10].HeaderText = "المنطقة";
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (text_name_users.Text.Trim() != "" && text_password_users.Text.Trim() != ""&& text_password_users_takd.Text.Trim() != "" && text_email_users.Text.Trim() != "" && text_phone_users.Text.Trim() != ""
                && combox_job.Text.Trim() != ""&& combox_city_users.Text.Trim() != ""&& combox_provinces_users.Text.Trim() != "")
            {
                if (text_password_users.Text.Trim() == text_password_users_takd.Text.Trim())
                {
                    DataTable d = new DataTable();
                    dt = d;
                    db.insert_usres(text_name_users.Text, text_password_users.Text, text_password_users_takd.Text,
                        text_email_users.Text, text_phone_users.Text, Convert.ToInt16(combox_job.SelectedValue),
                        Convert.ToInt16(combox_city_users.SelectedValue), Convert.ToInt16(combox_provinces_users.SelectedValue),
                        Convert.ToInt16(combox_arera_users.SelectedValue), text_datals_users.Text,
                        Link.link.url_add_users);
                    dataGridView2.Refresh();
                    db.view_all(Link.link.url_select_users, dt, dataGridView2);
                }

                MessageBox.Show("التاكد من كلمة المرور مع التاكيد");
            }
            else if (text_name_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الاسم");
            }
            else if (text_password_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل  كلمة المرور");
            }
            else if (text_password_users_takd.Text.Trim() == "")
            {
                MessageBox.Show("ادخل تاكيد كلمة المرور");
            }
            else if (text_email_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الايميل");
            }
            else if (text_phone_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل الرقم");
            }
            else if (combox_city_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل المدينة");
            }
            else if (combox_arera_users.Text.Trim() == "")
            {
                MessageBox.Show("ادخل المنطقة");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_name_users.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("user_id", text_number_users.Text, Link.link.url_delete_users);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_users.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_users.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            text_password_users.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            text_password_users_takd.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            text_email_users.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            text_phone_users.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            text_datals_users.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();







        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
