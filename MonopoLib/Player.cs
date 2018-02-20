using System;

namespace MonopoLib
{
    public class Player
    {
        private float money;
        private int currentLocation;
        private string name;
        private int START_MONEY = 3000;
        private int daysInJail;


        public Player(string n)
        {
            name = name;
            money = START_MONEY;
            currentLocation = 0;
            daysInJail = 0;
        }

        float getMoney()
        {
            return money;
        }

        int getCurrentLocation()
        {
            return currentLocation;
        }

        int throwDice()
        {
            return GameState.getRandomNumber();
        }

        string getName()
        {
            return name;
        }

        void advancePosition(int dice)
        {
            currentLocation += dice;
            currentLocation %= 40;
        }

        void addMoney(float value)
        {
            money += value;
        }

        void transferMoney(Player p, float pay)
        {
            p.addMoney(pay);
            addMoney(pay * -1);
        }

        void move()
        {
            advancePosition(throwDice());
        }
    }
}