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

namespace School_Project
{
    public partial class frmKulup : Form
    {
        public frmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-83L42UFV\SQLEXPRESS;Initial Catalog=OkulDb;Integrated Security=True;Encrypt=False");

       public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TblKulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmKulup_Load(object sender, EventArgs e)
        {

            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblKulupler (KulupAd) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from TblKulupler where Kulupid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Silme İşlemi Gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TblKulupler set KulupAd=@p1 where Kulupid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKulupID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Güncelleme İşlemi Gerçekleştirildi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Question);
            liste();
        }
    }
}
