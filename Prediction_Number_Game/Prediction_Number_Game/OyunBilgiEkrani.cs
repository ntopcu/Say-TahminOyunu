using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prediction_Number_Game
{
    public partial class bilgiEkran_frm : Form
    {
        public bilgiEkran_frm()
        {
            InitializeComponent();
        }

        private void bilgiEkran_frm_Load(object sender, EventArgs e)
        {
            bilgi_lbl.Text = "1- Oyuna başlamak için Oyuna Başla butonu kullanılır ve bilgisayar kullanıcının tahmin etmesi için kurallara uygun bir sayı üretir.\n\n" +
                             "2- Butona basıldıktan sonra ilk olarak kullanıcıdan, bilgisayarın tahmin etmesi gereken sayıyı kurallara uygun olarak girmesi \nistenir.\n\n" +
                             "3- Kabul et butonu ile sayı onaylanır.\n\n" +
                             "4- Herşey hazır olduğuna göre, oyun ilk olarak kullanıcı ile başlamaktadır.\n\n" +
                             "5- Kullanıcının sırasındayken kendisinden uygun yerlere kurallara uygun tahminde bulunması beklenir ve yine kendisi için görünen \ntahmin et butonu ile tahmini onaylanır.\n\n" +
                             "6- Onaylanan tahmine göre kullanıcıya tahminde bulunduğu alanların altında ipuçları sunulur ve kullanıcı bu ipuçlarından yola \nçıkarak sıra her kendisine geldiğinde manuel olarak anlatılan şekilde tahminde bulunmaya devam eder.\n\n" +
                             "7- Kullanıcıdan sonra sıra bilgisayardadır ve yine bilgisayarın kendisi için görünmekte olan buton yardımı ile bilgisayardan tahminde \nbulunması istenir." +
                             "Bilgisayarda yine kendisi için oluşturduğu rakamlardan yola çıkarak her sıra kendisine geldiğinde tahminlerine devam eder.";


        }
    }
}
