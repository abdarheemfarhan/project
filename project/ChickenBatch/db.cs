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
    {
        static DataTable dt = new DataTable();

        public static async void view_all(string link, DataTable ds, DataGridView dataGridView)
        {
            DataTable s = new DataTable();
            s = ds;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(link);
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
                            dataGridView.DataSource = s;
                            dataGridView.Refresh();
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
            s = dt;
        }
        public static async void delete_all(string index, string city_id, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {index,city_id }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responseString = await response.Content.ReadAsStringAsync();

        }
        public static async void Insert_city(string name, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "city_name", name },
        };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }


        /* public static async void delete_city(string city_id,string link)
          {
              var client = new HttpClient();
              var values = new Dictionary<string, string> {
                  {"city_id",city_id }
              };
              var content =  new  FormUrlEncodedContent(values);
              var response = await client.PostAsync(link, content);
              var responseString = await response.Content.ReadAsStringAsync();

          }

        */  //   ------------------------------------------------------   province_id    -----------------------------------------------------------

        public static async void Insert_province(string name, int city_id, string link)
        {
            var client = new HttpClient();
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



        //-------------------------------------------------------     araes     ---------------------------------------------------------

        public static async void insert_areas(string name_areas, int province_id, string link)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string> {
                {"area_name",name_areas},
                {"province_id",province_id.ToString()},
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(link, content);
            var responsestring = await response.Content.ReadAsStringAsync();

        }



        //-------------------------------------------------------        project        -------------------------------------------------


        public static async void Insert_project(string project_name, int city_id,int prov_id,int area_id,string create_dare,string details,string link)
        {
           
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "project_name", project_name },
            { "city_id", city_id.ToString() },
            { "prov_id", prov_id.ToString() },
            { "area_id", area_id.ToString() },
            { "create_dare", create_dare },
            { "details", details },
        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void update_project(string project_id, string project_name, int city_id, int prov_id, int area_id, string create_dare, string details, string link)
        {

            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
            { "project_id", project_id },
            { "project_name", project_name },
            { "city_id", city_id.ToString() },
            { "prov_id", prov_id.ToString() },
            { "area_id", area_id.ToString() },
            { "create_dare", create_dare },
            { "details", details },
        };

            var content = new FormUrlEncodedContent(values);
            // إرسال البيانات إلى سكربت PHP
            var response = await client.PostAsync(link, content);
            // طباعة نتيجة الاستجابة
            var responseString = await response.Content.ReadAsStringAsync();
        }


        //------------------------------------------------  selelct combox all  ---------------------------------------------
        public static async void view_combox_provinse(ComboBox combox_proinces, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<Item>>(response);
                    combox_proinces.DataSource = items;
                    combox_proinces.DisplayMember = "province_name"; // عرض الاسم
                    combox_proinces.ValueMember = "province_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }
        public static async void view_combox_city(ComboBox combox_city, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_city>>(response);
                    combox_city.DataSource = items;
                    combox_city.DisplayMember = "city_name"; // عرض الاسم
                    combox_city.ValueMember = "city_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }
        public static async void view_combox_arare(ComboBox combox_city, string link)
        {
            try
            {
                var client = new HttpClient();
                {
                    // استدعاء API الخاص بـ PHP
                    var response = await client.GetStringAsync(link);
                    // تحليل البيانات من JSON
                    var items = JsonConvert.DeserializeObject<List<com_arera>>(response);
                    combox_city.DataSource = items;
                    combox_city.DisplayMember = "area_name"; // عرض الاسم
                    combox_city.ValueMember = "area_id";    // تخزين الرقم
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }
    }



    //-----------------------------------------------------------    class_get_combox   --------------------------------------------------
    public class com_city
    {
        public int city_id { get; set; }
        public string city_name { get; set; }
    }
    public class com_arera
    {
        public int area_id { get; set; }
        public string area_name { get; set; }

    }
}

