namespace PokeDojo.src.Data.Stats
{
    // Represents one of the possible natures in the game
    public class Nature
    {
        string name;
        string increase;
        string decrease;

        public Nature(string name, string increase, string decrease)
        {
            this.name = name;
            this.increase = increase;
            this.decrease = decrease;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetIncrease(string increase)
        {
            name = increase;
        }

        public void SetDecrease(string decrease)
        {
            name = decrease;
        }

        public string GetName()
        {
            return name;
        }

        public string GetIncrease()
        {
            return increase;
        }

        public string GetDecrease()
        {
            return decrease;
        }
    }
}
