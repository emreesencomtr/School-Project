using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Project
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKulup frm = new frmKulup();
            frm.ShowDialog();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler frm = new FrmDersler();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm= new FrmOgrenci();
            frm.Show();
        }

        private void BtnSinavNotlar_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frm= new FrmSinavNotlar();
            frm.ShowDialog();
        }
    }
}
