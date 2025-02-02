namespace PokeDojo.src.Data.Stats
{
    // Represents one of the possible natures in the game
    public class Nature(string name, string increase, string decrease)
    {
        public string Name { get; set; } = name;
        public string Increase { get; set; } = increase;
        public string Decrease { get; set; } = decrease;
    }
}
