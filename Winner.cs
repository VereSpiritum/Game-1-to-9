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
    public partial class Winner : Form
    {
        new object Name;
        Play_form3 play_Form3 = new Play_form3();
        public Winner(Object name)
        {
            InitializeComponent();
            SoundPlayer soundPlayer = new SoundPlayer("won.wav");
            soundPlayer.Play();
            Name = name;
            
            if (Name.ToString() == play_Form3.Name)
            {
                button1.Text = "Закінчити гру";
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 25);
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Закінчити гру")
            {
                Application.Exit();
            }
            else
            {
                this.Close();
                Play_form play_Form = new Play_form();
                Play_form2 play_Form2 = new Play_form2();
                if (Name.ToString() == play_Form.Name)
                { play_Form2.Show(); }
                else
                {
                    play_Form3.Show();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Play_form play_Form = new Play_form();
            if(Name.ToString() == play_Form.Name)
            {
                Levels.l2 = true;
            }
            else
            {
                Levels.l3 = true;
                Levels.l2 = true;
            }
            Levels levels = new Levels();             
            levels.Show();
        }
    }
}
