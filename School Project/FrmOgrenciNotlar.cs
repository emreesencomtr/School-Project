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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti= new SqlConnection(@"Data Source=LAPTOP-83L42UFV\SQLEXPRESS;Initial Catalog=OkulDb;Integrated Security=True;Encrypt=False");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama, durum from TblNotlar inner join TblDersler on TblNotlar.Dersid=TblDersler.Dersid where Ogrid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);

            SqlDataAdapter da = new SqlDataAdapter(komut); // SqlDataAdapter'a komut nesnesini ekledik
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            //Form İsmine Öğrenci Adının Yazılması

            baglanti.Open();
            SqlCommand komut1= new SqlCommand("Select Ogrid, OgrAd,OgrSoyad from TblOgrenciler where Ogrid=@p1",baglanti);
            komut1.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                this.Text= dr1[0]+ "-"+ dr1[1] +"" + dr1[2].ToString();
            }
            baglanti.Close();

        }
    }
}
