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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

         SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AIVP1E4\\SQLEXPRESS;Initial Catalog=kardesler;Integrated Security=True");
        public static string giris = "";
        public static string sifre = "";
        public static string yetki = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "Select * From parola where Ad=@adi AND Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form3 abc = new Form3();
                    abc.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş");

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 abc = new Form4();
            abc.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
