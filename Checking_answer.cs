using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System;


namespace Project
{
    public partial class Checking_answer : Form
    {
        private int i;
        public static bool check { get; set; }
        public Checking_answer()
        {
            InitializeComponent();           
            Answer(check);
           
            
        }
        
        private void Answer(bool check)
        {
            timer1.Enabled = true;
                     
            if(check)
            {
                Random random = new Random();
                i = random.Next(0, 2);              
                switch (i)
                {
                    case 0: pictureBox1.Image = Properties.Resources._1;
                        break;
                    case 1:
                        pictureBox1.Image = Properties.Resources._2;
                        break;                   
                    case 2:
                        pictureBox1.Image = Properties.Resources._4;
                        break;
                }
                i++;
                SoundPlayer soundPlayer = new SoundPlayer("True.wav");
                soundPlayer.Play();
                
            }
            else
            {
                pictureBox1.Image = Properties.Resources._false;
                SoundPlayer soundPlayer = new SoundPlayer("False.wav");
                soundPlayer.Play();
                
            }
            
            
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            Play_form play_Form = new Play_form();
            SoundPlayer soundPlayer = new SoundPlayer("Play.wav");
            soundPlayer.PlayLooping();
        }

        
    }
}
