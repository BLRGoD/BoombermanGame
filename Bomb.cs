using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BoombermanGame
{
    public class Bomb
    {
        Timer timer;//переменная таймера бомбы
        int SecQuantity = 4;//переменная ко-ва секунд
        PictureBox[,] mapPic;
        public Point bombPlace { get; private set; }
        deBaBah BaBah;

        public Bomb(PictureBox[,] _mapPic, Point _bombPlace, deBaBah _BaBah)
        {
            mapPic = _mapPic;
            bombPlace = _bombPlace;
            BaBah = _BaBah;//подключение делегата взрыва
            CreateTimer();//создание таймера
            timer.Enabled = true;//запуск таймера
        }

        private void CreateTimer()//инициализация таймера
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;

        }

        void timer_Tick(object sender, EventArgs e)//события за один цикл таймера
        {

            if (SecQuantity <= 0)
            {
                timer.Enabled = false;
                BaBah(this);
                return;
            }
            WriteTimer(--SecQuantity);
        }


        private void WriteTimer(int nom)//прорисовка отсчёта таймера бомбы
        {
            mapPic[bombPlace.X, bombPlace.Y].Image = Properties.Resources.bomb;
            mapPic[bombPlace.X, bombPlace.Y].Refresh();
            using (Graphics gr=mapPic[bombPlace.X,bombPlace.Y].CreateGraphics())
            {

                PointF point = new PointF(
                    (mapPic[bombPlace.X,bombPlace.Y].Size.Width)/3,
                    (mapPic[bombPlace.X,bombPlace.Y].Size.Height)/3
                    );

                gr.DrawString(
                    nom.ToString(),
                    new Font("Microsoft Sans Serif",10),
                    Brushes.White,
                    point
                    );
            }
        }

        public void Detonation()
        {
            SecQuantity = 0;
        }

        
    }
}
