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
using DevExpress.XtraReports.UI;

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


        void RecalcTotalTable() 
        {
            int s = 0, a, b, c, d;
            if (checkBox1.Checked)
            {                
                pictureBox1.Image = Image.FromFile("1.jpg");
                a = Convert.ToInt32(numericUpDown1.Value);
                s = s + (a * 17000);
            }
            else
            {
                pictureBox1.Image = null;
            }
            if (checkBox2.Checked)
            {                
                pictureBox2.Image = Image.FromFile("2.jpg");
                b = Convert.ToInt32(numericUpDown2.Value);
                s = s + (b * 12000);
            }
            else
            {
                pictureBox2.Image = null;
            }
            if (checkBox3.Checked)
            {                
                pictureBox3.Image = Image.FromFile("3.jpg");
                c = Convert.ToInt32(numericUpDown3.Value);
                s = s + (c * 6000);
            }
            else
            {
                pictureBox3.Image = null;
            }
            if (checkBox4.Checked)
            {                
                pictureBox4.Image = Image.FromFile("4.jpg");
                d = Convert.ToInt32(numericUpDown4.Value);
                s = s + (d * 8000);
            }
            else
            {
                pictureBox4.Image = null;
            }
            label10.Text = s.ToString();

            
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
                var line = new ProductList();
                pd.Items = new List<ProductList>();
                if (checkBox1.Checked)
                    //pd.Items.Add(ProductType.Hol);
                    pd.Items.Add(new ProductList() { Type = ProductType.Hol, Quantity = (Int32) numericUpDown1.Value });
                if (checkBox2.Checked)
                    //pd.Items.Add(ProductType.Stir);
                    pd.Items.Add(new ProductList() { Type = ProductType.Stir, Quantity = (Int32)numericUpDown2.Value });
                if (checkBox3.Checked)
                    //pd.Items.Add(ProductLType.CVH);
                    pd.Items.Add(new ProductList() { Type = ProductType.CVH, Quantity = (Int32)numericUpDown3.Value });
                if (checkBox4.Checked)
                    //pd.Items.Add(ProductType.Plita);
                    pd.Items.Add(new ProductList() { Type = ProductType.Plita, Quantity = (Int32)numericUpDown4.Value });
                

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

                foreach(var line in pd.Items)
                {
                    if(line.Type==ProductType.Hol)
                    {                
                        checkBox1.Checked = true; numericUpDown1.Value = line.Quantity;
                    }
                    if (line.Type == ProductType.Stir)
                    {
                        checkBox2.Checked = true; numericUpDown2.Value = line.Quantity;
                    }
                    if (line.Type == ProductType.CVH)
                    {
                        checkBox3.Checked = true; numericUpDown3.Value = line.Quantity;
                    }
                    if (line.Type == ProductType.Plita)
                    {
                        checkBox4.Checked = true; numericUpDown4.Value = line.Quantity;
                    }
                }               
            }
        }

        private ShopData CreateShopData()
        {
            ShopData sd = new ShopData();
            sd.Items = new List<ProductList>();
            return sd;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotalTable();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = listBox1.SelectedItem != null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var xr = new XtraReport1();
            ShopData sd = CreateShopData();
            xr.DataSource = new BindingSource() { DataSource = sd };
            xr.ShowPreview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var pl = new ProductList
            {
                Hol = checkBox1.Checked,
                Stir = checkBox2.Checked,
                CVH = checkBox3.Checked,
                Plita = checkBox4.Checked,
                n1 = numericUpDown1.Value,
                n2 = numericUpDown2.Value,
                n3 = numericUpDown3.Value,
                n4 = numericUpDown4.Value,
            };
            
            
            listBox1.Items.Add(pl);
        }
    }

    public class ShopData
    {
        public ProductType product { get; set; }
        public List<ProductList> Items { get; set; }

        /*[XmlIgnore]
        public string Caption
        {            
            get 
            {
                if (product == ProductType.Hol)
                { return "Холодильник"; }
                if (product == ProductType.Stir)
                { return "Стиралка"; }
                if (product == ProductType.CVH)
                { return "Печь"; }
                return "плита";
            }
        }*/
    }
    public class ProductList
    {
        public ProductType Type { get; set; }
        public int Quantity { get; set; }
        public bool Hol { get; set; }
        public bool Stir { get; set; }
        public bool CVH { get; set; }
        public bool Plita { get; set; }
        public decimal n1 { get; set; }
        public decimal n2 { get; set; }
        public decimal n3 { get; set; }
        public decimal n4 { get; set; }
       
        [XmlIgnore]
        public string BarCode
        {
            get
            {
                return this.ToString();               
            }
        }

        [XmlIgnore]
        public string Description 
        { 
            get 
            { 
                return this.ToString(); 
            } 
        }

        public override string ToString()
        {
            var s = ".";
            if (Hol)
                s = "Холодильник " + n1 + "шт, " + s;
            if (Stir)
                s = "Стиральная машина " + n2 + "шт, " + s;
            if (CVH)
                s = "СВЧ печь " + n3 + "шт, " + s;
            if (Plita)
                s = "Плита " + n4 + "шт, " + s;
            return s;
        }
    }
    public enum ProductType
    {
        Hol, Stir, CVH, Plita
    }
}
