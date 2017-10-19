using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.PokemonClasses
{
    interface IPokemon
    {
        int DoDamage(int power);

        void TakeDamage(int damageBase, double random);
    }
}
