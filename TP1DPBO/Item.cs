using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1DPBO
{
    class Item
    {
        public string name { get; set; }
        public int price { get; set; }
        public string jenis { get; set; }
        public string desc { get; set; }

        public Item(string name, int price, string jenis, string desc)
        {
            this.name = name;
            this.price = price;
            this.jenis = jenis;
            this.desc = desc;
        }
        public Item() { }
    }
}
