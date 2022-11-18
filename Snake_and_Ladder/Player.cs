using Snake_and_Ladder.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Snake_and_Ladder
{
    internal class Player
    {
        public int turn = 0;
        //ladder position
        public int[] ladder = { 4, 21, 29, 43, 63, 71};
        //snake position
        public int[] sanke = { 30, 47, 56, 73, 82, 92, 98};
       
        //roll dice random number and appending in picture box
        public static int rolldice(PictureBox px)
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);
            string d = "_"+dice.ToString();
            px.Image = (Image)Resources.ResourceManager.GetObject(d);
            px.SizeMode = PictureBoxSizeMode.StretchImage;
            return dice;
            //sound 
            System.IO.Stream s1 = Resources.up;
            SoundPlayer su1 = new SoundPlayer(s1);
            su1.Play();
        }

        //-------------------- when player not in snake or ladder -----------------
        public void move(ref int x, ref int y, ref int p, int dice, ref int[] pos, PictureBox px,Label a)
        {
            System.IO.Stream s2 = Resources.up;
            SoundPlayer su2 = new SoundPlayer(s2);
            su2.Play();

            if (dice + p > 100)
            {
                a.Text = "can not move";
                a.ForeColor = Color.Red;
                return;
            }
            for (int i = 0; i < dice; i++)
            {
                if (p == 10)
                {
                    x = 582;
                    y = 373;
                    turn++;
                }
                else if (p == 20)
                {
                    x = 10;
                    y = 323;
                    turn = 2;
                }
                else if (p == 30)
                {
                    x = 582;
                    y = 272;
                    turn = 3;
                }
                else if (p == 40)
                {
                    x = 10;
                    y = 228;
                    turn = 4;
                }
                else if (p == 50)
                {
                    x = 582;
                    y = 185;
                    turn = 5;
                }
                else if (p == 60)
                {
                    x = 10;
                    y = 143;
                    turn = 6;
                }
                else if (p == 70)
                {
                    x = 582;
                    y = 100;
                    turn = 7;
                }
                else if (p == 80)
                {
                    x = 10;
                    y = 55;
                    turn = 8;
                }
                else if (p == 90)
                {
                    x = 582;
                    y = 10;
                    turn = 9;
                }

                else if (turn % 2 == 0)
                {
                    x += 60;
                }
                else if (turn % 2 != 0)
                {
                    x -= 62;
                }
                px.Location = new Point(x, y);
                p++;
                pos[p] = 1;
            }

        }
        //###########################when player in postion of ladder ###################
        public void laddermove(ref int x, ref int y, ref int p, ref int[] pos, PictureBox px)
        {
            if (p == 4)
            {
                x = 265;
                y = 319;
                p = 25;
                turn = 2;
            }
            else if (p == 21)
            {
                x = 81;
                y = 274;
                p = 39;
                turn = 2;
            }
            else if (p == 29)
            {
                x = 383;
                y = 96;
                p = 74;
                turn = 1;
            }

            else if (p == 49)
            {
                x = 265;
                y = 95;
                p = 76;
                turn = 1;
            }
            else if (p == 63)
            {
                x = 12;
                y = 97;
                p = 81;
                turn = 1;
            }
            else if (p == 71)
            {
                x = 509;
                y = 55;
                p = 89;
                turn = 1;
            }
            px.Location = new Point(x, y);
            pos[p] = 1;
        }
        //###########################when player in postion of sanke ####################
        public void snakemove(ref int x, ref int y, ref int p, ref int[] pos, PictureBox px)
        {
            System.IO.Stream s3 = Resources.down;
            SoundPlayer sd3 = new SoundPlayer(s3);
            sd3.Play();
            if (p == 30)
            {
                x = 379;
                y = 413;
                p = 7;
                turn = 2;
            }
            else if (p == 47)
            {
                x = 325;
                y = 367;
                p = 15;
                turn = 1;
            }
            else if (p == 56)
            {
                x = 81;
                y = 366;
                p = 19;
                turn = 1;
            }
            else if (p == 73)
            {
                x = 569;
                y = 191;
                p = 51;
                turn = 1;
            }
            else if (p == 82)
            {
                x = 84;
                y = 232;
                p = 42;
                turn = 2;
            }
            else if (p == 92)
            {
                x = 323;
                y = 99;
                p = 75;
                turn = 1;
            }
            else if (p == 98)
            {
                x = 324;
                y = 184;
                p = 55;
                turn = 1;
            }
            px.Location = new Point(x, y);
            pos[p] = 1;
         }

        }
    }
