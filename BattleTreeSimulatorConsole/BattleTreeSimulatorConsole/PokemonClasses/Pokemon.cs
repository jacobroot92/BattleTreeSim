using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    public class Pokemon : IPokemon
    {
        public string Name;
        int Attack;
        int Defense;
        public int RemainingHP;
        public int MaxHP;

        public Pokemon (string Name, int Attack, int Defense, int HP)
        {
            this.Name = Name;
            this.Attack = Attack;
            this.Defense = Defense;
            RemainingHP = MaxHP = HP;
        }

        public int DoDamage(int power)
        {
            return 12*power*Attack;
        }

        public void TakeDamage(int damageBase, double random)
        {
            var damageAfterDefense = (damageBase / (50*Defense)) + 2;
            var damageAfterRandom = damageAfterDefense * random;
            var roundedDamage = pokeRound(damageAfterRandom);
            if (roundedDamage > RemainingHP)
                RemainingHP = 0;
            else
                RemainingHP -= roundedDamage;
        }

        private int pokeRound(double number)
        {
            //Rounds double in the same fashion in the games
            return (number % 1 > 0.5) ? (int)Math.Ceiling(number) : (int)Math.Floor(number);
        }
    }
}
