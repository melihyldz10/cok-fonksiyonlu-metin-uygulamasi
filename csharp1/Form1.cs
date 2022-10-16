using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp1
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)//Formun yükleme kısmında gruop boxlarıve labelları gizledim her işlem seçildigi sürede açılacak şekilde olmuştur.
        {
            //GruıpBoxları formun yükleme kısmında görünürlüklerini false yaptım. combo box işleminde olan degerlere göre açılacaklardır.
            groupBox1.Visible = false;   
            groupbox2.Visible = false;
            groupBox3.Visible = false;

            button2.Enabled = false;//işlemi kaydet butonunu false hale getirdim. işlem yap butonuna tıklamadan bu buton çalışmaz.

            //GruıpBoxları formun yükleme kısmında görünürlüklerini false yaptım. combo box işleminde olan degerlere göre açılacaklardır.
            gunaLabel5.Visible = false;
            gunaLabel6.Visible = false;
            gunaLabel7.Visible = false;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = true;// button bire tıklandıgı durumda button 2 aktif hale gelecektir.

            if (String.IsNullOrWhiteSpace(TextBox1.Text)){MessageBox.Show("Lütfen Birşeyler Giriniz.");}//Textbox1 degerine birşeyler girilmediği sürede hata verecektir.

            else
            {
               
                String yazi = Convert.ToString(TextBox1.Text);
                String yazi2 = Convert.ToString(textBox2.Text);
                String yeni = Convert.ToString(yen.Text);
                String yazi3 = Convert.ToString(textBox4.Text);

                //comboboxa islem degeri atandı. 
                int islem = cb_islem.SelectedIndex;
                txt_sonuc.Text = yazi.ToString();// bir işlem seçmeden sonuc olarak textbox bire yazılan deger sonuc kısmında gözükür.

                switch (islem)
                {

                    case 0://Tüm harfleri büyük yazar
                        txt_sonuc.Text = yazi.ToString()+ "=" + " Yeni İşlem: " + yazi.ToUpper();      
                        break;

                    case 1://Tüm harfleri küçük yazar
                        txt_sonuc.Text = yazi.ToString()+ "=" + " Yeni İşlem: " + yazi.ToLower();             
                        break;

                    case 2://Belirtilen değerin ilk karşılaşılan yerini verir. (IndexOf)
                        if (textBox4.Text == "") { MessageBox.Show("Lütfen Boş Değer Girmeyiniz!!"); }
                        else { txt_sonuc.Text = yazi.ToString() + "=" + " " + yazi3.ToString() + " " + "İlk Karşılaşılan Yer: " + (yazi.IndexOf(yazi3)); }
                        
                        break;

                    case 3://belirtilen değerin son karşılaşılan yerini verir.
                        if (textBox4.Text == "") { MessageBox.Show("Lütfen Boş Değer Girmeyiniz!!"); }
                        else { txt_sonuc.Text = yazi.ToString() + "=" + " " + yazi3.ToString() + " " + " Son Karşılaşılan Yer: " + (yazi.LastIndexOf(yazi3)); }   
                        break;

                       
                    //deger degiştirir yazi ve yazi2 deki degeri degiştirir.   
                    case 4:
                        if (yen.Text == "" || textBox2.Text == "") { MessageBox.Show("Lütfen Boş Değer Girmeyiniz!!"); }
                        else { txt_sonuc.Text = yazi.ToString()+ "=" + " Yeni İşlem: " + yazi.Replace(yeni, yazi2); }          
                        break;



                    case 5://belirtilen index degerinden itibaren ifadeyi siler
                      
                       if (textBox5.Text != "" && textBox3.Text != "")
                        {
                            int ındex = Convert.ToInt32(textBox5.Text);
                            int ındex2 = Convert.ToInt32(textBox3.Text);
                            txt_sonuc.Text = yazi.ToString() + "=" + " Yeni İşlem: " + yazi.Remove(ındex,ındex2); }

                        else if (textBox5.Text != "") { int ındex = Convert.ToInt32(textBox5.Text); txt_sonuc.Text = yazi.ToString() + " =" + " Yeni İşlem: " + (yazi.Remove(ındex)); }
                        else { MessageBox.Show("Lütfen Boş Değer Girmeyiniz!!"); }

                        break;

                       


                    case 6://belirtilen index degerinden başlar ve son belirtilen index degeri arasındaki harfleri ekrana basar.   

                        if (textBox5.Text != "" && textBox3.Text != "")
                        {
                            int ındex = Convert.ToInt32(textBox5.Text);
                            int ındex2 = Convert.ToInt32(textBox3.Text);
                            txt_sonuc.Text = yazi.ToString() + " =" + " Yeni İşlem: " + (yazi.Substring(ındex, ındex2));
                        }
                        else if (textBox5.Text != "") { int ındex = Convert.ToInt32(textBox5.Text); txt_sonuc.Text = yazi.ToString() + " =" + " Yeni İşlem: " + (yazi.Substring(ındex)); }
                        else {MessageBox.Show("Lütfen Boş Değer Girmeyiniz!!  Başlangıç ve adet alanlarına değer giriniz"); }

                            break;


                    default:
                        MessageBox.Show("yanliş işlem seçtiniz");
                        break;
                }
                

            }

        }



        //İşlemi kaydet butonu TXT.SONUCTAN VERİYİ ÇEKİYOR.
        private void button2_Click_1(object sender, EventArgs e)
        {
               listBox1.Items.Add(txt_sonuc.Text);//listbox içine txt.sonucdaki verileri çekiyorum. 
            }



        
        //Bu kısımda combobox isleminde 0 indexi seçen birisi gruopboxları görmez. görülmesi gereken case işlemlerinde ise visible degeri true hal alır.
        private void cb_islem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        
            int islem = cb_islem.SelectedIndex;
            switch (islem)
            {
                case 0:
                    groupBox1.Visible = false;
                    groupbox2.Visible = false;
                    groupBox3.Visible = false;
                    gunaLabel5.Visible = false;
                    gunaLabel6.Visible = false;
                    gunaLabel7.Visible = false;
                    break;
                case 1:
                    groupBox1.Visible = false;
                    groupbox2.Visible = false;
                    groupBox3.Visible = false;
                    gunaLabel5.Visible = false;
                    gunaLabel6.Visible = false;
                    gunaLabel7.Visible = false;
                    break;

                case 2:
                    groupBox1.Visible = false;
                    groupbox2.Visible = false;
                    gunaLabel5.Visible = true;//açıklama görünürlügü true.
                    groupBox3.Visible = true;
                    gunaLabel6.Visible = false;
                    gunaLabel7.Visible = false;
                    break;

                case 3:
                    groupBox1.Visible = false;
                    groupbox2.Visible = false;
                    gunaLabel5.Visible = true;
                    groupBox3.Visible = true;
                    gunaLabel6.Visible = false;
                    gunaLabel7.Visible = false;
                    break;


                case 4:
                    groupBox1.Visible = true;
                    groupbox2.Visible = false;
                    groupBox3.Visible = false;
                    gunaLabel5.Visible = false;
                    gunaLabel6.Visible = true;
                    gunaLabel7.Visible = false;
                    break;

                case 5:
                    groupbox2.Visible = true;
                    groupBox1.Visible = false;
                    groupBox3.Visible = false;
                    gunaLabel5.Visible = false;
                    gunaLabel6.Visible = false;
                    gunaLabel7.Visible = true;
                    break;

                case 6:
                    groupBox1.Visible = false;
                    groupbox2.Visible = true;
                    textBox3.Enabled = true;
                    groupBox3.Visible = false;
                    gunaLabel5.Visible = false;
                    gunaLabel6.Visible = false;
                    gunaLabel7.Visible = true;
                    break;

            }


        }

        private void label1_Click(object sender, EventArgs e)//JFRAMEDEN Çıkar
        {
            Environment.Exit(1);
        }

        private void gunaLabel2_Click(object sender, EventArgs e)//JFRAME aşagıya simge haline alır.
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
