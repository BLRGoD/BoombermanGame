using System.Windows.Forms;
using System.Drawing;

namespace BoombermanGame
{
    class MovingClass
    {
        PictureBox Object;
        PictureBox[,] mapPic;
        Sost[,] map;


        public MovingClass(PictureBox item,PictureBox[,] _mapPic, Sost[,] _map)
        {
            Object = item;
            mapPic = _mapPic;
            map = _map;
        }
        
        public void Move(int sx, int sy)//метод для передвижения в опр. направлении
        {
            if (isEmpty(ref sx, ref sy))
                Object.Location = new Point(Object.Location.X + sx, Object.Location.Y + sy);
        }

        private bool isEmpty(ref int sx, ref int sy)//проверка соседних клеток на наличие препятствия
        {

            Point playerPoint = CurrentPoint();


            int playerRight = Object.Location.X + Object.Size.Width;
            int playerLeft = Object.Location.X;
            int playerDown = Object.Location.Y + Object.Size.Height;
            int playerUp = Object.Location.Y;

            int rightWallLeft = mapPic[playerPoint.X, playerPoint.Y].Location.X;
            int leftWallRight = mapPic[playerPoint.X - 1, playerPoint.Y].Location.X + mapPic[playerPoint.X - 1, playerPoint.Y].Size.Width;
            int downWallUp = mapPic[playerPoint.X, playerPoint.Y + 1].Location.Y;
            int upWallDown = mapPic[playerPoint.X, playerPoint.Y - 1].Location.Y + mapPic[playerPoint.X, playerPoint.Y - 1].Size.Height;

            int rightUpWallDown = mapPic[playerPoint.X + 1, playerPoint.Y - 1].Location.Y + mapPic[playerPoint.X + 1, playerPoint.Y - 1].Size.Height;
            int rightDownWallUp = mapPic[playerPoint.X + 1, playerPoint.Y + 1].Location.Y;
            int leftUpWallDown = mapPic[playerPoint.X - 1, playerPoint.Y - 1].Location.Y + mapPic[playerPoint.X - 1, playerPoint.Y - 1].Size.Height;
            int leftDownWallUp = mapPic[playerPoint.X - 1, playerPoint.Y + 1].Location.Y;

            int rightUpWallLeft = mapPic[playerPoint.X + 1, playerPoint.Y - 1].Location.X;
            int leftUpWallRight = mapPic[playerPoint.X - 1, playerPoint.Y - 1].Location.X + mapPic[playerPoint.X - 1, playerPoint.Y - 1].Size.Width;
            int rightDownWallLeft = mapPic[playerPoint.X + 1, playerPoint.Y + 1].Location.X;
            int leftDownWallRight = mapPic[playerPoint.X - 1, playerPoint.Y + 1].Location.X + mapPic[playerPoint.X - 1, playerPoint.Y + 1].Size.Width;

            int offset = 3;
            if (sx > 0 && (map[playerPoint.X + 1, playerPoint.Y] == Sost.пусто || map[playerPoint.X + 1, playerPoint.Y] == Sost.огонь))
            {
                if (playerUp < rightUpWallDown)
                    if (rightUpWallDown - playerUp > offset)
                        sy = offset;
                    else
                        sy = rightUpWallDown - playerUp;
                if (playerDown > rightDownWallUp)
                    if (rightDownWallUp - playerDown < -offset)
                        sy = -offset;
                    else
                        sy = rightDownWallUp - playerDown;
                return true;
            }
            if (sx < 0 && (map[playerPoint.X - 1, playerPoint.Y] == Sost.пусто || map[playerPoint.X - 1, playerPoint.Y] == Sost.огонь))
            {
                if (playerUp < leftUpWallDown)
                    if (leftUpWallDown - playerUp > offset)
                        sy = offset;
                    else
                        sy = leftUpWallDown - playerUp;
                if (playerDown > leftDownWallUp)
                    if (leftDownWallUp - playerDown < -offset)
                        sy = -offset;
                    else
                        sy = leftDownWallUp - playerDown;
                return true;
            }
            if (sy > 0 && (map[playerPoint.X, playerPoint.Y + 1] == Sost.пусто ||  map[playerPoint.X, playerPoint.Y + 1] == Sost.огонь))
            {
                if (playerRight > rightDownWallLeft)
                    if (rightDownWallLeft - playerRight < -offset)
                        sx = -offset;
                    else
                        sx = rightDownWallLeft - playerRight;
                if (playerLeft < leftDownWallRight)
                    if (leftDownWallRight - playerLeft > offset)
                        sx = offset;
                    else
                        sx = leftDownWallRight - playerLeft;
                return true;
            }
            if (sy < 0 && (map[playerPoint.X, playerPoint.Y - 1] == Sost.пусто || map[playerPoint.X, playerPoint.Y - 1] == Sost.огонь))
            {
                if (playerRight > rightUpWallLeft)
                    if (rightUpWallLeft - playerRight < -offset)
                        sx = -offset;
                    else
                        sx = rightUpWallLeft - playerRight;
                if (playerLeft < leftUpWallRight)
                    if (leftUpWallRight - playerLeft > offset)
                        sx = offset;
                    else
                        sx = leftUpWallRight - playerLeft;
                return true;
            }

            if (sx > 0 && playerRight + sx > rightWallLeft + 40)///////////FIX
                sx = rightWallLeft - playerLeft + 4;///////////////////////FIX
            if (sx < 0 && playerLeft + sx < leftWallRight)
                sx = leftWallRight - playerLeft;
            if (sy > 0 && playerDown + sy > downWallUp)
                sy = downWallUp - playerDown;
            if (sy < 0 && playerUp + sy < upWallDown)
                sy = upWallDown - playerUp;

            return true;
        }


        public Point CurrentPoint()//метод для возврата текущей позиции
        {
            Point point = new Point();
            {
                point.X = Object.Location.X + Object.Size.Width / 2;/////определение центра юнита,
                point.Y = Object.Location.Y + Object.Size.Height / 2;// в котором находится персонаж
            }
            for (int x = 0; x < mapPic.GetLength(0); x++)
                for (int y = 0; y < mapPic.GetLength(1); y++)
                {
                    if (mapPic[x, y].Location.X < point.X &&////////////////////////////проверка точки 
                        mapPic[x, y].Location.Y < point.Y &&////////////////////////////на нахождение в юните
                        mapPic[x, y].Location.X + mapPic[x, y].Size.Width > point.X &&// с вершинами данного
                        mapPic[x, y].Location.Y + mapPic[x, y].Size.Height > point.Y)///юнита
                        return new Point(x, y);//возврат такой точки при обнаружении 
                }

            return point;
        }

    }
}
