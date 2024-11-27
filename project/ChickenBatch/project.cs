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
    public partial class project : Form
    {
        DataTable dt = new DataTable();
        
        public project()
        {
            InitializeComponent();
        }

        private void project_Load(object sender, EventArgs e)
        {
            view();
            
        }
        async void view()
        {

            DataTable ds = new DataTable();
            // string url = "http://localhost/poultry2_mangemantdb2/ChickenBatch/city.php?mask=select_city";
            /*
            using (HttpClient client = new HttpClient())
             {
                 try
                 {
                     // إرسال طلب GET
                     HttpResponseMessage response = await client.GetAsync(Link.link.select_project);
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
                             dataGridView2.Columns[2].HeaderText = " المدينة";
                             dataGridView2.Columns[3].HeaderText = " المحافظة";
                             dataGridView2.Columns[4].HeaderText = " المنطقة";
                             dataGridView2.Columns[5].HeaderText = "  تاريخ الانشاء";
                             dataGridView2.Columns[6].HeaderText = " التفاصيل";
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
            */
           
            dataGridView2.DataSource = await HttpRequest.HttpRequest.select_data(Link.link.select_project); ;
            dataGridView2.Columns[0].HeaderText = "الرقم";
            dataGridView2.Columns[1].HeaderText = "اسم المشروع";
            dataGridView2.Columns[2].HeaderText = " المدينة";
            dataGridView2.Columns[3].HeaderText = " المحافظة";
            dataGridView2.Columns[4].HeaderText = " المنطقة";
            dataGridView2.Columns[5].HeaderText = "  تاريخ الانشاء";
            dataGridView2.Columns[6].HeaderText = " التفاصيل";
        
            DataTable city = await HttpRequest.HttpRequest.select_data(Link.link.select_city);
            DataTable prov = await HttpRequest.HttpRequest.select_data(Link.link.select_prov);
            DataTable areas = await HttpRequest.HttpRequest.select_data(Link.link.select_area);
           

            ComboBox_city.DataSource = city;
            ComboBox_city.DisplayMember = "city_name";
            ComboBox_city.ValueMember = "city_id";

            combox_prov.DataSource = prov;
            combox_prov.DisplayMember = "province_name";
            combox_prov.ValueMember = "province_id";


            combox_area.DataSource = areas;
            combox_area.DisplayMember = "area_name";
            combox_area.ValueMember = "area_id";




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            text_name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            text_datals.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string> {
                { "project_name",$"{text_name.Text}"},
             { "city_id",$"{ComboBox_city.SelectedValue}"},
             { "prov_id",$"{combox_prov.SelectedValue}"},
             { "area_id",$"{combox_area.SelectedValue}"},
             { "create_dare",$"{create_date.Value}"},
             { "details",$"{text_datals.Text}"},
            };
            HttpRequest.HttpRequest.insert_data(Link.link.add_project
                , values);
        }
    }
}
           
