using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IzleyiciListe Musteriler = new IzleyiciListe();  
        private void Form1_Load(object sender, EventArgs e)
        {
            string tmp = "";
            for(int i = 1; i <= 60; i++)
            {
                Node Bos = new Node { koltukNo = 61-i, ad = "", soyad = "", telefon = "" };
                Musteriler.InsertFirst(Bos);
                tmp += " * " + i.ToString();
                if (i % 10 == 0)
                    tmp += Environment.NewLine;
            }
            txtBosKoltuklar.Text = tmp;
            txtListe.Text = "AD     *     SOYAD     *     TELEFON    *    KOLTUK"+Environment.NewLine;
        }
        private void btnYap_Click(object sender, EventArgs e)
        {        
            string ad, soyad, tel;int kltk;
            ad=txtAd.Text;
            soyad=txtSoyad.Text;
            tel=txtTelYap.Text;
            kltk= Convert.ToInt32(txtKoltuk.Text);
            if ("yok" == Musteriler.TelKontrol(tel))
            {
                if (Musteriler.Karsilastir(kltk) == "dolu")
                    MessageBox.Show("Tercih edilen koltuk dolu, lütfen başka bir koltuk seçiniz");
                else
                {
                    Musteriler.InsertPos(ad, soyad, tel, kltk);
                    txtAd.Text = txtSoyad.Text = txtTelYap.Text = txtKoltuk.Text = "";
                    Guncelle();
                }
            }
            else
                MessageBox.Show("Bu numara rezervasyonda kullanılmıştır, lütfen tekrar deneyin");
        }
        private void Guncelle()
        {
            string tmpBoslar = "", tmpDolular = "",tmpHepsi="AD     *     SOYAD     *     TELEFON   *   KOLTUK"+Environment.NewLine;
             Node Eleman = Musteriler.Head;
             for (int i = 1; i <= 60; i++)
             {
                if (Eleman.telefon == "" || Eleman.telefon == null)
                 {
                     tmpBoslar += Eleman.koltukNo.ToString() + " * ";
                     if (i % 10 == 0)
                         tmpBoslar += Environment.NewLine;
                 }
                 else
                {
                    tmpHepsi += Eleman.ad + "   *   " + Eleman.soyad + "   *   " + Eleman.telefon + "   *   " + Eleman.koltukNo+Environment.NewLine;
                    tmpDolular += Eleman.koltukNo.ToString() + " * ";
                     if (i % 10 == 0)
                         tmpDolular += Environment.NewLine;
                 }
                 Eleman = Eleman.next;
             }
             txtBosKoltuklar.Text = tmpBoslar;
             txtDoluKoltuklar.Text = tmpDolular;
             txtListe.Text = tmpHepsi;
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            string tel = txtTelGosterIptal.Text;
            if ("var" == Musteriler.TelKontrol(tel))
            {
                Musteriler.DeletePos(tel);
                Guncelle();
                txtTelGosterIptal.Text = "";
            }
            else
                MessageBox.Show("Böyle bir numara kayıtlarımızda bulunmamaktadır, lütfen tekrar deneyin");
        }
        private void btnGoster_Click(object sender, EventArgs e)
        {            
            string bilgiler = "",tel="";
            tel = txtTelGosterIptal.Text;
            if ("var" == Musteriler.TelKontrol(tel))
            {
                Node Musteri = Musteriler.GetElement(tel);
                bilgiler = "Ad: " + Musteri.ad + "   Soyad: " + Musteri.soyad + "   Telefon: " + Musteri.telefon + "   Koltuk: " + Musteri.koltukNo;
                MessageBox.Show(bilgiler);
                txtTelGosterIptal.Text = "";
            }
            else
                MessageBox.Show("Böyle bir numara kayıtlarımızda bulunmamaktadır, lütfen tekrar deneyin");
        }
    }
}
