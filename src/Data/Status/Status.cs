using PokeDojo.src.Poke;

namespace PokeDojo.src.Data.Statuses
{
  //modify to account for generation differences
  public class Status
  {
    readonly string status;
    readonly string description;
    readonly Action<Pokemon> applyStatus;

    public Status(string status, string description, Action<Pokemon> onPokemon)
    {
      this.status = status;
      this.description = description;
      this.applyStatus = onPokemon;
    }

    public void ApplyStatus(Pokemon self)
    {
      if(applyStatus != null)
      {
        applyStatus.Invoke(self);
      }
    }

    public string GetStatus()
    {
      return status;
    }

    public string GetDescription()
    {
      return description;
    }
  }
}
