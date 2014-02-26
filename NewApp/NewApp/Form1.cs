using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NewApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            int s = 0, a, b, c, d;
            if (checkBox1.Checked)
            {
                a = Convert.ToInt32(numericUpDown1.Value);
                s = s + (a*17000);
            }
            if (checkBox2.Checked)
            {
                b = Convert.ToInt32(numericUpDown2.Value);
                s = s + (b*12000);
            } 
            if (checkBox3.Checked)
            {
                c = Convert.ToInt32(numericUpDown3.Value);
                s = s + (c*6000);
            }
            if (checkBox4.Checked)
            {
                d = Convert.ToInt32(numericUpDown4.Value);
                s = s + (d*8000);
            }
            label10.Text = s.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "покупка|*.shopml" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileName = sfd.FileName;
                ShopData pd = new ShopData();
                pd.ItemType = new List<ShopType>();
                //pd.ItemType.Add(ShopType.Plita);
                if (checkBox1.Checked)
                pd.ItemType.Add(ShopType.Hol);
                if (checkBox2.Checked)
                pd.ItemType.Add(ShopType.Stir);
                if (checkBox3.Checked)
                pd.ItemType.Add(ShopType.CVH);
                if (checkBox4.Checked)
                pd.ItemType.Add(ShopType.Plita);

                XmlSerializer xs = new XmlSerializer(typeof(ShopData));
                var fileStream = File.Create(fileName);
                xs.Serialize(fileStream, pd);
                fileStream.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "покупка|*.shopml" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var xs = new XmlSerializer(typeof(ShopData));
                var file = File.Open(ofd.FileName, FileMode.Open);
                var pd = (ShopData)xs.Deserialize(file);
                file.Close();

                checkBox1.Checked = pd.ItemType.Contains(ShopType.Hol);
                checkBox2.Checked = pd.ItemType.Contains(ShopType.Stir);
                checkBox3.Checked = pd.ItemType.Contains(ShopType.CVH);
                checkBox4.Checked = pd.ItemType.Contains(ShopType.Plita);
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int s = 0, a, b, c, d;
            if (checkBox1.Checked)
            {
                a = Convert.ToInt32(numericUpDown1.Value);
                s = s + (a * 17000);
            }
            if (checkBox2.Checked)
            {
                b = Convert.ToInt32(numericUpDown2.Value);
                s = s + (b * 12000);
            }
            if (checkBox3.Checked)
            {
                c = Convert.ToInt32(numericUpDown3.Value);
                s = s + (c * 6000);
            }
            if (checkBox4.Checked)
            {
                d = Convert.ToInt32(numericUpDown4.Value);
                s = s + (d * 8000);
            }
            label10.Text = s.ToString();
        }

      

    
    }
    public class ShopData
    {
        //List<ShopType> ItemType {get;set;}
        public List<ShopType> ItemType { get; set; }
        /*pd.ItemType = new List<ShopType>();
        pd.ItemType.Add(ShopType.Plita);
        public List<ShopType> ItemType { get; set; }*/
    }
    public enum ShopType
    {
        Hol, Stir, CVH, Plita
    }
}
