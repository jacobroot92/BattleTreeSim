﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public class Pokemon : IPokemon
    {
        private string Name;
        private int RemainingHP;
        private int MaxHP;
        private int Attack;
        private int Defense;
        private int SpecialAttack;
        private int SpecialDefense;
        private int Speed;

        string IPokemon.Name { get { return Name; } set { Name = value; } }
        int IPokemon.RemainingHP { get { return RemainingHP; } set { RemainingHP = value; } }
        int IPokemon.MaxHP { get { return MaxHP; } set { MaxHP = value; } }
        int IPokemon.Attack  { get { return Attack; } set { Attack = value; } }
        int IPokemon.Defense  { get { return Defense; } set { Defense = value; } }
        int IPokemon.SpecialAttack { get { return SpecialAttack; } set { SpecialAttack = value; } }
        int IPokemon.SpecialDefense { get { return SpecialDefense; } set { SpecialDefense = value; } }
        int IPokemon.Speed  { get { return Speed; } set { Speed = value; } }

        public Pokemon (Pokemon pokemon)
        {
            Name = pokemon.Name;
            Attack = pokemon.Attack;
            Defense = pokemon.Defense;
            RemainingHP = pokemon.RemainingHP;
            MaxHP = pokemon.MaxHP;
            Speed = pokemon.Speed;
        }

        public Pokemon (string Name, int Attack, int Defense, int HP, int Speed)
        {
            this.Name = Name;
            this.Attack = Attack;
            this.Defense = Defense;
            RemainingHP = MaxHP = HP;
            this.Speed = Speed;
        }

        public int DoDamage(int power, double random, double modifier)
        {
            return pokeRound(((12*power*Attack) + 2)*(random*modifier));
        }

        public void TakeDamage(int damageBase)
        {
            var damageAfterDefense = damageBase / (50*Defense);
            var roundedDamage = pokeRound(damageAfterDefense);
            if (roundedDamage > RemainingHP)
                RemainingHP = 0;
            else
                RemainingHP -= roundedDamage;
            Console.WriteLine(Name + " has " + RemainingHP + " HP remaining!");
        }

        public int pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (int)Math.Ceiling(number) : (int)Math.Floor(number);
        }
    }
}
