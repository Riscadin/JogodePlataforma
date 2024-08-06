using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogodePlataforma
{
    
    public partial class frm_principal : Form
    {
       
        public frm_principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                frm_nivel2 n2 = new frm_nivel2();
                this.Hide();
                n2.Show();
        }

        private void frm_principal_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_fase3 f3 =new frm_fase3();
            this.Hide();
            f3.Show();
        }
    }
}
