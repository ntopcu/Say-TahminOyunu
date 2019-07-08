//Nuri Topcuoğlu tarafından oluşturuldu.

using System;
using System.Windows.Forms;

namespace Prediction_Number_Game
{
    public partial class oyun_ekrani_frm : Form
    {
        Random random = new Random();
        public int[] yeni_sayi = new int[4];                    //kullanıcının tahmin etmesi için bilgisayarın oluşturduğu sayı           
        public int[] kullaniciSayi = new int[4];                //bilgisayarın tahmin etmesi için kullanıcının oluşturduğu sayı
        static public int[] bilgisayarTahmin = new int[4];      //bilgisayarın tahmin olarak oluşturduğu sayı
        public int[] kullaniciTahmin = new int[4];              //kullanıcının tahmin olarak oluşturduğu sayı
        public static int kullaniciTahminSayac = 0;
        public static int bilgisayarTahminSayac = 0;
        string[] bilgisayarIpUcu = new string[4]; 

        public oyun_ekrani_frm()
        {
            InitializeComponent();
        }

        public int[] SayiUretme()                                   //sayı üretme metodu
        {
            int[] sayi = { random.Next(1, 9), random.Next(0, 9), random.Next(0, 9), random.Next(0, 9) };
            int[] duzelen_sayi = new int[4];

            duzelen_sayi = SayiDuzeltme(sayi, random);
            return duzelen_sayi;
        }

        public int[] SayiDuzeltme(int[] sayi, Random random)        //üretilen sayının istenilen şekle dönüştürülmesi metodu
        {
            for (int i = 0; i < sayi.Length; i++)                   
            {
                bool degisme_durumu = false;
                for (int j = 0; j < sayi.Length; j++)           
                {
                    if (i != j)
                    {
                        if (sayi[i] == sayi[j])
                        {
                            degisme_durumu = true;

                            while (degisme_durumu == true)
                            {
                                if (j != 0)
                                {
                                    sayi[j] = random.Next(0, 9);
                                    for (int t = 0; t < sayi.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (sayi[j] != sayi[t])
                                            {
                                                degisme_durumu = false;
                                            }
                                            else
                                            {
                                                degisme_durumu = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    sayi[j] = random.Next(1, 9);
                                    for (int t = 0; t < sayi.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (sayi[j] != sayi[t])
                                            {
                                                degisme_durumu = false;
                                            }
                                            else
                                            {
                                                degisme_durumu = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return sayi;
        }

        private void basla_btn_Click(object sender, EventArgs e)    //Oyunu başlatma butonunun click eventi
        {
            yeni_sayi = SayiUretme();                               //kullanıcının tahmin etmesi bilgisayar sayı oluşturuyor
            basla_btn.Visible = false;                              //bu buton kayboluyor
            kullanici_bas0_txt.ReadOnly = false;                    //kullanıcı bilgisayarın tahmin edeceği kendi rakamını oluşturabilsin diye kutucuklar açılıyor
            kullanici_bas1_txt.ReadOnly = false;                    //kullanıcı bilgisayarın tahmin edeceği kendi rakamını oluşturabilsin diye kutucuklar açılıyor
            kullanici_bas2_txt.ReadOnly = false;                    //kullanıcı bilgisayarın tahmin edeceği kendi rakamını oluşturabilsin diye kutucuklar açılıyor
            kullanici_bas3_txt.ReadOnly = false;                    //kullanıcı bilgisayarın tahmin edeceği kendi rakamını oluşturabilsin diye kutucuklar açılıyor
            sayiOlustur_btn.Visible = true;                         //kullanıcı bilgisayarın tahmin edeceği kendi rakamını oluşturabilsin diye buton görünüyor
            uyari_lbl.Text = "Bilgisayarın tahmin etmesi için yukarıdaki kutucuklara kullanıcının uygun girdileri vermesi bekleniyor.";
            //if (kullanici_bas0_txt.Text != "" && kullanici_bas1_txt.Text != "" && kullanici_bas2_txt.Text != "" && kullanici_bas3_txt.Text != "")
            //{
            //    uyari_lbl.Text = "";
            //}
            deneme_lbl.Text = yeni_sayi[0].ToString() + yeni_sayi[1].ToString() + yeni_sayi[2].ToString() + yeni_sayi[3].ToString();
        }

        private void sayiOlustur_btn_Click(object sender, EventArgs e)                  //kullanıcı bilgisayarın tahmin edeceği kendi rakamını oluşturuyor
        {
            if (Convert.ToInt32(kullanici_bas0_txt.Text) != Convert.ToInt32(kullanici_bas1_txt.Text) &&
               Convert.ToInt32(kullanici_bas0_txt.Text) != Convert.ToInt32(kullanici_bas2_txt.Text) &&
               Convert.ToInt32(kullanici_bas0_txt.Text) != Convert.ToInt32(kullanici_bas3_txt.Text) &&
               Convert.ToInt32(kullanici_bas1_txt.Text) != Convert.ToInt32(kullanici_bas2_txt.Text) &&
               Convert.ToInt32(kullanici_bas1_txt.Text) != Convert.ToInt32(kullanici_bas3_txt.Text) &&
               Convert.ToInt32(kullanici_bas2_txt.Text) != Convert.ToInt32(kullanici_bas3_txt.Text))
               
            {
                kullaniciSayi[0] = Convert.ToInt32(kullanici_bas0_txt.Text);
                kullaniciSayi[1] = Convert.ToInt32(kullanici_bas1_txt.Text);
                kullaniciSayi[2] = Convert.ToInt32(kullanici_bas2_txt.Text);
                kullaniciSayi[3] = Convert.ToInt32(kullanici_bas3_txt.Text);

                kullanici_bas0_txt.ReadOnly = true;             //kullanıcı geçerli şekilde sayılarını girdikten sonra textler tekrar kapanıyor
                kullanici_bas1_txt.ReadOnly = true;             //kullanıcı geçerli şekilde sayılarını girdikten sonra textler tekrar kapanıyor
                kullanici_bas2_txt.ReadOnly = true;             //kullanıcı geçerli şekilde sayılarını girdikten sonra textler tekrar kapanıyor
                kullanici_bas3_txt.ReadOnly = true;             //kullanıcı geçerli şekilde sayılarını girdikten sonra textler tekrar kapanıyor
                sayiOlustur_btn.Visible = false;                //sayı oluştuğu için artık oyunun da başlaması için bu buton kayboluyor
                uyari_lbl.Text = "Oyun başladı. İlk tahmin sırası kullanıcıda.";

                kullaniciTahmin_bas0_txt.ReadOnly = false;      //Oyunun başlaması için kullanıcnın tahminde bulunacağı kutucuklar açılıyor
                kullaniciTahmin_bas1_txt.ReadOnly = false;      //Oyunun başlaması için kullanıcnın tahminde bulunacağı kutucuklar açılıyor
                kullaniciTahmin_bas2_txt.ReadOnly = false;      //Oyunun başlaması için kullanıcnın tahminde bulunacağı kutucuklar açılıyor
                kullaniciTahmin_bas3_txt.ReadOnly = false;      //Oyunun başlaması için kullanıcnın tahminde bulunacağı kutucuklar açılıyor
                kullanici_sira_lbl.Visible = true;
                kullaniciTahmin_btn.Visible = true;             //Sıra kullanıcıyla başlayacağı için ilk bu buton açılıyor

            }
            else if (kullanici_bas0_txt.Text == "" || kullanici_bas1_txt.Text == "" || kullanici_bas2_txt.Text == "" || kullanici_bas3_txt.Text == "")
            {
                MessageBox.Show("Lütfen boş haneleri kurallara uygun olarak doldurun.");
            }
            else
            {
                MessageBox.Show("Lütfen rakamları farklı bir 4 haneli sayı oluşturun.");
            }

        }

        private void kullaniciTahmin_btn_Click(object sender, EventArgs e)                  //kullanıcının tahmin üreteceği butonun click eventi
        {
            string[] kullaniciSonuc = new string[4];
            if (Convert.ToInt32(kullaniciTahmin_bas0_txt.Text) != Convert.ToInt32(kullaniciTahmin_bas1_txt.Text) &&
               Convert.ToInt32(kullaniciTahmin_bas0_txt.Text) != Convert.ToInt32(kullaniciTahmin_bas2_txt.Text) &&
               Convert.ToInt32(kullaniciTahmin_bas0_txt.Text) != Convert.ToInt32(kullaniciTahmin_bas3_txt.Text) &&
               Convert.ToInt32(kullaniciTahmin_bas1_txt.Text) != Convert.ToInt32(kullaniciTahmin_bas2_txt.Text) &&
               Convert.ToInt32(kullaniciTahmin_bas1_txt.Text) != Convert.ToInt32(kullaniciTahmin_bas3_txt.Text) &&
               Convert.ToInt32(kullaniciTahmin_bas2_txt.Text) != Convert.ToInt32(kullaniciTahmin_bas3_txt.Text))
            {
                kullaniciTahmin[0] = Convert.ToInt32(kullaniciTahmin_bas0_txt.Text);
                kullaniciTahmin[1] = Convert.ToInt32(kullaniciTahmin_bas1_txt.Text);
                kullaniciTahmin[2] = Convert.ToInt32(kullaniciTahmin_bas2_txt.Text);
                kullaniciTahmin[3] = Convert.ToInt32(kullaniciTahmin_bas3_txt.Text);

                for (int i = 0; i < kullaniciTahmin.Length; i++)                        //yapılan tahmine göre kutucukların altında ipuçları oluşuyor
                {
                    string lblName = "kullaniciTahmin_bas" + i.ToString() + "_lbl";
                    if (kullaniciTahmin[i] == yeni_sayi[i])
                    {
                        foreach (Control item in this.Controls)
                        {
                            if (item is Label && item.Name == lblName)
                            {
                                item.Text = "+";
                                kullaniciSonuc[i] = "+";
                            }
                        }
                    }
                    else
                    {
                        bool esitlikDurumu = false;
                        for (int j = 0; j < kullaniciTahmin.Length; j++)
                        {
                            if (i != j)
                            {
                                if (kullaniciTahmin[i] == yeni_sayi[j])
                                {
                                    esitlikDurumu = true;
                                    foreach (Control item in this.Controls)
                                    {
                                        if (item is Label && item.Name == lblName)
                                        {
                                            item.Text = "-";
                                            kullaniciSonuc[i] = "-";
                                        }
                                    }
                                }
                            }
                        }
                        if (esitlikDurumu == false)
                        {
                            foreach (Control item in this.Controls)
                            {
                                if (item is Label && item.Name == lblName)
                                {
                                    item.Text = "";
                                    kullaniciSonuc[i] = "";
                                }
                            }
                        }
                    }
                }

                kullaniciTahmin_bas0_txt.Text = "";
                kullaniciTahmin_bas1_txt.Text = "";
                kullaniciTahmin_bas2_txt.Text = "";
                kullaniciTahmin_bas3_txt.Text = "";
                kullanici_sira_lbl.Visible = false;                     
                kullaniciTahmin_btn.Visible = false;                    //bu buton kayboluyor
                kullaniciTahmin_bas0_txt.ReadOnly = true;               //sıra bilgisayara geçtiği için kutucuklara tekrar değer girilmesi engelleniyor
                kullaniciTahmin_bas1_txt.ReadOnly = true;               //sıra bilgisayara geçtiği için kutucuklara tekrar değer girilmesi engelleniyor 
                kullaniciTahmin_bas2_txt.ReadOnly = true;               //sıra bilgisayara geçtiği için kutucuklara tekrar değer girilmesi engelleniyor
                kullaniciTahmin_bas3_txt.ReadOnly = true;               //sıra bilgisayara geçtiği için kutucuklara tekrar değer girilmesi engelleniyor
                bilgisayar_sira_lbl.Visible = true;                     
                bilgisayarTahmin_btn.Visible = true;                    //sıra bilgisayara geçtiği için tahmin butonu görünüyor
                uyari_lbl.Text = "Kullanıcı tahminde bulundu.";
                kullaniciTahminSayac++;
                kullaniciTahminDurum_lbl.Text = "kullanıcı " + kullaniciTahminSayac.ToString() + ". tahmininde bulundu.";
                if (kullaniciSonuc[0] == "+" && kullaniciSonuc[1] == "+" && kullaniciSonuc[2] == "+" && kullaniciSonuc[3] == "+")
                {
                    MessageBox.Show("Oyun bitti. Kazanan: kullanıcı " + kullaniciTahminSayac.ToString() + " hamlede oyunu kazanmıştır.");
                }

            }
            else if (kullaniciTahmin_bas0_txt.Text == "" || kullaniciTahmin_bas1_txt.Text == "" || kullaniciTahmin_bas2_txt.Text == "" || kullaniciTahmin_bas3_txt.Text == "")
            {
                MessageBox.Show("Lütfen boş haneleri kurallara uygun olarak doldurun.");
            }
            else
            {
                MessageBox.Show("Lütfen rakamları farklı bir 4 haneli sayı tahmininde bulunun.");
            }
        }

        private void bilgisayarTahmin_btn_Click(object sender, EventArgs e)             //bilgisayarın tahmin üreteceği butonun click eventi
        {
            string[] bilgisayarSonuc = new string[4];

            if (bilgisayarTahminSayac == 0)
            {
                bilgisayarTahmin = SayiUretme();
            }
            
            for (int i = 0; i < bilgisayarTahmin.Length; i++)
            {
                for (int j = 0; j < bilgisayarTahmin.Length; j++)
                {
                    if (i != j)                                                 //farklı basamakları kontrol etmek için
                    {
                        bool esitlik = false;
                        if (kullaniciSayi[i] == bilgisayarTahmin[j])
                        {
                            esitlik = true;
                            bilgisayarTahmin[i] = bilgisayarTahmin[j];              
                            while (esitlik == true)
                            {
                                if (j == 0)
                                {
                                    bilgisayarTahmin[j] = random.Next(1, 9);
                                    for (int t = 0; t < bilgisayarTahmin.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (bilgisayarTahmin[j] == bilgisayarTahmin[t])
                                            {
                                                esitlik = true;
                                                break;
                                            }
                                            else
                                            {
                                                esitlik = false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bilgisayarTahmin[j] = random.Next(0, 9);
                                    for (int t = 0; t < bilgisayarTahmin.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (bilgisayarTahmin[j] == bilgisayarTahmin[t])
                                            {
                                                esitlik = true;
                                                break;
                                            }
                                            else
                                            {
                                                esitlik = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else                                 //farklı basamaklarda sayıların tutmama durumu
                        {
                            while (esitlik == false)
                            {
                                if (j == 0)
                                {
                                    bilgisayarTahmin[j] = random.Next(1, 9);
                                    for (int t = 0; t < bilgisayarTahmin.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (bilgisayarTahmin[j] == bilgisayarTahmin[t])
                                            {
                                                esitlik = false;
                                                break;
                                            }
                                            else
                                            {
                                                esitlik = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bilgisayarTahmin[j] = random.Next(0, 9);
                                    for (int t = 0; t < bilgisayarTahmin.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (bilgisayarTahmin[j] == bilgisayarTahmin[t])
                                            {
                                                esitlik = false;
                                                break;
                                            }
                                            else
                                            {
                                                esitlik = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else                                    // i == j yani aynı basamakları karşılaştırma
                    {
                        if (kullaniciSayi[i] != bilgisayarTahmin[j])
                        {
                            bool esitlik = false;
                            while (esitlik == false)
                            {
                                if (j == 0)
                                {
                                    bilgisayarTahmin[j] = random.Next(1, 9);
                                    for (int t = 0; t < bilgisayarTahmin.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (bilgisayarTahmin[j] == bilgisayarTahmin[t])
                                            {
                                                esitlik = false;
                                                break;
                                            }
                                            else
                                            {
                                                esitlik = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bilgisayarTahmin[j] = random.Next(0, 9);
                                    for (int t = 0; t < bilgisayarTahmin.Length; t++)
                                    {
                                        if (j != t)
                                        {
                                            if (bilgisayarTahmin[j] == bilgisayarTahmin[t])
                                            {
                                                esitlik = false;
                                                break;
                                            }
                                            else
                                            {
                                                esitlik = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bilgisayarSonuc[i] = "+";
                        }
                    }
                }
            }

            kullanici_sira_lbl.Visible = true;
            kullaniciTahmin_btn.Visible = true;                     //sıra kullanıcıya geçtiği için tahmin butonu görünüyor.
            kullaniciTahmin_bas0_txt.ReadOnly = false;              //sıra kullanıcıya geçtiği için kutucuklara tekrar değer girilmesine izin veriliyor.
            kullaniciTahmin_bas1_txt.ReadOnly = false;              //sıra kullanıcıya geçtiği için kutucuklara tekrar değer girilmesine izin veriliyor.
            kullaniciTahmin_bas2_txt.ReadOnly = false;              //sıra kullanıcıya geçtiği için kutucuklara tekrar değer girilmesine izin veriliyor.
            kullaniciTahmin_bas3_txt.ReadOnly = false;              //sıra kullanıcıya geçtiği için kutucuklara tekrar değer girilmesine izin veriliyor.
            bilgisayar_sira_lbl.Visible = false;
            bilgisayarTahmin_btn.Visible = false;                   //sıra kullanıcıya geçtiği için kendisi kayboluyor.
            uyari_lbl.Text = "Bilgisayar tahminde bulundu.";
            bilgisayarTahminSayac++;
            bilgisayarTahminDurum_lbl.Text = "bilgisayar " + bilgisayarTahminSayac.ToString() + ". tahmininde bulundu.";
            if (bilgisayarSonuc[0] == "+" && bilgisayarSonuc[1] == "+" && bilgisayarSonuc[2] == "+" && bilgisayarSonuc[3] == "+")
            {
                MessageBox.Show("Oyun bitti. Kazanan: bilgisayar " + bilgisayarTahminSayac.ToString() + " hamlede oyunu kazanmıştır.");
            }
        }

        private void bilgiAlma_btn_Click(object sender, EventArgs e)
        {
            bilgiEkran_frm frm = new bilgiEkran_frm();
            frm.Show();    
        }           //Oyun hakkında bilgi alma ekranına yönlendiriyor.

        //Textbox alanlarına sadece rakam girilmesini sağlayan kontroller.
        private void kullanici_bas0_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar > 48 && (int)e.KeyChar <= 57 && kullanici_bas0_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;

            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullanici_bas1_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 && kullanici_bas1_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullanici_bas2_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 && kullanici_bas2_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullanici_bas3_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 && kullanici_bas3_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullaniciTahmin_bas0_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar > 48 && (int)e.KeyChar <= 57 && kullaniciTahmin_bas0_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullaniciTahmin_bas1_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 && kullaniciTahmin_bas1_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullaniciTahmin_bas2_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 && kullaniciTahmin_bas2_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }

        private void kullaniciTahmin_bas3_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 && kullaniciTahmin_bas3_txt.Text.Length != 1)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
            if (e.Handled == true)
            {
                MessageBox.Show("Hatalı girdi.");
            }
        }
    }
}