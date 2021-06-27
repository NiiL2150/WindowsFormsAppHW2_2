using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHW2_2
{
    public partial class Form2 : Form
    {
        Form1 parentForm = null;

        public Form2()
        {
            InitializeComponent();
        }

        public void Show(Form1 form)
        {
            parentForm = form;
            base.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product(textBox1.Text, textBox2.Text, textBox3.Text, Double.Parse(textBox4.Text));
                parentForm.Products.Add(product);
                parentForm.comboBox1.Items.Add(product.Title);
            }
            catch (Exception)
            {

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentForm.opened--;
        }
    }
}
