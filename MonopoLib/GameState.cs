using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MonopoLib
{
    public static class GameState
    {
        public static List<Card> Cards = new List<Card>();

        public static int GetRandomNumber()
        {
            var rnd = new Random();
            return rnd.Next(1, 6);
        }

        static void FillCards()
        {
            if (Cards.Count == 40)
                return;
         
            var f = new FileStream("cards.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            float rent, price;
            int color;
            string name, line;
            string[] buf;
            while(f.CanSeek)
            {
                StreamReader streamReader = new StreamReader(f);
                line = streamReader.ReadLine();
                buf = line.Split(' ');

                name = buf[0];
                price = float.Parse(buf[1]);
                rent = float.Parse(buf[2]);
                color = int.Parse(buf[3]);


                Cards.Add(new Card(name, price, rent, color));
            }
            f.Close();
        }

        static void GameLoop()
        {
            /* Get Players from NET */
            

        }

    }
}