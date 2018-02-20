using System;

namespace MonopoLib
{
    public class Player
    {
        private float Money { get; }
        private int CurrentLocation { get; }
        private string Name { get; }
        private int START_MONEY = 3000;
        private int DaysInJail { get; }


        public Player(string n)
        {
            Name = n;
            Money = START_MONEY;
            CurrentLocation = 0;
            DaysInJail = -1;
        }

        int ThrowDice()
        {
            return GameState.GetRandomNumber();
        }

        void AdvancePosition(int dice)
        {
            currentLocation += dice;
            currentLocation %= 40;
        }

        void AddMoney(float value)
        {
            money += value;
        }

        void TransferMoney(Player p, float pay)
        {
            p.AddMoney(pay);
            AddMoney(pay * -1);
        }

        void Move()
        {
            AdvancePosition( ThrowDice() );
        }

        bool HasLost()
        {
            return money <= 0;
        }

        bool IsInJail()
        {
            return daysInJail >= 0;
        }
    }
}