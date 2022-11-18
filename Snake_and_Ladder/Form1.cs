using Snake_and_Ladder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_and_Ladder
{
    public partial class Form1 : Form
    {
        int[] pos = new int[101];
        int rx = 32, ry = 412, red_p = 0, dicevalue;
        int bx = 32, by = 412, blue_p = 0;
        bool red = false, blue = false;
        Player p1;
        Player p2;
       

        public Form1()
        {
            InitializeComponent();
            p1 = new Player();
            p2 = new Player();
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }
        //--------------- red player --------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            // roll dice 
            dicevalue = Player.rolldice(pictureBox3);
            // 
            if (dicevalue == 6 && red == false)
            {
                pictureBox4.Visible = true;
                red = true;
                pictureBox4.Location = new Point(rx, ry);
                red_p++;
                pos[red_p] = 1;
            }
            //
            else if (red == true)
            {
                p1.move(ref rx, ref ry, ref red_p, dicevalue, ref pos, pictureBox4,label3);
                //check if dice + postion will be in ladder postion 
                for (int i = 0; i < p1.ladder.Length; i++)
                {
                    if (red_p == p1.ladder[i])
                    {
                        p1.laddermove(ref rx, ref ry, ref red_p, ref pos, pictureBox4);
                    }
                }
                //check if dice + postion will be in snake postion 
                for (int i = 0; i < p1.sanke.Length; i++)
                {
                    if (red_p == p1.sanke[i])
                    {
                        p1.snakemove(ref rx, ref ry, ref red_p, ref pos, pictureBox4);
                    }
                }
            }
            // red player win 
            if (red_p == 100)
            {
                MessageBox.Show("player 1 win");
                button1.Enabled = false;
                button2.Enabled = false;
            }
            button2.Visible = true;
            button1.Visible = false;

        }

        //------------------------ blue player -------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            dicevalue = Player.rolldice(pictureBox3);

            if (dicevalue == 6 && blue == false)
            {
                pictureBox5.Visible = true;
                blue = true;
                pictureBox5.Location = new Point(bx, by);
                blue_p++;
                pos[blue_p] = 1;
            }

            else if (blue == true)
            {
                p2.move(ref bx, ref by, ref blue_p, dicevalue, ref pos, pictureBox5,label4);
                //check if dice + postion will be in ladder postion 
                for (int i = 0; i < p2.ladder.Length; i++)
                {
                    if (blue_p == p2.ladder[i])
                    {
                        p2.laddermove(ref bx, ref by, ref blue_p, ref pos, pictureBox5);
                    }
                }
                //check if dice + postion will be in snake postion 
                for (int i = 0; i < p2.sanke.Length; i++)
                {
                    if (blue_p == p2.sanke[i])
                    {
                        p2.snakemove(ref bx, ref by, ref blue_p, ref pos, pictureBox5);
                    }
                }
            }
            if (blue_p == 100)
            {
                MessageBox.Show("player 2 win");
                button1.Enabled = false;
                button2.Enabled = false;

            }
            button2.Visible = false;
            button1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = true;
            button1.Enabled = true;
            button2.Enabled = true;
            rx = 32; ry = 412; red_p = 0;
            bx = 32; by = 412; blue_p = 0;
            red = false; blue = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }
    }
}
