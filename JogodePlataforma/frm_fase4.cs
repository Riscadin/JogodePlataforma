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
    public partial class frm_fase4 : Form
    {
        bool goleft, goright, pular, GameOver;
        int puloRapido, force, score = 0, playerSpeed = 8, horizontalVelocidade = 5, verticalvelocidade = 3, inimigo1vel = 4, inimigo2vel = 4, inimigo3vel = 4, inimigo5vel = 4, inimigo6vel = 7,inimigo7vel = 4, inimigo8vel = 4
            , inimigo9vel = 4;

        private void button1_Click(object sender, EventArgs e)
        {

            frm_principal pr = new frm_principal();
            this.Hide();
            pr.Show();
        }

        private void ganhoou_Click(object sender, EventArgs e)
        {

        }

        int inimigo10vel = 7, inimigo11vel = 4, inimigo12vel = 4, inimigo13vel = 4, inimigo14vel = 4, inimigo15vel = 7;
        public frm_fase4()
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
            if (plataformVertical.Top < 196 || plataformVertical.Top > 718)
            {
                verticalvelocidade = -verticalvelocidade;
            }

            inimigo2.Left -= inimigo2vel;

            if (inimigo2.Left < pictureBox6.Left || inimigo2.Left + inimigo2.Width > pictureBox6.Left + pictureBox6.Width)
            {
                inimigo2vel = -inimigo2vel;
            }


            //inimigo4.Left -= inimigo4vel;
            //if (inimigo4.Left < pictureBox5.Left || inimigo4.Left + pictureBox5.Width > pictureBox5.Left + pictureBox5.Width)
            //{
            //    inimigo4vel = -inimigo4vel;
            //}
            inimigo3.Left -= inimigo3vel;
            if (inimigo3.Left < pictureBox5.Left || inimigo3.Left + inimigo3.Width > pictureBox5.Left + pictureBox5.Width)
            {
                inimigo3vel = -inimigo3vel;
            }
            inimigo1.Left -= inimigo1vel;
            if (inimigo1.Left < pictureBox1.Left || inimigo1.Left + inimigo1.Width > pictureBox1.Left + pictureBox1.Width)
            {
                inimigo1vel = -inimigo1vel;
            }
            inimigo5.Left -= inimigo5vel;
            if (inimigo5.Left < pictureBox2.Left || inimigo5.Left + inimigo5.Width > pictureBox2.Left + pictureBox2.Width)
            {
                inimigo5vel = -inimigo5vel;
            }
            inimigo6.Left -= inimigo6vel;
            if (inimigo6.Left < pictureBox2.Left || inimigo6.Left + inimigo6.Width > pictureBox2.Left + pictureBox2.Width)
            {
                inimigo6vel = -inimigo6vel;
            }
            inimigo7.Left -= inimigo7vel;
            if (inimigo7.Left < pictureBox2.Left || inimigo7.Left + inimigo7.Width > pictureBox2.Left + pictureBox2.Width)
            {
                inimigo7vel = -inimigo7vel;
            }
            inimigo8.Left -= inimigo8vel;
            if (inimigo8.Left < pictureBox2.Left || inimigo8.Left + inimigo8.Width > pictureBox2.Left + pictureBox2.Width)
            {
                inimigo8vel = -inimigo8vel;
            }
            inimigo9.Left -= inimigo9vel;
            if (inimigo9.Left < pictureBox2.Left || inimigo9.Left + inimigo9.Width > pictureBox2.Left + pictureBox2.Width)
            {
                inimigo9vel = -inimigo9vel;
            }
            inimigo10.Left -= inimigo10vel;
            if (inimigo10.Left < pictureBox3.Left || inimigo10.Left + inimigo10.Width > pictureBox3.Left + pictureBox3.Width)
            {
                inimigo10vel = -inimigo10vel;
            }
            //inimigo11.Left -= inimigo11vel;
            //if (inimigo11.Left < pictureBox3.Left || inimigo11.Left + inimigo11.Width > pictureBox3.Left + pictureBox3.Width)
            //{
            //    inimigo11vel = -inimigo11vel;
            //}
            inimigo12.Left -= inimigo12vel;
            if (inimigo12.Left < pictureBox3.Left || inimigo12.Left + inimigo12.Width > pictureBox3.Left + pictureBox3.Width)
            {
                inimigo12vel = -inimigo12vel;
            }
            inimigo13.Left -= inimigo13vel;
            if (inimigo13.Left < sla.Left || inimigo13.Left + inimigo13.Width > sla.Left + sla.Width)
            {
                inimigo13vel = -inimigo13vel;
            }
            //inimigo14.Left -= inimigo14vel;
            //if (inimigo14.Left < sla.Left || inimigo14.Left + inimigo14.Width > sla.Left + sla.Width)
            //{
            //    inimigo11vel = -inimigo11vel;
            //}
            inimigo15.Left -= inimigo15vel;
            if (inimigo15.Left < sla.Left || inimigo15.Left + inimigo15.Width > sla.Left + sla.Width)
            {
                inimigo15vel = -inimigo15vel;
            }


            if (Player.Top + Player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                GameOver = true;
                MENSSAGEM.Visible = true;
                // txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Você falhou miseravelmente!";
            }
            if (Player.Bounds.IntersectsWith(ganhoou.Bounds) && score == 47)
            {

                GameTimer.Stop();
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
            Player.Left = 12;
            Player.Top = 681;


            inimigo2.Left = 693;

            inimigo3.Left = 389; 
            //inimigo4.Left = 693;
            inimigo1.Left = 1312;
            inimigo5.Left = 1354;
            inimigo6.Left = 704; 
            inimigo7.Left = 514;
            inimigo8.Left = 275;
            inimigo9.Left = 161;
            inimigo10.Left = 1182;
            //inimigo11.Left = 916;
            inimigo12.Left = 149;

            inimigo13.Left = 335;
            //inimigo14.Left = 559;
            inimigo15.Left = 1317;
            plataformVertical.Top = 718;

            GameTimer.Start();


        }
    }
}
