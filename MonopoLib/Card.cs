namespace MonopoLib
{
    public class Card
    {
        private float rent;
        private float price;
        private Player owner = null;
        private int color;
        private string name;
        private int MAX_LOCATIONS = 40;

        public Card(string sName, float sPrice, float sRent, int sColor)
        {
            name = sName;
            price = sPrice;
            rent = sRent;
            color = sColor;
            owner = null;
        }

        string getName()
        {
            return name;
        }

        float getRent()
        {
            return rent;
        }

        Player getOwner()
        {
            return owner;
        }

        float getPrice()
        {
            return price;
        }

        int getColor()
        {
            return color;
        }

        bool isSpecial()
        {
            return color > 10;
        }
        
    }
}