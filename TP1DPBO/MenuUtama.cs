using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1DPBO
{
    public partial class MenuUtama : Form
    {
        List<GroupBox> groupBoxes = new List<GroupBox>();
        private string uname;
        private string[] arrJenis = { "Jenis barang", "Elektronik", "Baju", "Makanan" };
        private string[] arrHarga = { "Harga", "100rb - 5jt", "5jt - 10jt", "10jt - 16jt" };
        private List<Item> arrItem = new List<Item>{
                new Item { name = "Hape Q2 Pro", price = 11000000, desc =  "Hape murah meriah kualitas nggk terjamin :')", jenis = "Elektronik"},
                new Item { name = "Kemeja", price = 7050000, desc = "Kemeja bekas, cuci gudang", jenis = "Baju" },
                new Item { name = "Tiramsu", price = 500000, desc = "Makanan manis", jenis = "Makanan" },
                new Item { name = "Laptop", price = 15700000, desc = "Laptop superkebut, internetan ngebut wuz wuz", jenis = "Elektronik" },
                new Item { name = "T-shirt", price = 1000000, desc = "Baju oblong, ada lubangnya 4 buah", jenis = "Baju" },
                new Item { name = "Ayam panggang", price = 2400000, desc = "Makanan halal dan begizi tinggi", jenis = "Makanan" }
        };
        private ListViewItem lvItem;
        private int btsBawah;
        private int btsAtas;

        public MenuUtama(string uname)
        {
            InitializeComponent();
            this.uname = uname;
            lblUname.Text = "Hi, " + uname + " :)";
            lblUname2.Text = "Hi, " + uname + " :)";
            /*TO DO:
             - nampilin detail barang
            */
        }

        private void pbLogout_Click(object sender, EventArgs e) => this.Close();

        private void lblLogout_Click(object sender, EventArgs e) => this.Close();

        private void pbCatalog_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://shopee.co.id/");

        private void lblWeb_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://shopee.co.id/");

        private void MenuUtama_Load(object sender, EventArgs e)
        {
            groupBoxes.Add(groupBox1);
            groupBoxes.Add(groupBox2);
            groupBoxes[0].Visible = true;
            groupBoxes[1].Visible = false;

            foreach (string jenis in arrJenis)
            {
                cbJenis.Items.Add(jenis);
            }
            foreach (string harga in arrHarga)
            {
                cbHarga.Items.Add(harga);
            }

            listView1.View = View.Tile;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            dummy();

        }
        private void dummy()
        {
            var i = 0;
            foreach(Item item in arrItem)
            {
                lvItem = new ListViewItem(item.name);
                lvItem.SubItems.Add(item.price.ToString());
                lvItem.SubItems.Add(item.jenis);
                lvItem.SubItems.Add(item.desc);
                listView1.Items.Add(lvItem);
                listView1.Items[i].ImageIndex = i;
                i++;
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            //menghapus list view yang sekarang
            listView1.Clear();
            listView1.Refresh();
            listView1.View = View.Tile;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if ((cbJenis.Text.ToString() == "Jenis barang") && (cbHarga.Text.ToString() == "Harga"))
            {
                //jika tidak ada yang ingin dicari, mungkin udah jenuh dengan serangkaian kisah yang membuat hatinya tersakiti oleh keadaan untuk memilih bertahan menanggung rasa sakit atau berpisah dengan memendam rasa suci ini sendiri 
                dummy();
            }
            else
            {
                //mencari batas harga barang yang dicari
                if(cbHarga.Text.ToString() != "Harga")
                {
                    if(cbHarga.Text.ToString() == "100rb - 5jt"){
                        btsBawah = 100000;
                        btsAtas = 5000000;
                    }
                    else if(cbHarga.Text.ToString() == "5jt - 10jt") { 
                        btsBawah = 5000000;
                        btsAtas = 10000000;
                    }
                    else if(cbHarga.Text.ToString() == "10jt - 16jt") { 
                        btsBawah = 10000000;
                        btsAtas = 16000000;
                    }
                }

                //mencari barang yang sesuai kata hati user
            
                if (cbHarga.Text.ToString() == "Harga")
                {
                    //jika hanya ada inputan pencarian jenis saja
                    var i = 0;
                    foreach(Item item in arrItem)
                    {
                        if(item.jenis == cbJenis.Text.ToString())
                        {
                            lvItem = new ListViewItem(item.name);
                            lvItem.SubItems.Add(item.price.ToString());
                            lvItem.SubItems.Add(item.jenis);
                            lvItem.SubItems.Add(item.desc);
                            listView1.Items.Add(lvItem);
                            listView1.Items[i].ImageIndex = i;
                            i++;
                        }
                    }
                }
                else if (cbJenis.Text.ToString() == "Jenis barang")
                {
                    //jika hanya ada inputan pencarian harga saja
                    var i = 0;
                    foreach(Item item in arrItem)
                    {
                        if((item.price >= btsBawah) && (item.price <= btsAtas))
                        {
                            lvItem = new ListViewItem(item.name);
                            lvItem.SubItems.Add(item.price.ToString());
                            lvItem.SubItems.Add(item.jenis);
                            lvItem.SubItems.Add(item.desc);
                            listView1.Items.Add(lvItem);
                            listView1.Items[i].ImageIndex = i;
                            i++;
                        }
                    }
                }
                else
                {
                    //jika ada inputan pencarian jenis dan harga
                    var i = 0;
                    foreach (Item item in arrItem)
                    {
                        if ((item.jenis == cbJenis.Text.ToString()) && ((item.price >= btsBawah) && (item.price <= btsAtas)))
                        {
                            lvItem = new ListViewItem(item.name);
                            lvItem.SubItems.Add(item.price.ToString());
                            lvItem.SubItems.Add(item.jenis);
                            lvItem.SubItems.Add(item.desc);
                            listView1.Items.Add(lvItem);
                            listView1.Items[i].ImageIndex = i;
                            i++;
                        }
                    }
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {       
            groupBoxes[0].Visible = false;
            groupBoxes[1].Visible = true;
            int selected = listView1.SelectedItems[0].ImageIndex;
            listView2.Clear();
                            listView2.Refresh();
                            listView2.View = View.Tile;
                            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                            lvItem = new ListViewItem(arrItem[selected].name);
                            lvItem.SubItems.Add(arrItem[selected].price.ToString());
                            lvItem.SubItems.Add(arrItem[selected].jenis);
                            lvItem.SubItems.Add(arrItem[selected].desc);
                            listView2.Items.Add(lvItem);
                            listView2.Items[0].ImageIndex = 0;
            }

            private void button1_Click(object sender, EventArgs e)
        {
            groupBoxes[0].Visible = true;
            groupBoxes[1].Visible = false;
        }
    }
}
