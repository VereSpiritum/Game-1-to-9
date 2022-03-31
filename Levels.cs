using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Project
{
    public partial class Levels : Form
    {
        public static bool l2 { get; set; }
        public static bool l3 { get; set; }
        public Levels()
        {
            InitializeComponent();
            if(l2)
            {
                label2.Enabled = true;
            }
            if (l3)
            {
                label3.Enabled = true;
            }
            SoundPlayer soundPlayer = new SoundPlayer("Play.wav");
            soundPlayer.PlayLooping();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Play_form play_Form = new Play_form();
            this.Close();
            play_Form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Play_form2 play_Form2 = new Play_form2();
            this.Close();
            play_Form2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Exit exit = new Exit();
            if (exit.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Play_form3 play_Form3 = new Play_form3();
            this.Close();
            play_Form3.Show();
        }
    }
}
