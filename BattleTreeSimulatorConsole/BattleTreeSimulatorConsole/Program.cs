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
            IPokemon TyphlosionWithoutItem = new Pokemon("Typhlosion", 200, 50, 50, 50, 50, 6);
            IPokemon TyphlosionBeforeSTAB = new ChoiceBand(TyphlosionWithoutItem);
            IPokemon Typhlosion = new STAB(TyphlosionBeforeSTAB);
            IPokemon PikachuWithoutItem = new Pokemon("Pikachu", 200, 50, 50, 50, 50, 5);
            IPokemon Pikachu = new ChoiceScarf(PikachuWithoutItem);
            IPokemon pkmn1;
            IPokemon pkmn2;
            int round = 1;
            
            while (Typhlosion.RemainingHP > 0 && Pikachu.RemainingHP > 0)
            {
                if(Pikachu.Speed > Typhlosion.Speed)
                {
                    pkmn1 = Pikachu;
                    pkmn2 = Typhlosion;
                }
                else if (Pikachu.Speed < Typhlosion.Speed)
                {
                    pkmn1 = Typhlosion;
                    pkmn2 = Pikachu;
                }
                else
                {
                    if(GetRandomNumber(0,1,random) > 0.5)
                    {
                        pkmn1 = Pikachu;
                        pkmn2 = Typhlosion;
                    }
                    else
                    {
                        pkmn1 = Typhlosion;
                        pkmn2 = Pikachu;
                    }
                }
                Console.WriteLine("Round " + round);
                Battle(pkmn1, pkmn2, GetRandomNumber(0.85, 1.0, random), GetRandomNumber(0.85, 1.0, random));
                round++;
            }

            if (Typhlosion.RemainingHP > 0)
                Console.WriteLine(Typhlosion.Name + " Wins!");
            else
                Console.WriteLine(Pikachu.Name + " Wins!");
            endInput = Console.ReadLine();
        }

        static public double GetRandomNumber(double minimum, double maximum, Random random)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        static public void Battle(IPokemon pkmn1, IPokemon pkmn2, double random1, double random2)
        {
                Console.WriteLine(pkmn1.Name + " attacks " + pkmn2.Name);
                pkmn2.TakeDamage(pkmn1.DoDamage(80, false, random1, 1), false);
                Console.WriteLine();

                if (pkmn2.RemainingHP > 0)
                {
                    Console.WriteLine(pkmn2.Name + " attacks " + pkmn1.Name);
                    pkmn1.TakeDamage(pkmn2.DoDamage(80, true, random2, 1), true);
                    Console.WriteLine();
                }
        }
    }
}
