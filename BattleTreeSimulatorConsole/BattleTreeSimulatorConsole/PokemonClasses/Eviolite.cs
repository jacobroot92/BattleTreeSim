using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    class Eviolite : IPokemon
    {
        IPokemon pokemon;

        public Eviolite(IPokemon pokemon)
        {
            this.pokemon = pokemon;
        }

        public string Name { get => pokemon.Name; set => pokemon.Name = value; }
        public int RemainingHP { get => pokemon.RemainingHP; set => pokemon.RemainingHP = value; }
        public int MaxHP { get => pokemon.MaxHP; set => pokemon.MaxHP = value; }
        public int Attack { get => pokemon.Attack; set => pokemon.Attack = value; }
        public int Defense { get => pokeRound(pokemon.Defense * 1.5); set => pokemon.Defense = value; }
        public int SpecialAttack { get => pokemon.SpecialAttack; set => pokemon.SpecialAttack = value; }
        public int SpecialDefense { get => pokeRound(pokemon.SpecialDefense * 1.5); set => pokemon.SpecialDefense = value; }
        public int Speed { get => pokemon.Speed; set => pokemon.Speed = value; }
        
        public int DoDamage(int power, double random, double modifier)
        {
            return pokemon.DoDamage(power, random, modifier);
        }

        public void TakeDamage(int damageBase)
        {
            pokemon.TakeDamage(damageBase);
        }

        private int pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (int)Math.Ceiling(number) : (int)Math.Floor(number);
        }
    }
}
