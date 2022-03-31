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
    public partial class Play_form2 : Form
    {
        private int value;
        private int tracking;
        
        public static bool checking { get; set; }
        private int right_tracking;
        readonly Label label = new Label();
        readonly Digits digits = new Digits();
       
        public Play_form2()
        {
            InitializeComponent();
            Creation(digits.Dig());
            toolTip1.SetToolTip(pictureBox1, "Вихід");
            SoundPlayer soundPlayer = new SoundPlayer("Play.wav");
            soundPlayer.PlayLooping();
        }
        private void Creation(int N)
        {
            if (value == N)
            {

                Creation(digits.Dig());
            }
            else
            {
                digits.Save = N;
                label.AutoSize = true;
                label.Location = new Point(157, 70);
                label.Text = $"Яка цифра йде за {N}?";
                label.ForeColor = Color.LightCoral;
                label.BackColor = Color.Transparent;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Font = new Font("Microsoft Sans Serif", 36);
                Controls.Add(label);
                value = N;
                Buttons_location();
                

            }

        }
        private void Buttons_location()
        {
            Button[] buttons = 
                { button1, button2, button3, button4, button5, 
                button6, button7, button8, button9, button10 };
            Random random = new Random();
            int X = 0, X1 = 0;
            for(int i = 0; i < buttons.Length; i++)
            {

                buttons[i].Location = new Point(random.Next(X1, X)+54, random.Next(100, Size.Height - 100) + 48);
                X1 = buttons[i].Location.X + 5;
                X = X1 +20;

            }


            for (int i = 0; i < buttons.Length - 1; i++)
            {
                Button temp = new Button();
                int j = random.Next(i+1, buttons.Length - 1);
                if (j != i)
                {
                    temp.Location = buttons[i].Location;
                    buttons[i].Location = buttons[j].Location;
                    buttons[j].Location = temp.Location;
                }
                
            }

        }
        private void number_Click(int tmp)
        {
            Checking_answer Answer;
            if (tmp == value + 1)
            {
                Checking_answer.check = true;
                Answer = new Checking_answer();
                Answer.ShowDialog();               
                
                right_tracking++;
                if (right_tracking == 3)
                {
                    this.Close();
                    Winner winner = new Winner(this.Name);
                    winner.ShowDialog();

                }
                Creation(digits.Dig());
            }
            else
            {
                Checking_answer.check = false;
                Answer = new Checking_answer();
                Answer.ShowDialog();
                if (tracking > 2)
                { tracking = 0; }
                if (tracking == 0)
                {
                    pictureBox4.Visible = false;
                }
                else
                {

                    if (tracking == 1)
                    {
                        pictureBox3.Visible = false;                     
                    }
                    else
                        if (tracking == 2)
                    {
                        pictureBox2.Visible = false;
                        this.Hide();
                        Game_over game_Over = new Game_over();
                        game_Over.ShowDialog();
                    }
                }
                tracking++;

            }
        }
        private void button_Click(object sender, System.EventArgs e)
        {
            Button[] buttons =
                { button1, button2, button3, button4, button5,
                button6, button7, button8, button9, button10 };

            for (int i = 0; i < buttons.Length; i++)
            {
                if (sender == buttons[i])
                {
                    number_Click(int.Parse(buttons[i].Text));
                    break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Exit exit = new Exit();
            if (exit.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
