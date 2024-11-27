using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.ChickenBatch
{
    public partial class City : Form
    {
        DataTable dt = new DataTable();
        public City()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        async void view(string d)
        {
            DataTable ds = new DataTable( );
            // string url = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=select_project";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // إرسال طلب GET
                    HttpResponseMessage response = await client.GetAsync(d);
                    // إذا كانت الاستجابة ناجحة
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        // var s = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseData);
                        var f = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseData);
                        foreach (var key in f[0].Keys)
                        {
                            ds.Columns.Add(key);
                        }
                        foreach (var row in f)
                        {

                            var ro = ds.NewRow();
                            foreach (var kvp in row)
                            {
                                ro[kvp.Key] = kvp.Value;
                            }

                            ds.Rows.Add(ro);

                            dataGridView2.DataSource = ds;
                            dataGridView2.Columns[0].HeaderText = "الرقم";
                            dataGridView2.Columns[1].HeaderText = "اسم المشروع";

                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            dt = ds;

        }
        private void City_Load(object sender, EventArgs e)
        {
            DataTable s = new DataTable();
            db.view_all(Link.link.url_select_city,dt,dataGridView2);
  

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            db.Insert_city(text_name_city.Text, Link.link.url_add_city);
            DataTable d = new DataTable();           
            db.view_all(Link.link.url_select_city, d, dataGridView2);
            d = dt;           
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_number_city.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            text_name_city.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            BindingContext[dt].AddNew();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هلا تريد حذف السجل="+text_name_city.Text, "تاكيد", MessageBoxButtons.OKCancel) == DialogResult.OK) { 
                  db.delete_all("city_id", text_number_city.Text, Link.link.url_delete_city);
               BindingContext[dt].RemoveAt(BindingContext[dt].Position);
            
            }
          
      



        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           
            BindingContext[dt].Position += 1;
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position -= 1;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            BindingContext[dt].Position = 0;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        { 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           // BindingContext[dt].Position = 0;
        }
    }
}
