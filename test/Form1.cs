using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = "";
            SQL_OWO owo = new SQL_OWO();
            List<Shard> test = owo.GetAll();
            test.ForEach(shard =>
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                shard.datum,
                shard.cislo.ToString(),
                shard.odberatel,
                shard.nazev,
                shard.pocet,
                shard.cenaza.ToString(),
                shard.celkcena.ToString(),
                shard.DPH.ToString(),
                shard.cenasDPH.ToString(),
                });

                listView1.Items.Add(item);
                
            });

        }
    }
}
