
using System.Collections.Generic;
using System;
namespace BoombermanGame
{ 
    public enum Prizes
        {
            пусто,
            бомба_плюс,
            бомба_минус,
            огонь_плюс,
            огонь_минус,
            бег_плюс,
            бег_минус
        }

    public static class BonusClass
    {
       

        static Dictionary<Prizes, int> percent;
        public static List<Prizes> listBonus;   
        static Random rand=new Random();
        static int BonusCount = 7;
  
        public static void Prepare()
        {
            PreparePercent();
            PrepareBonus();
        }
        private static void PreparePercent()
        {
            percent = new Dictionary<Prizes, int>();
            percent.Add(Prizes.бомба_плюс, 90);
            percent.Add(Prizes.бомба_минус, 30);
            percent.Add(Prizes.огонь_плюс, 60);
            percent.Add(Prizes.огонь_минус, 20);
            percent.Add(Prizes.бег_плюс, 60);
            percent.Add(Prizes.бег_минус, 20);
            
        }

        private static void PrepareBonus()
        {
            listBonus = new List<Prizes>();
            int sum = 0;
            foreach (int item in percent.Values)
            {
                sum += item;
            }
            do
            {
                int BonusNum = rand.Next(0, sum);
                int tBonus = 0;
                foreach (Prizes prize in percent.Keys)
                {
                    tBonus += percent[prize];
                    if (BonusNum < tBonus)
                    {
                        listBonus.Add(prize);
                        break;
                    }
                }
            } while (listBonus.Count<BonusCount);
        }
        public static Prizes GetBonus()
        {
            if (listBonus.Count == 0) return Prizes.пусто;
            Prizes prize = listBonus[0];
            listBonus.Remove(prize);
            return prize;
        }
    }
}
