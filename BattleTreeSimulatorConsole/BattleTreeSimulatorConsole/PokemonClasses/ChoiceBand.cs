﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    class ChoiceBand : IPokemon
    {
        IPokemon pokemon;

        public ChoiceBand(IPokemon pokemon)
        {
            this.pokemon = pokemon;
        }

        public string Name { get { return pokemon.Name; } set { pokemon.Name = value; } }
        public int RemainingHP { get { return pokemon.RemainingHP; } set { pokemon.RemainingHP = value; } }
        public int MaxHP { get { return pokemon.MaxHP; } set { pokemon.MaxHP = value; } }
        public int Attack { get { return pokemon.Attack; } set { pokemon.Attack = value; } }
        public int Defense { get { return pokemon.Defense; } set { pokemon.Defense = value; } }
        public int SpecialAttack { get => pokemon.SpecialAttack; set => pokemon.SpecialAttack = value; }
        public int SpecialDefense { get => pokemon.SpecialDefense; set => pokemon.SpecialDefense = value; }
        public int Speed { get { return pokemon.Speed; } set { pokemon.Speed = value; } }
        
        int IPokemon.DoDamage(int power, double random, double modifier)
        {
            return pokemon.DoDamage(power, random, modifier * 1.5);
        }

        private int pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (int)Math.Ceiling(number) : (int)Math.Floor(number);
        }

        void IPokemon.TakeDamage(int damageBase)
        {
            pokemon.TakeDamage(damageBase);
        }
    }
}
