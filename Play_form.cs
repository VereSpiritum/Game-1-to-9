using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Project
{
    public partial class Play_form : Form
    {
        private int value;
        private int tracking;
        public int right_tracking;
        public static bool checking { get; set; }
        Label label = new Label();
        Digits digits = new Digits();
        
        
        public Play_form()
        {

            InitializeComponent();          
            Creation(digits.Dig());
            toolTip1.SetToolTip(pictureBox1, "Вихід");

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
                label.Location = new Point(157, 85);
                label.Text = $"Яка цифра йде за {N}?";
                label.ForeColor = Color.LightCoral;
                label.BackColor = Color.Transparent;
                label.TextAlign = ContentAlignment.TopCenter;
                label.Font = new Font("Microsoft Sans Serif", 36);
                Controls.Add(label);
                Mash(N);
                value = N;
            }

        }
       private void Mash(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                switch (i)
                {
                    case 1:
                        picture1.Visible = true;
                        break;
                    case 2:
                        picture2.Visible = true;
                        break;
                    case 3:
                        picture3.Visible = true;
                        break;
                    case 4:
                        picture4.Visible = true;
                        break;
                    case 5:
                        picture5.Visible = true;
                        break;
                    case 6:
                        picture6.Visible = true;
                        break;
                    case 7:
                        picture7.Visible = true;
                        break;
                    case 8:
                        picture8.Visible = true;
                        break;
                    case 9:
                        picture9.Visible = true;
                        break;
                    case 10:
                        picture10.Visible = true;
                        break;

                }

            }
        }
        private void number_Click(int tmp)
        {   
            Checking_answer Answer = new Checking_answer(); 
            if(tmp == value+1)
            {
                Checking_answer.check = true;

                Answer = new Checking_answer();                             
                Answer.ShowDialog();
                picture1.Visible = picture2.Visible = picture3.Visible = picture4.Visible = picture5.Visible =
                    picture6.Visible = picture7.Visible = picture8.Visible = picture9.Visible = picture10.Visible = false;
                Creation(digits.Dig());
                right_tracking++;
                if(right_tracking == 3)
                {
                    this.Close();               
                    Winner winner = new Winner(this.Name);
                    winner.ShowDialog();
                    
                }
            }
            else
            {
                Checking_answer.check = false;
                Answer = new Checking_answer();
                Answer.ShowDialog();
                if (tracking > 2)
                { tracking = 0; }
                if(tracking == 0)
                {
                    pictureBox4.Visible = false;
                }
                else
                {
                    
                    if(tracking == 1)
                    {
                        pictureBox3.Visible = false;
                        Prompt prompt = new Prompt();
                        prompt.ShowDialog();
                        if(prompt.DialogResult == DialogResult.OK)
                        {
                            Mash(value + 1);
                        }
                    }
                    else
                        if(tracking == 2)
                    {
                        pictureBox2.Visible = false;
                        this.Close();
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
                { button2, button3, button4, button5, button6,
                button7, button8, button9, button10, button11 };
            for(int i = 0; i < buttons.Length; i++)
            {
                if(sender == buttons[i])
                {
                    number_Click(int.Parse(buttons[i].Text));
                    break;
                }
            }
            
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            Exit exit = new Exit();
            if (exit.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        
    }
}
