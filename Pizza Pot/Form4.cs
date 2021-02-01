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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIVP1E4\\SQLEXPRESS;Initial Catalog=kardesler;Integrated Security=True");
        SqlCommand komut;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                komut = new SqlCommand("insert into parola(id,Ad,Sifre) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            
            Form2 abc = new Form2();
            abc.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 abc = new Form3();
            abc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
