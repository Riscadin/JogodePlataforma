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

    public partial class frm_fase3 : Form
    {
        bool goleft, goright, pular, GameOver;
        int puloRapido, force, score = 0, playerSpeed = 7, horizontalVelocidade = 5, verticalvelocidade = 3, inimigo1vel = 4 , inimigo4vel = 3, inimigo2vel = 3, inimigo3vel = 3, flag = 0;
        public frm_fase3()
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
            plataformVertical.Top += verticalvelocidade;

            if (plataformVertical.Top < 194 || plataformVertical.Top > 232)
            {
                verticalvelocidade = -verticalvelocidade;
            }

            inimigo2.Left -= inimigo2vel;

            if (inimigo2.Left < pictureBox16.Left || inimigo2.Left + inimigo2.Width > pictureBox16.Left + pictureBox16.Width)
            {
                inimigo2vel = -inimigo2vel;
            }


            inimigo4.Left -= inimigo4vel;
            if (inimigo4.Left < pictureBox21.Left || inimigo4.Left + inimigo4.Width > pictureBox21.Left + pictureBox21.Width)
            {
                inimigo4vel = -inimigo4vel;
            }
            inimigo3.Left -= inimigo3vel;
            if (inimigo3.Left < pictureBox18.Left || inimigo3.Left + inimigo3.Width > pictureBox18.Left + pictureBox18.Width)
            {
                inimigo3vel = -inimigo3vel;
            }
            inimigo1.Left -= inimigo1vel;
            if (inimigo1.Left < pictureBox3.Left || inimigo1.Left + inimigo1.Width > pictureBox3.Left + pictureBox3.Width)
            {
                inimigo1vel = -inimigo1vel;
            }

            if (Player.Top + Player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                GameOver = true;
                MENSSAGEM.Visible = true;
                // txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Você falhou miseravelmente!";
            }
            if (Player.Bounds.IntersectsWith(ganhoou.Bounds) /*&& score == 70*/)
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
            Player.Left = 533;
            Player.Top = 496;


            inimigo2.Left = 325;

            inimigo3.Left = 672;
            inimigo4.Left = 946;
            inimigo1.Left = 764;
            plataformVertical.Top = 194;

            GameTimer.Start();


        }
    }
}
