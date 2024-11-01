using PokeDojo.src.Generation;
using PokeDojo.src.Type;

using System;

namespace PokeDojoTests.test
{
    [TestClass]
    public class GenerationTests
    {
        [TestMethod]
        public void GivenValidGeneration_WhenCreatingGenerationInfo_ThenReturnGeneration()
        {
          // Arrange
          int generation = 1;
          GenerationInfo FirstGenPokemon = new GenerationInfo();
          
          // Act
          FirstGenPokemon.SetGeneration(generation);

          // Assert
          int actualGeneration = FirstGenPokemon.GetGeneration();
          Assert.AreEqual(generation, actualGeneration);
        }

        [TestMethod]
        public void GivenValidName_WhenCreatingGenerationInfo_ThenReturnName()
        {
          // Arrange
          string name = "Pikachu";
          GenerationInfo PikachuInfo = new GenerationInfo();

          // Act
          PikachuInfo.GetDescription().SetName(name);

          // Assert
          string actualName = PikachuInfo.GetDescription().GetName();
          Assert.AreEqual(name, actualName);
        }

        [TestMethod]
        public void GivenValidLevel_WhenCreatingGenerationInfo_ThenReturnLevel()
        {
          // Arrange
          int level = 50;
          GenerationInfo PikachuInfo = new GenerationInfo();

          // Act
          PikachuInfo.GetDescription().SetLevel(level);

          // Assert
          int actualLevel = PikachuInfo.GetDescription().GetLevel();
          Assert.AreEqual(level, actualLevel);
        }

        [TestMethod]
        public void GivenValidGender_WhenCreatingGenerationInfo_ThenReturnGender()
        {
          // Arrange
          string gender = "Female";
          GenerationInfo PikachuInfo = new GenerationInfo();

          // Act
          PikachuInfo.GetGender().SetGender(gender);

          // Assert
          string actualGender = PikachuInfo.GetGender().GetGender();
          Assert.AreEqual(gender, actualGender);
        }

        [TestMethod]
        public void GivenValidHappiness_WhenCreatingGenerationInfo_ThenReturnHappiness()
        {
          // Arrange
          int happiness = 255;
          GenerationInfo PikachuInfo = new GenerationInfo();

          // Act
          PikachuInfo.SetHappiness(happiness);

          // Assert
          int actualHappiness = PikachuInfo.GetHappiness();
          Assert.AreEqual(happiness, actualHappiness);
        }

       [TestMethod]
       public void GivenValidHiddenPower_WhenCreatingGenerationInfo_ThenReturnHiddenPower()
        {
          PokemonType type = new PokemonType("Normal");
          GenerationInfo PikachuInfo = new GenerationInfo();
          
          // Act
          PikachuInfo.SetHiddenPower(type);

          // Assert
          PokemonType actualType = PikachuInfo.GetHiddenPower();
          Assert.AreEqual(type, actualType);
        }
    }
}