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
        int puloRapido, force, score = 0, playerSpeed = 7, horizontalVelocidade = 5, verticalvelocidade = 3, inimigo2vel = 4, inimigo4vel = 6, inimigo5vel= 6, inimigo6vel = 2, inimigo3vel = 3, flag =0;

        private void button1_Click(object sender, EventArgs e)
        {

            frm_principal pr = new frm_principal();
            this.Hide();
            pr.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
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
            if (Player.Bounds.IntersectsWith(ganhoou.Bounds) && score == 66)
            {
               
                GameTimer.Stop();
                flag = 2;
                GameOver = true;
                MENSSAGEM.Text = "Parabéns, você ganhou!";
                frm_principal pr = new frm_principal();
                pr.Show();
                this.Hide();
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
            inimigo4.Left = 1100;
            inimigo5.Left = 868;
            inimigo6.Left = 795;

            plataformHorizontal.Left = 340;
            plataformHorizontalll.Left = 297;
            plataformVertical.Top = 367;

            GameTimer.Start();


        }

        private void frm_nivel2_Load(object sender, EventArgs e)
        {

        }

    }
}
