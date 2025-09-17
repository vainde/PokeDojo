using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeDojo.src.Simulator.Team;
using System.Text.Json;

namespace PokeDojo.src.Simulator.User
{
  internal class Player
  {
    public string Name { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }

    public List<Party> Teams;

    public List<int> PlayerStats;

    public string saveFile { get; set; }

    public Player() {
      Name = "";
      GamesPlayed = 0;
      Wins = 0;
      Losses = 0;
      Teams = new();
      PlayerStats = [];
      saveFile = "";
    }

    public void ChangeName(string name)
    {
      if (name != "" && name != null)
      {
        Name = name;
      }
      else
      {
        Console.WriteLine("Unable to change your name.");
      }
    }

    public void PlayedGame()
    {
      GamesPlayed += 1;
    }

    public void PlayerWon()
    {
      Wins += 1;
    }

    public void PlayerLost()
    {
      Losses += 1;
    }

    public void DisplayTeams()
    {
      foreach (Party p in Teams)
      {
        Console.WriteLine($"Team: {p.Name}");
        if(p.Team.Count == 0)
        {
          Console.WriteLine("Empty Team!");
        }
        else
        {
          p.DisplayParty();
        }
      }
    }

    public void UpdateTeam(Party party)
    {
      party.UpdateTeam();
    }

    // fix save teams
    public void SaveTeams()
    {
      List<int> playerData = [Wins, Losses, GamesPlayed];
      string jsonPlayerData = JsonSerializer.Serialize(playerData);
      string jsonTeams = JsonSerializer.Serialize(Teams);
      string jsonSaveFile = jsonPlayerData + jsonTeams;
      saveFile = jsonSaveFile;
    }
  }
}
