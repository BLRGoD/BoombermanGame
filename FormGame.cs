using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoombermanGame
{
    public delegate void deClear();

    public partial class FormGame : Form
    {
        MainBoard board;
        int Difficulty = 1;
        public FormGame()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            board = new MainBoard(panelGame,StartClear,labelScore);
            ChangeDifficulty(Difficulty);
            timerGameOver.Enabled = true;
        }

        private void обИгреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Описание игры!", "Описание игры");
        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Написал Ахрамович Иван\nСоре за нечитаемый код", "Об авторе");
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if(timerGameOver.Enabled)
            switch (e.KeyCode)
            {
                case Keys.Left: board.MovePlayer(Arrows.left); break;
                case Keys.Right: board.MovePlayer(Arrows.right); break;
                case Keys.Up: board.MovePlayer(Arrows.up); break;
                case Keys.Down: board.MovePlayer(Arrows.down); break;
                case Keys.Space: board.PutBomb(); break;   
            }
        }

        private void timerFireClear_Tick(object sender, EventArgs e)
        {
            board.clearFire();
            timerFireClear.Enabled = false;
        }//очистка клеток с огнём

        private void StartClear()
        {
            timerFireClear.Enabled = true;
        }//запуск таймера очистки

        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            if (board.GameOver())
            {
                timerGameOver.Enabled = false;
                DialogResult dr = MessageBox.Show("Хотите начать заново?","Конец игре",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    NewGame();
                }
                else if (dr == System.Windows.Forms.DialogResult.No)
                {
                    
                }
            }
        }//события при проигрыше

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)//новая игра
        {
            NewGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)//выход
        {
            this.Close();
        }

        private void ChangeDifficulty(int _diff)
        {
            Difficulty = _diff;
            board.SetMobDifficulty(Difficulty);
        }

        private void среднийToolStripMenuItem_Click(object sender, EventArgs e)//уровни сложности
        {
            ChangeDifficulty(2);
        }

        private void сложныйToolStripMenuItem_Click(object sender, EventArgs e)//
        {
            ChangeDifficulty(3);
        }

        private void лёгкийToolStripMenuItem_Click(object sender, EventArgs e)//
        {
            ChangeDifficulty(1);
        }
     
    }
}
