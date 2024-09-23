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
    public partial class Form1 : Form
    {
        bool goleft, goright, pular, GameOver;
        int puloRapido, force, score=0, playerSpeed=7, horizontalVelocidade=5, verticalvelocidade=3,inimigo2vel=4,inimigo3vel=3,flag=0;

        private void button1_Click(object sender, EventArgs e)
        {
            frm_principal pr = new frm_principal();
            this.Hide();
            pr.Show();
        }

        private void ganhou_Click(object sender, EventArgs e)
        {

        }

        private void MENSSAGEM_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtscore.Text = "Pontuação: "+score;

            Player.Top += puloRapido;

            if (goleft == true)
            {
                Player.Left -= playerSpeed;
            }
            if(goright == true)
            {
                Player.Left += playerSpeed;
            }
            if(pular == true && force < 0)
            {
                pular = false;  
            }
            if(pular == true )
            {
                puloRapido = -8;
                force -= 1;
            }
            else
            {
                puloRapido = 10;
            }
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "plataformplataform")
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
                    if((string)x.Tag == "coin")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if((string)x.Tag == "inimigo")
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

            if((plataformHorizontal.Left < 0 || plataformHorizontal.Left + plataformHorizontal.Width > this.ClientSize.Width) && (plataformHorizontalll.Left < 0 || plataformHorizontalll.Left + plataformHorizontalll.Width > this.ClientSize.Width))
            {
                horizontalVelocidade = -horizontalVelocidade;
            }

            plataformVertical.Top += verticalvelocidade;

            if(plataformVertical.Top < 370 || plataformVertical.Top > 581)
            {
                verticalvelocidade = -verticalvelocidade;
            }

            inimigo2.Left -= inimigo2vel;

            if(inimigo2.Left < pictureBox5.Left || inimigo2.Left + inimigo2.Width > pictureBox5.Left + pictureBox5.Width)
            {
                inimigo2vel = -inimigo2vel;
            }


            inimigo3.Left -= inimigo3vel;
            if (inimigo3.Left < pictureBox7.Left || inimigo3.Left + inimigo3.Width > pictureBox7.Left + pictureBox7.Width)
            {
                inimigo3vel = -inimigo3vel;
            }

            if(Player.Top + Player.Height > this.ClientSize.Height + 50)
            {
                GameTimer.Stop();
                GameOver =true;
                MENSSAGEM.Visible = true;
               // txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Você falhou miseravelmente!";
            }
            if(Player.Bounds.IntersectsWith(ganhou.Bounds)/* && score == 35*/)
            {
                flag = 1;
                GameTimer.Stop();
                GameOver = true;
                MENSSAGEM.Text = "Parabéns, você ganhou!";
                this.Hide();
               // txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Parabéns, você ganhou!";
            }
            else
            {
                txtscore.Text = "Pontuação: " + score + Environment.NewLine + "Colete todos os queijinhos!";
            }
             
        }

        private void ChaveBaixo(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;

            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if(e.KeyCode == Keys.Space && pular == false)
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
            if(pular == true)
            {
                pular = false;
            }
            if(e.KeyCode == Keys.Enter && GameOver == true)
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
            txtscore.Text = "Pontuação: " + score;
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            Player.Left = 94;
            Player.Top = 701;
            
            
            inimigo2.Left = 391;
            
            inimigo3.Left= 364;

            plataformHorizontal.Left = 338;
            plataformHorizontalll.Left = 295;
            plataformVertical.Top = 548;

            GameTimer.Start();


        }
    }
}
