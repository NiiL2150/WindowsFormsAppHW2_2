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

namespace WindowsFormsAppHW2_2
{
    public partial class Form1 : Form
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private List<Product> cart = new List<Product>();
        public int opened = 0;
        private double sum = 0;

        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            XmlSerializer xs;
            try
            {
                xs = new XmlSerializer(typeof(List<Product>));
                using (var sr = new StreamReader("Products.xml"))
                {
                    Products = (List<Product>)xs.Deserialize(sr);
                }
                foreach (var item in Products)
                {
                    comboBox1.Items.Add(item.Title);
                }
            }
            catch (FileNotFoundException)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (opened != 0);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Products.Sort();
            XmlSerializer xs = new XmlSerializer(typeof(List<Product>));
            TextWriter tw = new StreamWriter("Products.xml");
            xs.Serialize(tw, Products);
            tw.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Products[comboBox1.SelectedIndex].Price.ToString("F2");
            textBox2.Text = Products[comboBox1.SelectedIndex].Title + "\n";
            textBox2.Text += Products[comboBox1.SelectedIndex].Characteristic + "\n";
            textBox2.Text += Products[comboBox1.SelectedIndex].Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(Products[comboBox1.SelectedIndex].Title);
            cart.Add(Products[comboBox1.SelectedIndex]);
            sum += Products[comboBox1.SelectedIndex].Price;
            label1.Text = sum.ToString("F2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cart.Remove(listBox1.SelectedItem as Product);
            sum -= Products[comboBox1.SelectedIndex].Price;
            label1.Text = sum.ToString("F2");
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            opened++;
            form.Show(this);
        }
    }
}
