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
    public partial class Game_over : Form
    {
        public Game_over()
        {
            InitializeComponent();
            SoundPlayer soundPlayer = new SoundPlayer("lose.wav");
            soundPlayer.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Levels levels = new Levels();
            this.Close();
            levels.Show();
        }
    }
}
