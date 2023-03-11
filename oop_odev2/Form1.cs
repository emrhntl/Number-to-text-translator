/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2021-2022 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........:ÖDEV-2
** ÖĞRENCİ ADI............:EMİRHAN ETLİ
** DERSİN ALINDIĞI GRUP...:NESNEYE DAYALI PROGRAMLAMA(B)
****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace oop_odev2
{
    public partial class Form1 : Form
    {
        private TextBox txtGirilenSayi;//global tanımlanması gereken kontroller tanımlanır
        private Label lblYazi;
        private Label lblSonuc;
        private Label lblSonuc2;
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Fonksiyon Hesabı";
            this.BackColor = Color.Gray;
            this.Size = new System.Drawing.Size(545, 375);
            Label lblSayi = new Label();
            lblSayi.Text = "Tutarı giriniz:";
            lblSayi.Location = new Point(135, 90);
            lblSayi.Size = new Size(95,27);
            lblSayi.BackColor = SystemColors.ActiveCaption;
            this.Controls.Add(lblSayi);//tanımlanan kontrol forma ekleniyor
            this.txtGirilenSayi = new System.Windows.Forms.TextBox();
            txtGirilenSayi.Location = new Point(235, 90);
            txtGirilenSayi.MaxLength = 8;
            this.Controls.Add(txtGirilenSayi);
            this.lblYazi = new System.Windows.Forms.Label();
            lblYazi.Text = "Yazıya dökülmüş hali:"; 
            lblYazi.Location = new Point(25, 145);
            lblYazi.AutoSize = true;
            lblYazi.BackColor = SystemColors.ActiveCaption;
            this.Controls.Add(lblYazi);
            this.lblSonuc = new System.Windows.Forms.Label();
            lblSonuc.Size = new System.Drawing.Size(40, 50);
            lblSonuc.Location = new Point(205, 145);
            lblSonuc.AutoSize=true;
            lblSonuc.BackColor = SystemColors.ActiveCaption;
            this.Controls.Add(lblSonuc);
            this.lblSonuc2 = new System.Windows.Forms.Label();
            lblSonuc2.Location = new Point(205, 168);
            lblSonuc2.AutoSize = true;
            lblSonuc2.BackColor = SystemColors.ActiveCaption;
            this.Controls.Add(lblSonuc2);
            Button btnBul = new Button();
            btnBul.AutoSize = true;
            btnBul.Location = new Point(210, 195);
            btnBul.Text = "YAZDIR(ENTER)";
            btnBul.BackColor = SystemColors.ActiveCaption;
            this.Controls.Add(btnBul);
            btnBul.Click += btnBul_Click;//buton un click olayına metod ekledim
            this.AcceptButton = btnBul; //enter a bastığında btnbul un çalışması
            txtGirilenSayi.Focus();//form yüklenince textbox a odaklanmasını sağlıyor
        }
        private void btnBul_Click(object sender, EventArgs e) 
        {
            string[] onlar = { "", " on", " yirmi", " otuz", " kırk", " elli", " altmış", " yetmiş", " seksen", " doksan" };//onlar basamağı için kullanılacak string ifadeler
            string[] birler = { "", " bir", " iki", " üç", " dört", " beş", " altı", " yedi", " sekiz", " dokuz" };//birler basamağı için kullanılacak string ifadeler 
            string[] yuzler = { "", "", " iki", " üç", " dört", " beş", " altı", " yedi", " sekiz", " dokuz" };//yüzler basamağı için kullanılacak string ifadeler
            bool virgulKontrol = false;
            lblSonuc2.Visible = false;//sadece virgüllü ifade olduğunda kuruş kısmını göstermek için sonuç2 labelinin görünürlüğünü false yaptım
            lblSonuc.Visible = true;
            int basamak =txtGirilenSayi.Text.Length-txtGirilenSayi.Text.IndexOf(",")-1;//virgülden sonra kaç basamak olduğunu kontrol ettim
            for (int i = 0; i < txtGirilenSayi.Text.Length; i++)//virgüllü ifade ya da noktalı ifade olup olmadığını kontrol ettim
            {
                if (txtGirilenSayi.Text.Substring(i, 1) == "," || txtGirilenSayi.Text.Substring(i, 1) == ".")
                {
                    virgulKontrol = true;
                }
            }
            if (txtGirilenSayi.Text != "0")
            {
                try //textbox ın içine sayı harici harf,noktalama vb. ifade girildiğinde kullanıcıyı uyarması için try catch kullandım
                {
                    double sayi = Convert.ToDouble(txtGirilenSayi.Text);
                    int onbinlerBasamagi = (int)sayi / 10000, binlerBasamagi = (int)(sayi % 10000) / 1000, yuzlerBasamagi = (int)(sayi % 1000) / 100, onlarBasamagi = (int)(sayi % 100) / 10, birlerBasamagi = (int)sayi % 10;
                    if (sayi >= 10000)
                    {
                        if (yuzlerBasamagi > 0)//sonuca her türlü yazılacak yüz kelimesini sadece yüzler basamağı 0 dan büyükken yazması için kontrol yapısı kurdum
                        {
                            lblSonuc.Text = onlar[onbinlerBasamagi] + birler[binlerBasamagi] + " bin" + yuzler[yuzlerBasamagi] + " yüz" + onlar[onlarBasamagi] + birler[birlerBasamagi] + " lira";
                        }
                        else
                        {
                            lblSonuc.Text = onlar[onbinlerBasamagi] + birler[binlerBasamagi] + " bin" + onlar[onlarBasamagi] + birler[birlerBasamagi] + " lira";
                        }
                    }
                    else if (binlerBasamagi > 0)
                    {
                        if (yuzlerBasamagi > 0) 
                        {
                        lblSonuc.Text = yuzler[binlerBasamagi] + " bin" + yuzler[yuzlerBasamagi] + " yüz" + onlar[onlarBasamagi] + birler[birlerBasamagi] + " lira";
                        }
                        else 
                        {
                        lblSonuc.Text = yuzler[binlerBasamagi] + " bin" + onlar[onlarBasamagi] + birler[birlerBasamagi] + " lira";
                        }
                    }
                    else if (yuzlerBasamagi > 0)
                    {
                        lblSonuc.Text = yuzler[yuzlerBasamagi] + " yüz" + onlar[onlarBasamagi] + birler[birlerBasamagi] + " lira";
                    }
                    else
                    {
                        lblSonuc.Text = onlar[onlarBasamagi] + birler[birlerBasamagi] + " lira";
                    }
                    if (lblSonuc.Text == " lira") 
                        lblSonuc.Visible=false;//eğer virgülden önceki basamaklar sıfırsa 0 lira yazmaması için visible ı false yapıyoruz
                    if (virgulKontrol)
                    {
                        if (basamak <= 2 && basamak > 0) //virgül olduğu durumda kullanıcı virgülden sonra sayı girmiş mi diye kontrol ediliyor
                        {
                            int ondaBirler = (int)((sayi * 100) % 100) / 10, yuzdeBirler = (int)(sayi * 100) % 10;
                            if (!(ondaBirler == 0 && yuzdeBirler == 0)) //eğer virgülden sonra girilen iki basamak da 0 a eşitse kuruş yazmaması için 
                            {
                                lblSonuc2.Visible = true;
                                lblSonuc2.Text = onlar[ondaBirler] + birler[yuzdeBirler] + " kuruş";
                            }
                        }
                        else
                        {
                            lblSonuc.Text = "";
                            MessageBox.Show("LÜTFEN VİRGÜLDEN SONRA 1 YA DA 2 BASAMAK GİRİNİZ", "HATA!");
                            txtGirilenSayi.Text = "";
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("LÜTFEN 0-99999,99 ARASINDA GEÇERLİ BİR SAYI GİRİNİZ", "HATA!");
                    txtGirilenSayi.Text = "";
                    lblSonuc.Text = "";
                }
            }
            else
            {
                lblSonuc.Text = "sıfır lira";
            }
        }
    }
}
