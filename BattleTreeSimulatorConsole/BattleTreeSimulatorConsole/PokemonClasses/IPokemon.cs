using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public interface IPokemon
    {
        string Name { get; set; }
        Type Type1 { get; set; }
        Type Type2 { get; set; }
        int RemainingHP { get; set; }
        int MaxHP { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int SpecialAttack { get; set; }
        int SpecialDefense { get; set; }
        int Speed { get; set; }
        Item HeldItem { get; set; }
        bool CanEvolve { get; set; }

        int DoDamage(int power, bool physical, double random, double modifier);

        void TakeDamage(int damageBase, bool physical);
    }
}
