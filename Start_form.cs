using System;
using System.Windows.Forms;
using System.Media;

namespace Project
{
    public partial class Start_form : Form
    {
        public Start_form()
        {
            InitializeComponent();

            SoundPlayer soundPlayer = new SoundPlayer("Play.wav");
            soundPlayer.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Levels levels = new Levels();
            this.Hide();
            levels.Show();

        }
    }
}
