using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Enventer_Prog
{
    public partial class Form2 : Form
    {
        SqlConnection baglantı = new SqlConnection("server=.;initial catalog=EnvanterProg;integrated security=sspi;");
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();
        public Form2()
        {
            InitializeComponent();
        }
        void datget()
        {
            
            baglantı.Open();
            adap = new SqlDataAdapter("Select * From Urun",baglantı);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            datget();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {   string tıp;
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tıp = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (tıp == "Giriş")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            { comboBox1.SelectedIndex = 1; }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string sorg = "INSERT INTO Urun (Ürün,Adet,Fiyat,İşlem_Tipi,Tarih) VALUES (@Ürün,@Adet,@Fiyat,@İşlem_Tipi,@Tarih)";
            komut=new SqlCommand(sorg,baglantı);
            komut.Parameters.AddWithValue("@Ürün", textBox2.Text);
            komut.Parameters.AddWithValue("@Adet",Convert.ToInt32(textBox3.Text));
            komut.Parameters.AddWithValue("@Fiyat",Convert.ToInt32(textBox4.Text));
            komut.Parameters.AddWithValue("@İşlem_Tipi", comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            baglantı.Open();
            komut.ExecuteNonQuery();
            baglantı.Close();
            datget();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Sil = "Delete From Urun Where İşlem_No=@İşlem_No";
            komut = new SqlCommand(Sil, baglantı);
            komut.Parameters.AddWithValue("@İşlem_No", textBox1.Text);
            baglantı.Open();
            komut.ExecuteNonQuery();
            baglantı.Close();
            datget();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string up = "UPDATE Urun Set Ürün=@Ürün,Adet=@Adet,Fiyat=@Fiyat,İşlem_Tipi=@İşlem_Tipi,Tarih=@Tarih where İşlem_No=@İşlem_No";
            komut = new SqlCommand(up, baglantı);
            komut.Parameters.AddWithValue("@Ürün", textBox2.Text);
            komut.Parameters.AddWithValue("@Adet", Convert.ToInt32(textBox3.Text));
            komut.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(textBox4.Text));
            komut.Parameters.AddWithValue("@İşlem_Tipi", comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@İşlem_No", Convert.ToInt32(textBox1.Text));
            baglantı.Open();
            komut.ExecuteNonQuery();
            baglantı.Close();
            datget();

        }
    }
}
