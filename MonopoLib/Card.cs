namespace MonopoLib
{
    public class Card
    {
        private float Rent { get; }
        private float Price { get; }
        private Player Owner { get; set; } = null;
        private int Color { get; }
        private string Name { get; }
        private int MAX_LOCATIONS = 40;

        public Card(string sName, float sPrice, float sRent, int sColor)
        {
            name = sName;
            price = sPrice;
            rent = sRent;
            color = sColor;
            owner = null;
        }

        bool IsSpecial()
        {
            return color > 10;
        }
        
    }
}