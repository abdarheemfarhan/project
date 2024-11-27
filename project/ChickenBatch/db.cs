using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.ChickenBatch
{
   public static class db
    {  static DataTable dt = new DataTable();
        
      public  static async void view_all(string link,DataTable ds,DataGridView dataGridView)
        {
            DataTable s = new DataTable();
           s=ds ;
            //DataTable ds = new DataTable();
            // string url = "http://localhost/poultry2_mangemantdb2/ChickenBatch/projects.php?mask=select_project";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // إرسال طلب GET
                    HttpResponseMessage response = await client.GetAsync(link);
                    // إذا كانت الاستجابة ناجحة
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        // var s = JsonConvert.DeserializeObject<Dictionary<string,object>>(responseData);
                        var f = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseData);
                        foreach (var key in f[0].Keys)
                        {
                            s.Columns.Add(key);
                        }
                        foreach (var row in f)
                        {

                            var ro = s.NewRow();
                            foreach (var kvp in row)
                            {
                                ro[kvp.Key] = kvp.Value;
                            }
                            s.Rows.Add(ro);
                            //City x = new City();
                          //  dataGridView.Refresh();
                            dataGridView.DataSource = s;
                            dataGridView.Refresh();
                           
                          // dataGridView.Columns[0].HeaderText = "الرقم";
                          // dataGridView.Columns[1].HeaderText = "اسم المدينة";

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


            //ff=s;
            DataTable ff = new DataTable();

            s = dt;

        }
        public static async void Insert_city(string name,string link)
        {
            //BindingContext[dt].AddNew();
            var client = new HttpClient();
            // البيانات التي سيتم إرسالها إلى PHP
            var values = new Dictionary<string, string>
            {
            { "city_name", name },
        };
            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }


       public static async void delete_city(string city_id,string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {"city_id",city_id }
            };
            var content =  new  FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responseString = await response.Content.ReadAsStringAsync();
        
        }

        //   ------------------------------------------------------   province_id    -----------------------------------------------------------

        public static async void Insert_province(string name,int city_id, string link)
        {
            //BindingContext[dt].AddNew();
            var client = new HttpClient();
            // البيانات التي سيتم إرسالها إلى PHP
            var values = new Dictionary<string, string>
            {
            { "province_name", name },
            { "city_id", city_id.ToString() },

        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public static async void delete_province(string index,string city_id, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {index,city_id }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responseString = await response.Content.ReadAsStringAsync();

        }

        //-------------------------------------------------------     araes     ---------------------------------------------------------

       public static async void insert_areas(string name_areas,int province_id,string link) {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {"area_name",name_areas},
                {"province_id",province_id.ToString()},
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responsestring = await response.Content.ReadAsStringAsync();
            
        }
    }
}
