namespace MonopoLib
{
    public class Card
    {
        private float Rent;
        public float GetRent()
        {
            return Rent;
        }

        private float Price;
        public float GetPrice()
        {
            return Price;
        }

        private Player Owner;
        public Player GetOwner()
        {
            return Owner;
        }
        public void SetOwner(Player value)
        {
            Owner = value;
        }

        private int Color;
        public int GetColor()
        {
            return Color;
        }

        private string Name;
        public string GetName()
        {
            return Name;
        }

        private int MAX_LOCATIONS = 40;

        public Card(string sName, float sPrice, float sRent, int sColor)
        {
            Name = sName;
            Price = sPrice;
            Rent = sRent;
            Color = sColor;
            Owner = null;
        }

        public bool IsSpecial()
        {
            return Color > 10;
        }
        
    }
}