using System;

namespace MonopoLib
{
    public class Player
    {
        public override bool Equals(object obj)
        {
            if (obj is Player)
                return (obj as Player == this);
            return false;
        }


        private float Money;
        public float GetMoney() {
            return Money;
        }

        private int CurrentLocation;
        public int GetCurrentLocation()
        {
            return CurrentLocation;
        }
        public void SetCurrentLocation(int value)
        {
            CurrentLocation = value;
        }

        private string Name;
        public string GetName()
        {
            return Name;
        }
        
        private int DaysInJail;
        public int GetDaysInJail()
        {
            return DaysInJail;
        }

        private float ColorModifier(int colr)
        {
            int i;
            float SameColorOwned = 0;
            for(i = 0; i < 40; i++)
            {
                if (GameState.Cards[i].GetOwner().Equals(this) && GameState.Cards[i].GetColor() == colr)
                {
                    SameColorOwned++;
                }
            }
            float modifier = SameColorOwned / 3;
            return modifier + 1;
        }
        public float GetColorModifier(int colr)
        {
            return ColorModifier(colr);
        }

        private int START_MONEY = 3000;


        public Player(string n)
        {
            Name = n;
            Money = START_MONEY;
            CurrentLocation = 0;
            DaysInJail = -1;  // Not in jail
        }

        int ThrowDice()
        {
            return GameState.GetRandomNumber();
        }

        void AdvancePosition(int dice)
        {
            CurrentLocation += dice;
            CurrentLocation %= 40;
        }

        void AddMoney(float value)
        {
            Money += value;
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
            return Money <= 0;
        }

        bool IsInJail()
        {
            return DaysInJail >= 0;
        }

        void PlayerTurn()
        {
            if (HasLost())
                return;

            if (IsInJail())
            {
                DaysInJail++;
                if (DaysInJail > 1)
                    DaysInJail = -1;
            }
            else
            {
                Move();
                Card Current = GameState.Cards[CurrentLocation];
                if ( Current.IsSpecial() )
                {
                    switch ( Current.GetColor() )
                    {
                        case 11:    // Jail           
                            break;
                        case 12:    // "Go to Jail"                           
                            break;
                        case 13:    // Start                            
                            break;
                        case 14:    // Edu, pon tú cosas aquí que yo no sé qué más hay en el Monopoly
                            break;

                    }
                }

                else
                {
                    if (Current.GetOwner().Equals(this))
                    {
                        // do stuff to auction place ( maybe ?)
                    }

                    else if (Current.GetOwner() != null)
                    {
                        TransferMoney(Current.GetOwner(), Current.GetRent() * Current.GetOwner().GetColorModifier(Current.GetColor()));
                    }                 

                    else
                    {
                        //do stuff to buy place
                    }
                }
            }

        }
    }
}