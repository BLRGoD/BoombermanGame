using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BoombermanGame
{
    public delegate void deBaBah(Bomb bomb);
    
    enum Sost//перечисление состояний
    {
        пусто,
        стена,  
        кирпич,
        бомба,
        огонь,
        приз
    }


    class MainBoard
    {
        Panel panelGame;
        PictureBox[,] mapPic;//массив картинок на юнитах по координатам
        Sost[,] map;//массив состояний на юнитах по координатам
       private int sizeX = 17;//
       private int sizeY = 10;//размеры поля
       static Random rand = new Random();//переменная для случайной генерации кирпичей
       Player player;//экземпляр класса Player
       int MobQuantity = 4;//переменная количества мобов
       List<Mob> mobs;
       deClear needClear;
       Label Score;

       public MainBoard(Panel panel,deClear _clear, Label _Score)//конструктор класса
        {
            Score = _Score;
            panelGame = panel;
            needClear = _clear;
            mobs = new List<Mob>();

            int BoxSize;
            if ((panelGame.Width / sizeX) < (panelGame.Height / sizeY))
                BoxSize = panelGame.Width / sizeX;
            else
                BoxSize = panelGame.Height / sizeY;


            InitStartMap(BoxSize);
            InitStartPlayer(BoxSize);
            for (int i = 0; i < MobQuantity; i++)//спавн мобов
            {
                InitMob(BoxSize);
            }
        }

        private void InitStartMap(int BoxSize)//инициализация карты
        {
            mapPic = new PictureBox[sizeX, sizeY];//массив картинок на юнитах по координатам
            map = new Sost[sizeX, sizeY];//массив состояний на юнитах по координатам
          panelGame.Controls.Clear();//очистка панели



          for (int x = 0; x < sizeX; x++)//заполнение карты
              for (int y = 0; y < sizeY; y++)
              {
                  if (x == 0 || y == 0 || x==(sizeX-1) || y==(sizeY-1))//стены по краям карты
                      CreatePlace(new Point(x, y), BoxSize, Sost.стена);

                  else if (x % 2 == 0 && y % 2 == 0) //стены через один блок
                  {
                      CreatePlace(new Point(x,y),BoxSize,Sost.стена); 
                  }
                  else if(rand.Next(3)==0)//в 1 случае из 3х создаёт кирпич
                  {
                      CreatePlace(new Point(x, y), BoxSize, Sost.кирпич);
                  }
                  else
                      CreatePlace(new Point(x, y), BoxSize, Sost.пусто);//заполнение землёй
              }
          ChangeSost(new Point(1, 1), Sost.пусто);/////////////////
          ChangeSost(new Point(1, 2), Sost.пусто);/////////////////
          ChangeSost(new Point(2, 1), Sost.пусто);/////////////////проработка исключений для спавна
          //ChangeSost(new Point(sizeX-2, 1), Sost.пусто);///////////
          //ChangeSost(new Point(sizeX - 3, 1), Sost.пусто);///////////
          //ChangeSost(new Point(sizeX - 2, 2), Sost.пусто);///////////
          //ChangeSost(new Point(sizeX-2, sizeY-2), Sost.пусто);/////
          //ChangeSost(new Point(sizeX - 3, sizeY - 2), Sost.пусто);/////  
          //ChangeSost(new Point(sizeX - 2, sizeY - 3), Sost.пусто);/////
        }
       
        private void CreatePlace(Point point, int boxsize, Sost sost)//создание полноценного юнита с состоянием и картинкой
        {
            PictureBox picture = new PictureBox();
            picture.Location = new Point(point.X*(boxsize-1),point.Y*(boxsize-1));
            picture.Size = new Size(boxsize, boxsize);//подгон картинки по размерам юнита
             picture.BorderStyle = BorderStyle.FixedSingle;//сетка
            picture.SizeMode = PictureBoxSizeMode.StretchImage;//растягивание картинки по размерам юнита
            mapPic[point.X, point.Y] = picture;
            ChangeSost(point, sost);
            panelGame.Controls.Add(picture);
        }
        
        private void ChangeSost(Point point, Sost newSost)//смена состояния на переданное
        {
            switch (newSost)
            {
                case Sost.стена:
                    mapPic[point.X, point.Y].Image = Properties.Resources.wall1_2;
                    break;
                case Sost.кирпич:
                    mapPic[point.X, point.Y].Image = Properties.Resources.brick1_2;
                    break;
                case Sost.бомба:
                    mapPic[point.X, point.Y].Image = Properties.Resources.bomb;
                    mapPic[point.X, point.Y].BackgroundImage = Properties.Resources.ground;
                    break;
                case Sost.огонь:
                    mapPic[point.X, point.Y].Image = Properties.Resources.Fire;
                    mapPic[point.X, point.Y].BackgroundImage = Properties.Resources.ground;
                    break;
                case Sost.приз:
                    mapPic[point.X, point.Y].Image = Properties.Resources.Prize;
                    break;
                default:
                    mapPic[point.X, point.Y].Image = Properties.Resources.ground;
                    break;
            }
            map[point.X, point.Y] = newSost;//присваивание юниту в массиве состояния
        }
       
        private void InitStartPlayer(int BoxSize)//инициализация игрока
        {
            int x = 1; int y = 1;//координаты спавна
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (BoxSize), y * (BoxSize)+2);//расположение спавна персонажа
            picture.Size = new Size(BoxSize-8, BoxSize-3);//размер персонажа относительно размера юнита
            picture.Image = Properties.Resources.Player;
            picture.BackgroundImage = Properties.Resources.ground;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            panelGame.Controls.Add(picture);
            picture.BringToFront();
            player = new Player(picture, mapPic, map, Score);
        }

        private void InitMob(int BoxSize)//инициализация моба
        {
            int x = 15; int y = 8;//координаты спавна
            FindEmptyPlace(out x, out y);
            PictureBox picture = new PictureBox();
            picture.Location = new Point(x * (BoxSize)-12, y * (BoxSize)-4);//расположение спавна персонажа
            picture.Size = new Size(BoxSize-8, BoxSize-5);//размер персонажа относительно размера юнита
            picture.Image = Properties.Resources.mob;
            picture.BackgroundImage = Properties.Resources.ground;
            picture.BackgroundImageLayout = ImageLayout.Stretch;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            panelGame.Controls.Add(picture);
            picture.BringToFront();

            mobs.Add(new Mob(picture, mapPic, map,player));
        }

        private void FindEmptyPlace(out int x,out int y)//поиск пустой клетки для спавна
        {
            int loop = 0;
            do
            {
                x = rand.Next(map.GetLength(0)/2+1, map.GetLength(0));
                y = rand.Next(1, map.GetLength(1));
                
            } while (map[x,y]!=Sost.пусто && loop++<100);
        }


        public void MovePlayer(Arrows arrow)//передача в класс Player зажатых клавиш
        {
            if (player == null) return;
            player.MovePlayer(arrow);
        }

        public void PutBomb()
        {
            Point playerPoint = player.CurrentPoint();
            if (map[playerPoint.X, playerPoint.Y] == Sost.бомба) return;
            if(player.CanPutBomb(mapPic,BaBah))
            ChangeSost(player.CurrentPoint(),Sost.бомба);
        }

        private void BaBah(Bomb bomb)//взрыв
        {
            ChangeSost(bomb.bombPlace, Sost.огонь);
            Flame(bomb.bombPlace, Arrows.left);
            Flame(bomb.bombPlace, Arrows.right);
            Flame(bomb.bombPlace, Arrows.up);
            Flame(bomb.bombPlace, Arrows.down);
            player.RemoveBomb(bomb);

            Blaze();
            needClear();
        }

        private void Blaze()//уничтожение моба
        {
            List<Mob> DeleteMobs=new List<Mob>();
            foreach (Mob mob in mobs)
            {              
                Point mobPoint = mob.CurrentPoint();
                if (map[mobPoint.X, mobPoint.Y] == Sost.огонь)
                    DeleteMobs.Add(mob);
            }
            for (int x = 0; x < DeleteMobs.Count; x++)
            {
                mobs.Remove(DeleteMobs[x]); 
                panelGame.Controls.Remove(DeleteMobs[x].mob);
                DeleteMobs[x] = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Flame(Point bombPlace, Arrows arrow)//прорисовка огня
        {
            int sx=0, sy=0;
            switch (arrow)
            {
                case Arrows.left:
                    sx = -1;
                    break;
                case Arrows.right:
                    sx = 1;
                    break;
                case Arrows.up:
                    sy = -1;
                    break;
                case Arrows.down:
                    sy = 1;
                    break;
                default:
                    break;
            }

            bool isNotDone = true;
            int x = 0, y = 0;

            do
            {
                x += sx;
                y += sy;
                if (Math.Abs(x) > player.FireLength || Math.Abs(y) > player.FireLength) break;
                if (CanBeFired(bombPlace, x, y))
                    ChangeSost(new Point(bombPlace.X + x, bombPlace.Y + y), Sost.огонь);
                else isNotDone = false;
            } while (isNotDone);
        }

        private bool CanBeFired(Point place, int sx, int sy)//проверка на разрушаемость клетки
        {
            switch (map[place.X+sx,place.Y+sy])
            {
                case Sost.пусто:  return true;                  
                case Sost.стена:  return false;                  
                case Sost.кирпич:
                    ChangeSost(new Point(place.X+sx,place.Y+sy),Sost.огонь);
                    return false;
                case Sost.бомба:
                    foreach (Bomb bomb in player.bombs)
                    {
                        if (bomb.bombPlace == new Point(place.X + sx, place.Y + sy))
                            bomb.Detonation();
                    }
                    return false;
                
                default:
                    return true;
            }
        }
        
        public void clearFire()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == Sost.огонь)
                        ChangeSost(new Point(x, y), Sost.пусто);
                }
            }
        }//очистка огня

        public bool GameOver()//конец игры
        {
            Point myPoint = player.CurrentPoint();
            if (map[myPoint.X, myPoint.Y] == Sost.огонь)
            {
                player.RemovePlayer();
                return true;
            }
            if (mobs.Count == 0)
            {
                player.RemovePlayer();
                return true;
            }
            foreach (Mob mob in mobs)
            {
                if (mob.CurrentPoint() == player.CurrentPoint())
                {
                    player.RemovePlayer();
                    return true;
                }
            }
            return false;
        }

        public void SetMobDifficulty(int _diff)
        {
            foreach (Mob mob in mobs)
            {
                mob.SetDifficulty(_diff);
            }
        }
    }

}
