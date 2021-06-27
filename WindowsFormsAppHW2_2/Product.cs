using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppHW2_2
{
    public class Product
    {
        public string Title { get; set; }
        public string Characteristic { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string title, string ch, string desc, double price)
        {
            Title = title;
            Characteristic = ch;
            Description = desc;
            Price = price;
        }

        public Product() : this("Title", "Characteristics", "Description", 0) { }
    }
}
