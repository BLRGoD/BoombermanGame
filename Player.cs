using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace BoombermanGame
{
    public delegate void deAddBonus(Prizes p);

    enum Arrows
    { 
    left,
    right,
    up,
    down
    }


    class Player
    {
        public PictureBox player { get; private set; }
     // PictureBox[,] mapPic ;
     // Sost[,] map;
        public static int step { get; private set; } //шаг передвижения
        MovingClass moving;
        public List<Bomb> bombs { get; private set; }
        int BombQuantity;//переменная количества бомб
        public int FireLength { get; private set; }//переменная длины огня
        Label Score;


        public Player(PictureBox _player, PictureBox[,] _mapPic,Sost[,] _map, Label lbScore)//конструктор класса
        {
            player = _player;
            Score = lbScore;
         // mapPic = _mapPic;
         // map = _map;
            step = 3;
            BombQuantity = 3;
            FireLength = 3;
            bombs = new List<Bomb>();
            moving = new MovingClass(_player, _mapPic, _map, AddBonus);
            ChangeScore();
        }


        public void MovePlayer(Arrows arrow)//передвижение взависимости от полученных зажатых клавиш
        {
            switch (arrow)
            {
                case Arrows.left:
                   player.Image = Properties.Resources.PlayerLeft;
                   moving.Move(-step, 0);                 
                    break;
                case Arrows.right:
                    player.Image = Properties.Resources.playerRight;
                    moving.Move(step, 0);
                    break;
                case Arrows.up:
                    player.Image = Properties.Resources.playerUp;                   
                    moving.Move(0, -step);
                    break;
                case Arrows.down:
                    player.Image = Properties.Resources.playerDown;
                    moving.Move(0, step);
                    break;
                default:
                    break;
            }
        }

        public Point CurrentPoint()
        {
            return moving.CurrentPoint();
        }

        public bool CanPutBomb(PictureBox[,] mapPic, deBaBah _BaBah)//проверка на возможность установки бомбы
        {
            if (bombs.Count >= BombQuantity) return false;
          //  player.Image = Properties.Resources.playerDown;
            Bomb bomb = new Bomb(mapPic,CurrentPoint(),_BaBah);
            bombs.Add(bomb);
            return true;
        }

        public void RemoveBomb(Bomb bomb)
        {
            bombs.Remove(bomb);
        }

        public void RemovePlayer()
        {
            player.Visible = false;
        }

        private void ChangeScore(string alarm="")//статистика сверху экрана
        {
            if (Score == null) return;
            Score.Text="скорость: "+step+"     доступное кол-во бомб: "+BombQuantity+"      сила бомб: "+FireLength+"  "+alarm;
        }

        private void AddBonus(Prizes prize) 
        {
            switch (prize)
            {
              
                case Prizes.бомба_плюс:
                    BombQuantity++;
                    ChangeScore("   +1 бомба");
                    break;

                case Prizes.бомба_минус:
                    if (BombQuantity == 1) BombQuantity = 1; else BombQuantity--;
                    ChangeScore("   -1 бомба");
                  
                    break;
                case Prizes.огонь_плюс:
                    FireLength++;
                    ChangeScore("   +1 к мощности взрыва");                    
                    break;

                case Prizes.огонь_минус:
                    if (FireLength == 1) FireLength = 1; else FireLength--;
                    ChangeScore("   -1 к мощности взрыва");
                    break;

                case Prizes.бег_плюс:
                    step++;
                    ChangeScore("   +1 к скорости");                  
                    break;

                case Prizes.бег_минус:
                    if (step <= 3) step = 3; else step--;
                    ChangeScore("   -1 к скорости");                    
                    break;

                default:
                    break;
            }
           
        }
    }
}
