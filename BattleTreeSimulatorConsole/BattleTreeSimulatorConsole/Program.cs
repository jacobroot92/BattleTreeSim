using BattleTreeSimulatorConsole.PokemonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var endInput = "";
            Random random = new Random();
            Pokemon pkmn1 = new Pokemon("Pikachu", 500, 50, 200);
            Pokemon pkmn2 = new Pokemon("Typhlosion", 500, 500, 200);
            while (pkmn1.RemainingHP > 0 && pkmn2.RemainingHP > 0)
            {
                var attackDamage = pkmn1.DoDamage(80);
                pkmn2.TakeDamage(attackDamage, GetRandomNumber(0.85, 1.0, random));
                Console.WriteLine(pkmn2.Name + " has " + pkmn2.RemainingHP + " HP remaining!");

                var attackDamage2 = pkmn2.DoDamage(80);
                pkmn1.TakeDamage(attackDamage2, GetRandomNumber(0.85, 1.0, random));
                Console.WriteLine(pkmn1.Name + " has " + pkmn1.RemainingHP + " HP remaining!");

                endInput = Console.ReadLine();
            }

            if (pkmn1.RemainingHP > 0)
                Console.WriteLine(pkmn1.Name + " Wins!");
            else
                Console.WriteLine(pkmn2.Name + " Wins!");
            endInput = Console.ReadLine();
        }

        static public double GetRandomNumber(double minimum, double maximum, Random random)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
