using I_m_end.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace I_m_end
{
    public partial class Form1 : Form
    {
        int MOVES = 0;
        bool LASTPLAYER = true; // true = X's turn, false = O's turn
        bool GameOver = false;
        public Form1()
        {
            InitializeComponent();
            SetupButtons();
        }

       
        private void SetupButtons()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Tag = "?"; // means empty
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.UseVisualStyleBackColor = false;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    // Attach the same click handler to all buttons
                    btn.Click += (s, e) => ChangeImage(btn);
                }
            }
        }

       
          void ResetGame()
        {
            button1.Tag = "?";
            button2.Tag = "?";
            button3.Tag = "?";
            button4.Tag = "?";
            button5.Tag = "?";
            button6.Tag = "?";    
            button7.Tag = "?";
            button8.Tag = "?";
            button9.Tag = "?";

            button1.Image = Resources.QUE;
            button2.Image = Resources.QUE;
            button3.Image = Resources.QUE;
            button4.Image = Resources.QUE;
            button5.Image = Resources.QUE;
            button6.Image = Resources.QUE;
            button7.Image = Resources.QUE;
            button8.Image = Resources.QUE;
            button9.Image = Resources.QUE;

            MOVES = 0;
            LASTPLAYER = true; // Reset to X's turn
            GameOver = false;

           

        }

        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?" && MOVES < 9)
            {
                if (LASTPLAYER) // X's turn
                {
                    btn.Image = Resources.X;
                    btn.Tag = "X";
                    LASTPLAYER = false;
                }
                else // O's turn
                {
                    btn.Image = Resources.O;
                    btn.Tag = "O";
                    LASTPLAYER = true;
                }

                MOVES++;
                CheckAllWinners();
            }
        }


        private void CheckAllWinners()
        {
            CheckWinner(button1, button2, button3);
            CheckWinner(button4, button5, button6);
            CheckWinner(button7, button8, button9);

            CheckWinner(button1, button4, button7);
            CheckWinner(button2, button5, button8);
            CheckWinner(button3, button6, button9);

            CheckWinner(button1, button5, button9);
            CheckWinner(button3, button5, button7);

            if (MOVES == 9 && !GameOver)
            {
                MessageBox.Show("It's a draw!");
                GameOver = true;
            }
        }

        private void CheckWinner(Button b1, Button b2, Button b3)
        {
            if (b1.Tag.ToString() == b2.Tag.ToString() &&
                b2.Tag.ToString() == b3.Tag.ToString() &&
                b1.Tag.ToString() != "?")
            {
                GameOver = true;
                b1.BackColor = Color.Green;
                b2.BackColor = Color.Green;
                b3.BackColor = Color.Green;
                label1.Text = $"Player {b1.Tag} wins!";
            }
        }

        // ✅ Draw TicTacToe grid lines
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Black;
            Color White = Color.FromArgb(255, 255, 255, 255);
            Pen pen = new Pen(White)
            {
                Width = 10,
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };

            int gridWidth = 450;
            int gridHeight = 450;
            int startX = (this.ClientSize.Width - gridWidth) / 2;
            int startY = (this.ClientSize.Height - gridHeight) / 2;
            int cellSize = gridWidth / 3;

            // Draw horizontal lines
            e.Graphics.DrawLine(pen, startX, startY + cellSize, startX + gridWidth, startY + cellSize);
            e.Graphics.DrawLine(pen, startX, startY + 2 * cellSize, startX + gridWidth, startY + 2 * cellSize);

            // Draw vertical lines
            e.Graphics.DrawLine(pen, startX + cellSize, startY, startX + cellSize, startY + gridHeight);
            e.Graphics.DrawLine(pen, startX + 2 * cellSize, startY, startX + 2 * cellSize, startY + gridHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage((button1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage((button2));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage((button3));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage((button4));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage((button5));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage((button6));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage((button7));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage((button8));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage((button9));
        }



        private void button10_Click_1(object sender, EventArgs e)
        {
            button10.BackColor = Color.White;   
            ResetGame();
        }


    }
}
