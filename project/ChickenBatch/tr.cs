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
    public partial class tr : Form
    {
        public tr()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ChickenBatch.chicken_batch_tab batch = new chicken_batch_tab();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();

            panel1.Controls.Add(batch);
            batch.Show();
        }

        private void tr_Load(object sender, EventArgs e)
        {
            ChickenBatch.chicken_batch_tab batch = new chicken_batch_tab();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();

            panel1.Controls.Add(batch);
            batch.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            f.AutoScroll = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(f);
            f.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ChickenBatch.project batch = new project();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();
          
            panel1.Controls.Add(batch);
            batch.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ChickenBatch.batch_details batch = new batch_details();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();
            panel1.Controls.Add(batch);
            batch.Show();


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ChickenBatch.farm batch = new farm();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();
            panel1.Controls.Add(batch);
            batch.Show();

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ChickenBatch.users batch = new users();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();
            panel1.Controls.Add(batch);
            batch.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            ChickenBatch.job batch = new job();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();
            panel1.Controls.Add(batch);
            batch.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            ChickenBatch.chicken batch = new chicken();
            batch.TopLevel = false;
            batch.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Clear();
            panel1.Controls.Add(batch);
            batch.Show();
            batch.WindowState = FormWindowState.Maximized;

        }
    }
}
