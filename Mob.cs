using System.Windows.Forms;
using System.Drawing;
using System;

namespace BoombermanGame
{
    class Mob
    {
        /// <summary>
        /// Уровни сложности:
        /// 1. Лёгкий - выбирает доступную точку и бежит к ней
        /// 2. Средний - выбирает доступную точку и бежит к ней, если видит бомбу или огонь - убегает
        /// 3. Сложный - бегает от точке к точке, если доступен человек, бежит к нему, если встретит бомбу или огонь - убегает
        /// </summary>
        int Difficulty = 1 ;

        public PictureBox mob { get; private set; }
        Timer timer;
        Point destinePlace;
        Point mobPlace;
        MovingClass moving;
        int step = 3;//шаг 
        Sost[,] map;
        int[,] fmap;//карта поиска пути
        int paths;
        Point[] path;
        int pathStep;
        static Random rand = new Random();
        Player player;

        public Mob(PictureBox picMob,PictureBox[,] _mapPic, Sost[,] _map, Player _player)
        {
            player = _player;
            mob = picMob;
            map = _map;
            fmap = new int[map.GetLength(0), map.GetLength(1)];
            path = new Point[map.GetLength(0)*map.GetLength(1)];
            moving = new MovingClass(picMob, _mapPic,_map);
            mobPlace = moving.CurrentPoint();
            destinePlace = mobPlace;//Точка назначения
            CreateTimer();
            timer.Enabled = true;
            
        }


        private void CreateTimer()
        {
            timer = new Timer();
           timer.Interval = 10;//интервал таймера
           timer.Tick += timer_Tick;
           

        }

        void timer_Tick(object sender, System.EventArgs e)//события за один тик таймера
        {
            if (mobPlace == destinePlace) GetNewPlace();
            if (path[0].X == 0 && path[0].Y == 0)
                if (!FindPath()) return;
            if (pathStep > paths) return;
            if(path[pathStep]==mobPlace)
            pathStep++;
            else
            MoveMob(path[pathStep]);
        }

        private void MoveMob(Point newPlace)//передвижение
        {
            int sx = 0, sy = 0;
            if (mobPlace.X < newPlace.X)
                sx = newPlace.X - mobPlace.X > step ? step : newPlace.X - mobPlace.X;//если больше step, = step, если нет, = newPlace.X - mobPlace.X
            else
                sx = mobPlace.X - newPlace.X < step ? newPlace.X - mobPlace.X : -step;
            if (mobPlace.Y < newPlace.Y)
                sy = newPlace.Y - mobPlace.Y > step ? step : newPlace.Y - mobPlace.Y;
            else
                sy = mobPlace.Y - newPlace.Y < step ? newPlace.Y - mobPlace.Y : -step;
            moving.Move(sx, sy);

            mobPlace = moving.CurrentPoint();

            if (Difficulty >= 2 && 
                map[newPlace.X, newPlace.Y]==Sost.огонь ||
                map[newPlace.X, newPlace.Y] == Sost.бомба
                ) //проработка сложности 2+ уровня
            {
                GetNewPlace();
            }
        }


        private bool FindPath()//поиск кратчайшего пути до destinePoint(целевой точки) 
        {
            for (int x = 0; x < map.GetLength(0); x++)//заполнение массива для поиска нулями
                for (int y = 0; y < map.GetLength(1); y++)
                    fmap[x, y] = 0;
            bool added;
            bool found = false;
            fmap[mobPlace.X, mobPlace.Y] = 1;
            int nr = 1;//для нумерации клеток в массиве fmap 
            do
            {
                added = false;

                for (int x = 0; x < map.GetLength(0); x++)
                  for (int y = 0; y < map.GetLength(1); y++)
                      if (fmap[x, y] == nr)
                      {
                          MarkPath(x + 1, y, nr+1);
                          MarkPath(x - 1, y, nr + 1);
                          MarkPath(x, y - 1, nr + 1);
                          MarkPath(x, y + 1, nr + 1);
                          added = true;
                      }

                if (fmap[destinePlace.X, destinePlace.Y] > 0)//при нумерации клетки destinePlace отправить, что путь найден
                {
                    found = true;
                    break;
                }
                nr++;
            } while (added);

            if (!found) return false;
            int sx = destinePlace.X, sy = destinePlace.Y;
            paths = nr;
            while (nr>=0)
            {
                path[nr].X = sx;
                path[nr].Y = sy;
                if (IsPath(sx + 1, sy, nr)) sx++;
                else if (IsPath(sx - 1, sy, nr)) sx--;
                else if (IsPath(sx, sy + 1, nr)) sy++;
                else if (IsPath(sx, sy - 1, nr)) sy--;
                nr--;

            }
            pathStep = 0;
            return true;

        }

        private void MarkPath(int x,int y,int n)//маркировка клетки кратчайшего пути
        {
            if (x < 0 || x >= map.GetLength(0)) return;////проверка на выход 
            if (y < 0 || y >= map.GetLength(1)) return;////за границы карты
            if (fmap[x, y] > 0) return;//проверка, если клетка уже отмечена
            if (map[x, y] != Sost.пусто) return;//проверка на занятость клетки блоком
            fmap[x, y] = n;//нумерация клетки в массиве fmap
        }

        private bool IsPath(int x, int y, int n)//проверка на корректность пути
        {
            if (x < 0 || x >= map.GetLength(0)) return false;
            if (y < 0 || y >= map.GetLength(1)) return false;
            return fmap[x,y]==n;
        }

        private void GetNewPlace()
        {
            if (Difficulty >= 3 && player.player.Visible==true)
            {
                destinePlace = player.CurrentPoint();
                if (FindPath()) return;
            }

            int loop = 0;
            do
            {
                destinePlace.X = rand.Next(1, map.GetLength(0) - 1);
                destinePlace.Y = rand.Next(1, map.GetLength(1) - 1);

            } while (!FindPath() && loop++<200);
            if (loop >= 200)
                destinePlace = mobPlace;
        }

        public Point CurrentPoint()
        {
            return moving.CurrentPoint();
        }

        public void SetDifficulty(int _diff)
        {
            Difficulty = _diff;
        }
    }
}
