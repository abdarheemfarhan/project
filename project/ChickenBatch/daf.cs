using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace project.ChickenBatch
{
    public partial class daf : Form
    {
        DataTable dt = new DataTable();
        public daf()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
            int d = await db.select_data_id("http://localhost/poultry2_mangemantdb2/ChickenBatch/se.php?mask=a", "batch_id");
            text_number_batch_id.Text =  d.ToString();
            b_add.Enabled = false;
            b_sava.Enabled = true;
            b_update.Enabled = false;
            b_delete.Enabled = false;
            // dataGridView2.Rows.Add();
        }
        private async void daf_Load(object sender, EventArgs e)
        {
           
            // MessageBox.Show(data_batch.ValueChanged.);
            dt = await db.select_data(Link.link.url_select_chicken_batch_tab);
            dataGridView2.DataSource = dt;
            db.Fill_comobox(await db.select_data(Link.link.url_select_chicken), combox_chicken_type);
            text_number_batch_id.DataBindings.Add("text", dt, "batch_id");
            combox_chicken_type.DataBindings.Add("SelectedValue", dt, "chicken_type");
            combox_project.DataBindings.Add("SelectedValue", dt, "project_id");
            combox_users.DataBindings.Add("SelectedValue", dt, "user_id");
            data_batch.DataBindings.Add("Value", dt, "date_in",true);
            text_f.DataBindings.Add("text", dt, "unknow");
            text_datals_batch.DataBindings.Add("text", dt, "details");
            db.Fill_data_comobox( await db.select_data(Link.link.url_select_farm), farm);
            db.Fill_data_comobox(dt, project);
            b_sava.Enabled = false;
           
        }

        private async void combox_project_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Fill_comobox(await db.select_data(Link.link.url_select_users), combox_users);
        }

        private async void combox_chicken_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Fill_comobox(await db.select_data(Link.link.select_project), combox_project);

        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            BindingContext[dt].CancelCurrentEdit();
            b_add.Enabled = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل=" + text_number_batch_id.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.delete_all("batch_id", text_number_batch_id.Text, Link.link.url_delete_chicken_batch_tab);
                BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Refresh();

            var values = new Dictionary<string, string>
            {
            { "chicken_type",$"{combox_chicken_type.SelectedValue}"},
            { "project_id",$"{combox_project.SelectedValue}"},
            { "user_id",Convert.ToInt16(combox_users.SelectedValue).ToString()},
            { "date_in",$"{data_batch. Text}"},
            { "unknow", $"{text_f.Text}"},
            { "details",$"{text_datals_batch.Text}"},

        };
            dataGridView2.Refresh();
            db.insert_all(values, Link.link.url_add_chicken_batch_tab);
            BindingContext[dt].EndCurrentEdit();
            dataGridView2.Refresh();
            dg.Refresh();
            b_sava.Enabled = false;
            b_update.Enabled = true;
            b_delete.Enabled = true;
            //BindingContext[d].AddNew();     
            dg.Rows.Add();
            dg.CurrentRow.Cells[0].Value = 1;
        }

        private async void combox_chicken_type_ControlAdded(object sender, ControlEventArgs e)
        {

        }
        private async void combox_chicken_type_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void text_f_TextChanged(object sender, EventArgs e)
        {

        }

        private void dg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dg_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                MessageBox.Show("التاكد من ادخل جميع البيانات", "c", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
                e.Cancel = false;
                //BindingContext[d].CancelCurrentEdit();
        }
        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        DataTable d = new DataTable();
        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            dg.DataSource = d;
            BindingContext[d].AddNew();
            dg.CurrentRow.Cells[0].Value = 1;
        }
        private void dg_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dg.CurrentRow.Cells[0].Value!= null && dg.CurrentRow.Cells[1].Value != null
                     && dg.CurrentRow.Cells[2].Value != null&& dg.CurrentRow.Cells[3].Value != null)
            {
                if (e.RowIndex == dg.Rows.Count - 1 && e.ColumnIndex == dg.Columns.Count - 1)
                {
                    var values = new Dictionary<string, string>
                {
                    {"batch_id",dg.CurrentRow.Cells[1].Value.ToString()},
                    {"farm_id",dg.CurrentRow.Cells[2].Value.ToString()},
                    {"quantity",dg.CurrentRow.Cells[3].Value.ToString()}
                };
                    db.insert_all(values, Link.link.url_add_batch_details);
                    BindingContext[d].AddNew();
                    for (int i = 1; i < dg.Rows.Count + 1; i++)
                    {
                        dg.CurrentRow.Cells[0].Value = i;
                    }
                } 
            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            b_add.Enabled = true;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
        }
        private void dg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(e.Control is ComboBox comboBox)
            {
                comboBox.DropDownHeight = 70;
            }
        }
    }
 }
