using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace olacak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-AIVP1E4\\SQLEXPRESS;Initial Catalog=kardesler;Integrated Security=True");
        

        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From fener",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ID"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Adres"].ToString());
                ekle.SubItems.Add(oku["Notlar"].ToString());
                ekle.SubItems.Add(oku["Menu"].ToString());
                ekle.SubItems.Add(oku["PizzaBoyu"].ToString());
                ekle.SubItems.Add(oku["Icecekler"].ToString());
                ekle.SubItems.Add(oku["Tatlilar"].ToString());
                ekle.SubItems.Add(oku["Ekstra"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            verilerigöster();
        }
        double fiyat1 = 0;
        double fiyat2 = 0;
        double fiyat_3 = 0;
        double fiyat_4 = 0;
        double fiyat_5 = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Karışık Pizza ")
                    fiyat1 = 15;
                else if (Convert.ToString(comboBox1.SelectedItem) == "Kaşarlı Pizza ")
                    fiyat1 = 20;
                else if (Convert.ToString(comboBox1.SelectedItem) == "Sucuklu Pizza ")
                    fiyat1 = 25;
                else if (Convert.ToString(comboBox1.SelectedItem) == "Gennaro Pizza ")
                    fiyat1 = 30;
                else
                    fiyat1 = 0;

            }

            {
                if (Convert.ToString(comboBox2.SelectedItem) == "Küçük Boy ")
                    fiyat2 = 5;

                else if (Convert.ToString(comboBox2.SelectedItem) == "Orta Boy ")
                {
                    fiyat2 = 10;
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Büyük Boy ")
                {
                    fiyat2 = 15;
                }
                else
                    fiyat2 = 0;

            }
            {
                if (Convert.ToString(comboBox3.SelectedItem) == "Su ")
                    fiyat_3 = 1;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Cola")
                    fiyat_3 = 4;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Fanta ")
                    fiyat_3 = 4;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Ayran ")
                    fiyat_3 = 2;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Soda ")
                    fiyat_3 = 2;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Meyveli Soda ")
                    fiyat_3 = 3;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Şalgam")
                    fiyat_3 = 4;
                else
                    fiyat_3 = 0;

            }
            {
                if (Convert.ToString(comboBox4.SelectedItem) == "Kazandibi ")
                    fiyat_4 = 5;
                else if (Convert.ToString(comboBox4.SelectedItem) == "Künefe ")
                {
                    fiyat_4 = 7;
                }
                else if (Convert.ToString(comboBox4.SelectedItem) == "Baklava ")
                    fiyat_4 = 8;
                else if (Convert.ToString(comboBox4.SelectedItem) == "Puding ")
                    fiyat_4 = 4;
                else if (Convert.ToString(comboBox4.SelectedItem) == "Sütlaç ")
                    fiyat_4 = 6;
                else
                    fiyat_4 = 0;
            }

            {

                if (Convert.ToString(comboBox5.SelectedItem) == "Soğan Halkaları ")
                    fiyat_5 = 6;
                else if (Convert.ToString(comboBox5.SelectedItem) == "Patates Kızartması ")
                    fiyat_5 = 5;
                else if (Convert.ToString(comboBox5.SelectedItem) == "Dondurma ")
                    fiyat_5 += 3;
                else
                    fiyat_5 = 0;
            }

            double sonuc = fiyat1 + fiyat2 + fiyat_3 + fiyat_4 + fiyat_5;
            textBox6.Text = sonuc.ToString() + " TL";
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into fener(ID,AdSoyad,Telefon,Adres,Notlar,Menu,PizzaBoyu,Icecekler,Tatlilar,Ekstra,Fiyat)values('"+textBox1.Text.ToString()+ "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','"+ comboBox1.Text.ToString()+ "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
            {
                TexBoxTemizleForm(this.groupBox1.Controls);
            }
            void TexBoxTemizleForm(System.Windows.Forms.Control.ControlCollection textbox)
            {
                foreach (System.Windows.Forms.Control item in textbox)
                {
                    if (item is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)item;
                        txt.Text = string.Empty;
                    }
                }
            }

        }
        int ID = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete FROM fener WHERE ID=@ID" , baglan);
            komut.Parameters.AddWithValue("@ID", textBox1.Text);
            
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[7].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[9].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[10].Text;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                if (Convert.ToString(comboBox1.SelectedItem) == "Karışık Pizza ")
                    fiyat1 = 15;
                else if (Convert.ToString(comboBox1.SelectedItem) == "Kaşarlı Pizza ")
                    fiyat1 = 20;
                else if (Convert.ToString(comboBox1.SelectedItem) == "Sucuklu Pizza ")
                    fiyat1 = 25;
                else if (Convert.ToString(comboBox1.SelectedItem) == "Gennaro Pizza ")
                    fiyat1 = 30;

            }

            {
                if (Convert.ToString(comboBox2.SelectedItem) == "Küçük Boy ")
                    fiyat2 = 5;

                else if (Convert.ToString(comboBox2.SelectedItem) == "Orta Boy ")
                {
                    fiyat2 = 10;
                }
                else if (Convert.ToString(comboBox2.SelectedItem) == "Büyük Boy ")
                {
                    fiyat2 = 15;
                }

            }
            {
                if (Convert.ToString(comboBox3.SelectedItem) == "Su ")
                    fiyat_3 = 1;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Cola")
                    fiyat_3 = 4;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Fanta ")
                    fiyat_3 = 4;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Ayran ")
                    fiyat_3 = 2;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Soda ")
                    fiyat_3 = 2;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Meyveli Soda ")
                    fiyat_3 = 3;
                else if (Convert.ToString(comboBox3.SelectedItem) == "Şalgam")
                    fiyat_3 = 4;

            }
            {
                if (Convert.ToString(comboBox4.SelectedItem) == "Kazandibi ")
                    fiyat_4 = 5;
                else if (Convert.ToString(comboBox4.SelectedItem) == "Künefe ")
                {
                    fiyat_4 = 7;
                }
                else if (Convert.ToString(comboBox4.SelectedItem) == "Baklava ")
                    fiyat_4 = 8;
                else if (Convert.ToString(comboBox4.SelectedItem) == "Puding ")
                    fiyat_4 = 4;
                else if (Convert.ToString(comboBox4.SelectedItem) == "Sütlaç ")
                    fiyat_4 = 6;
            }

            {

                if (Convert.ToString(comboBox5.SelectedItem) == "Soğan Halkaları ")
                    fiyat_5 = 6;
                else if (Convert.ToString(comboBox5.SelectedItem) == "Patates Kızartması ")
                    fiyat_5 = 5;
                else if (Convert.ToString(comboBox5.SelectedItem) == "Dondurma ")
                    fiyat_5 += 3;
            }

            double sonuc = fiyat1 + fiyat2 + fiyat_3 + fiyat_4 + fiyat_5;
            textBox6.Text = sonuc.ToString() + " TL";
            string sorgu = "Update fener Set ID=@ID,AdSoyad=@AdSoyad,Telefon=@Telefon,Adres=@Adres,Notlar=@Notlar,Menu=@Menu,PizzaBoyu=@PizzaBoyu,Icecekler=@Icecekler,Tatlilar=@Tatlilar,Ekstra=@Ekstra,fiyat=@fiyat Where ID=@ID";
          SqlCommand  komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@ID", textBox1.Text);
            komut.Parameters.AddWithValue("@AdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("@Telefon", textBox3.Text);
            komut.Parameters.AddWithValue("@Adres", textBox4.Text);
            komut.Parameters.AddWithValue("@Notlar", textBox5.Text);
            komut.Parameters.AddWithValue("@Menu", comboBox1.Text);
            komut.Parameters.AddWithValue("@PizzaBoyu", comboBox2.Text);
            komut.Parameters.AddWithValue("@Icecekler", comboBox3.Text);
            komut.Parameters.AddWithValue("@Tatlilar", comboBox4.Text);
            komut.Parameters.AddWithValue("@Ekstra", comboBox5.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox6.Text);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 abc = new Form3();
            abc.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
