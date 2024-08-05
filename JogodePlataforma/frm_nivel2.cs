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
    public partial class frm_nivel2 : Form
    {

        bool goleft, goright, pular, GameOver;
        int puloRapido, force, score = 0, playerSpeed = 7, horizontalVelocidade = 5, verticalvelocidade = 3, inimigo2vel = 4, inimigo4vel = 6, inimigo5vel= 6, inimigo6vel = 2, inimigo3vel = 3;

        private void pictureBox31_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox73_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox83_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        public frm_nivel2()
        {
            InitializeComponent();
        }


        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtpontuacao.Text = "Pontuação: " + score;

            Player.Top += puloRapido;

            if (goleft == true)
            {
                Player.Left -= playerSpeed;
            }
            if (goright == true)
            {
                Player.Left += playerSpeed;
            }
            if (pular == true && force < 0)
            {
                pular = false;
            }
            if (pular == true)
            {
                puloRapido = -8;
                force -= 1;
            }
            else
            {
                puloRapido = 10;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "plataformplataform")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            Player.Top = x.Top - Player.Height;


                            if (((string)x.Name == "plataformHorizontal" && goleft == false || (string)x.Name == "plataformHorizontal" && goright == false) && ((string)x.Name == "plataformHorizontalll" && goleft == false || (string)x.Name == "plataformHorizontalll" && goright == false))
                            {
                                Player.Left -= horizontalVelocidade;
                            }

                        }
                        x.BringToFront();
                    }
                    if ((string)x.Tag == "coin")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if ((string)x.Tag == "inimigo")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameTimer.Stop();
                            GameOver = true;
                            MENSSAGEM.Visible = true;
                            //txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Você falhou miseravelmente!";
                        }
                    }

                }

            }
            plataformHorizontal.Left -= horizontalVelocidade;
            plataformHorizontalll.Left -= horizontalVelocidade;

            if ((plataformHorizontal.Left < 0 || plataformHorizontal.Left + plataformHorizontal.Width > 500) && (plataformHorizontalll.Left < 0 || plataformHorizontalll.Left + plataformHorizontalll.Width > 500))
            {
                horizontalVelocidade = -horizontalVelocidade;
            }

            plataformVertical.Top += verticalvelocidade;

            if (plataformVertical.Top < 222 || plataformVertical.Top > 367)
            {
                verticalvelocidade = -verticalvelocidade;
            }

            inimigo2.Left -= inimigo2vel;

            if (inimigo2.Left < pictureBox5.Left || inimigo2.Left + inimigo2.Width > pictureBox5.Left + pictureBox5.Width)
            {
                inimigo2vel = -inimigo2vel;
            }


            inimigo4.Left -= inimigo4vel;
            if (inimigo4.Left < pictureBox40.Left || inimigo4.Left + inimigo4.Width > pictureBox40.Left + pictureBox40.Width)
            {
                inimigo4vel = -inimigo4vel;
            }
            inimigo3.Left -= inimigo3vel;
            if (inimigo3.Left < pictureBox7.Left || inimigo3.Left + inimigo3.Width > pictureBox7.Left + pictureBox7.Width)
            {
                inimigo3vel = -inimigo3vel;
            }
            inimigo5.Left -= inimigo5vel;
            if (inimigo5.Left < pictureBox40.Left || inimigo5.Left + inimigo5.Width > pictureBox40.Left + pictureBox40.Width)
            {
                inimigo5vel = -inimigo5vel;
            }
            inimigo6.Left -= inimigo6vel;
            if (inimigo6.Left < pictureBox45.Left || inimigo6.Left + inimigo6.Width > pictureBox45.Left + pictureBox45.Width)
            {
                inimigo6vel = -inimigo6vel;
            }

            if (Player.Top + Player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                GameOver = true;
                MENSSAGEM.Visible = true;
                // txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Você falhou miseravelmente!";
            }
            if (Player.Bounds.IntersectsWith(ganhou.Bounds) && score == 70)
            {
                GameTimer.Stop();
                GameOver = true;
                MENSSAGEM.Text = "Parabéns, você ganhou!";
                MENSSAGEM.Visible = true;
                // txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Parabéns, você ganhou!";
            }
            else
            {
                txtpontuacao.Text = "Pontuação: " + score + Environment.NewLine + "Colete todos os queijinhos!";
            }

        }

        private void ChaveBaixo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && pular == false)
            {
                pular = true;
            }
        }

        private void ChaveCima(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (pular == true)
            {
                pular = false;
            }
            if (e.KeyCode == Keys.Enter && GameOver == true)
            {
                RestartGame();
            }
        }
        private void RestartGame()
        {
            MENSSAGEM.Visible = false;

            pular = false;
            goleft = false;
            goright = false;
            GameOver = false;
            score = 0;
            MENSSAGEM.Text = "PRESSIONE 'ENTER' PARA RECOMEÇAR";
            txtpontuacao.Text = "Pontuação: " + score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            Player.Left = 96;
            Player.Top = 520;


            inimigo2.Left = 387;

            inimigo3.Left = 366;
            inimigo4.Left = 1262;
            inimigo5.Left = 868;
            inimigo6.Left = 960;

            plataformHorizontal.Left = 340;
            plataformHorizontalll.Left = 297;
            plataformVertical.Top = 367;

            GameTimer.Start();


        }

        private void frm_nivel2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }
    }
}
