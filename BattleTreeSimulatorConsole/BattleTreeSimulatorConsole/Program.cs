using BattleTreeSimulatorConsole.PokemonClasses;
using BattleTreeSimulatorConsole.Trainers;
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
            IPokemon Typhlosion = new Pokemon("Typhlosion", 200, 50, 50, 50, 50, 6, Item.ChoiceBand, Type.Fire, Type.None, false);
            IPokemon Pikachu = new Pokemon("Pikachu", 200, 50, 50, 50, 50, 5, Item.ChoiceScarf, Type.Electric, Type.None, true);
            IPokemon Porygon2 = new Pokemon("Porygon2", 200, 50, 50, 50, 50, 2, Item.Eviolite, Type.Normal, Type.None, true);
            Trainer User = new Trainer(Typhlosion, Pikachu, Porygon2);
            Trainer CPU = new Trainer();
            CPU.PopulateRandomCPU();
            IPokemon pkmn1;
            IPokemon pkmn2;
            int round = 1;

            var userPokemon = User.Pokemon1;
            var CPUPokemon = CPU.Pokemon1;

            while (userPokemon.RemainingHP > 0 && CPU.Pokemon1.RemainingHP > 0)
            {
                if(userPokemon.Speed > CPUPokemon.Speed)
                {
                    pkmn1 = userPokemon;
                    pkmn2 = CPUPokemon;
                }
                else if (userPokemon.Speed < CPUPokemon.Speed)
                {
                    pkmn1 = CPUPokemon;
                    pkmn2 = userPokemon;
                }
                else
                {
                    if(GetRandomNumber(0,1,random) > 0.5)
                    {
                        pkmn1 = userPokemon;
                        pkmn2 = CPUPokemon;
                    }
                    else
                    {
                        pkmn1 = CPUPokemon;
                        pkmn2 = userPokemon;
                    }
                }
                pkmn1 = Update(pkmn1);
                pkmn2 = Update(pkmn2);
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

        private static IPokemon Update(IPokemon pokemon)
        {
            IPokemon updatedPokemon = pokemon;
            switch(pokemon.HeldItem)
            {
                case Item.ChoiceBand:
                    updatedPokemon = new ChoiceBand(pokemon);
                    break;
                case Item.ChoiceScarf:
                    updatedPokemon = new ChoiceScarf(pokemon);
                    break;
                case Item.Eviolite:
                    updatedPokemon = new Eviolite(pokemon);
                    break;
            }

            return updatedPokemon;
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
