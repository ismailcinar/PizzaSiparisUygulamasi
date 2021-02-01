using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace olacak
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLExpress;  Initial Catalog=kardesler;Integrated Security=SSPI");
        SqlCommand komut;
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {

                komut = new SqlCommand("delete from parola where id='" + textBox1.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
            this.Hide();
            Form2 abc = new Form2();
            abc.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 abc = new Form3();
            abc.Show();
            this.Hide();
        }
    }
}
