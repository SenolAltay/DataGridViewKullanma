using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewKullanimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Urun> urunler = new List<Urun>();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-864OGI4\SQLEXPRESS;Database=AdventureWorks2019;Integrated Security=true");
        public List<Kisi>kisilerGetir(int adet)
        {
            List<Kisi>kisiler=new List<Kisi>();

            for (int i = 0; i < adet; i++)
            {
                Kisi kisi = new Kisi();
                kisi.Ad = "Ali";
                kisi.Soyad = "yok";
                kisi.DogumTarihi = new DateTime(2000, 01, 01);
                kisiler.Add(kisi);
            }
            return kisiler;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int kisiAdedi = rnd.Next(1, 11);
            List<Kisi>kisiler=kisilerGetir(kisiAdedi);

            dataGridView1.DataSource = kisiler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Production.Product", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();
           
            while (dr.Read())
            {
                Urun urun = new Urun();
                urun.Adı = dr["Name"].ToString();
                urun.Stok = Convert.ToInt32(dr["SafetyStockLevel"]);
                urun.Renk = dr["Color"].ToString();
                urunler.Add(urun);
                if (checkBox1.Checked==true)
                {
                    urunler.Where(satir => satir.Renk == "kirmizi").ToString();
                    dataGridView1.DataSource = urunler;
                }
                else
                {
                    dataGridView1.DataSource = urunler;
                }
            }
            urunler = urunler.OrderBy(p => p.Stok).ToList();
           

            dataGridView1.DataSource = urunler;

            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand("select SafetyStockLevel from Production.Product desc Stock", baglanti);
            //baglanti.Open();
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    Urun urun = new Urun();
            //    urun.Adı = dr["Name"].ToString();

            //    urun.Stok = Convert.ToInt32(dr["SafetyStockLevel"]);
            //    urunler.Add(urun);
            //}
            urunler = urunler.OrderByDescending(p => p.Stok).ToList();
            dataGridView1.DataSource = urunler;
            baglanti.Close();
        }
    }
}
