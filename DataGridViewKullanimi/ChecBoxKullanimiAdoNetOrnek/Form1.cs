using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChecBoxKullanimiAdoNetOrnek
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
       

        private List<Urun> UrunleriGetir()
        {
            List<Urun> urunler = new List<Urun>()
            {
                new Urun(){Ad="Ayakkabı", Fiyat=56 , Renk="Red"},
                new Urun(){Ad="Kitap", Fiyat=78 , Renk="Black"},
                new Urun(){Ad="Kalem", Fiyat=26 , Renk="Silver"},
                new Urun(){Ad="Ayakkabı2", Fiyat=79 , Renk="Red"},
                new Urun(){Ad="Kitap2", Fiyat=47 , Renk="White"},
                new Urun(){Ad="Kalem3", Fiyat=56 , Renk="Black"},
                new Urun(){Ad="Telefon", Fiyat=8000 , Renk="Silver"}
            };
            return urunler;

          
        }
        bool kirmiziMi, silverMi, blackMi;

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox3.Checked)
                label1.Text += checkBox3.Text + ";";//seçilen rengi ekler
            else
                label1.Text = label1.Text.Replace(checkBox3.Text + ";", "");//siler

            string[] renkler = label1.Text.Split(';'); //Split ; görünce o ana kadar ki metni alır ve diziye atar.
            kirmiziMi = renkler.Contains("Red");
            silverMi = renkler.Contains("Silver");
            blackMi = renkler.Contains("Black");



            List<Urun> Urunler = UrunleriGetir();

            if (kirmiziMi && silverMi && blackMi)
            {
                Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Black" || kayit.Renk == "Silver").ToList();
            }
            else if (kirmiziMi != true && silverMi != true && blackMi != true)
            {
                Urunler = UrunleriGetir();
            }
            else
            {
                if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Silver").ToList();
                }
                else if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Black").ToList();
                }
                else if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Silver" || kayit.Renk == "Black").ToList();
                }
                else if (kirmiziMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red").ToList();
                else if (silverMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Silver").ToList();
                else if (blackMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Black").ToList();
            }
            dataGridView1.DataSource = Urunler;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            checkBox1.Text = "Red";
            checkBox2.Text = "Silver";
            checkBox3.Text = "Black";
            label1.Text = string.Empty;
            UrunleriGetir();
           // dataGridView1.DataSource = UrunleriGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Urun> urunler = UrunleriGetir();
            double altFiyat=Convert.ToDouble(textBox1.Text);
            double ustFiyat=Convert.ToDouble(textBox2.Text);
            urunler=urunler.Where(kayit => kayit.Fiyat >= altFiyat && kayit.Fiyat <= ustFiyat).ToList();
            dataGridView1.DataSource = urunler;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //silver seçili mi?
            if (checkBox2.Checked)
                label1.Text += checkBox2.Text + ";";//seçilen rengi ekler
            else
                label1.Text = label1.Text.Replace(checkBox2.Text + ";", "");//siler

            string[] renkler = label1.Text.Split(';'); //Split ; görünce o ana kadar ki metni alır ve diziye atar.
            kirmiziMi = renkler.Contains("Red");
            silverMi = renkler.Contains("Silver");
            blackMi = renkler.Contains("Black");


            List<Urun> Urunler = UrunleriGetir();

            if (kirmiziMi && silverMi && blackMi)
            {
                Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Black" || kayit.Renk == "Silver").ToList();
            }
            else if (kirmiziMi != true && silverMi != true && blackMi != true)
            {
                Urunler = UrunleriGetir();
            }
            else
            {
                if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Silver").ToList();
                }
                else if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Black").ToList();
                }
                else if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Silver" || kayit.Renk == "Black").ToList();
                }
                else if (kirmiziMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red").ToList();
                else if (silverMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Silver").ToList();
                else if (blackMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Black").ToList();
            }
            dataGridView1.DataSource = Urunler;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //silver seçili mi?
            if (checkBox1.Checked)
                label1.Text += checkBox1.Text + ";";//seçilen rengi ekler
            else
                label1.Text = label1.Text.Replace(checkBox1.Text + ";", "");//siler

            string[] renkler = label1.Text.Split(';'); //Split ; görünce o ana kadar ki metni alır ve diziye atar.
            kirmiziMi = renkler.Contains("Red");
            silverMi = renkler.Contains("Silver");
            blackMi = renkler.Contains("Black");



            List<Urun> Urunler = UrunleriGetir();

            if (kirmiziMi && silverMi && blackMi)
            {
                Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Black" || kayit.Renk == "Silver").ToList();
            }
            else if (kirmiziMi!=true && silverMi!=true && blackMi!=true)
            {
                Urunler = UrunleriGetir();
            }
            else
            {
                if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Silver").ToList();
                }
                else if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red" || kayit.Renk == "Black").ToList();
                }
                else if (kirmiziMi && silverMi)
                {
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Silver" || kayit.Renk == "Black").ToList();
                }
                else if (kirmiziMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Red").ToList();
                else if (silverMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Silver").ToList();
                else if (blackMi)
                    Urunler = Urunler.Where(kayit => kayit.Renk == "Black").ToList();
            }
            dataGridView1.DataSource= Urunler;

        }
    }
}
