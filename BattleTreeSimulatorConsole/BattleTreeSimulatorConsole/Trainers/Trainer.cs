using BattleTreeSimulatorConsole.PokemonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTreeSimulatorConsole.Trainers
{
    class Trainer
    {
        public IPokemon Pokemon1 { get; set; }
        public IPokemon Pokemon2 { get; set; }
        public IPokemon Pokemon3 { get; set; }

        public Trainer()
        {
            //Blank to randomly populate computer trainer
        }

        public Trainer(IPokemon pokemon1, IPokemon pokemon2, IPokemon pokemon3)
        {
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
            Pokemon3 = pokemon3;
        }

        public bool HasRemainingPokemon()
        {
            if(Pokemon1.RemainingHP > 0)
            {
                return true;
            }
            else if(Pokemon2.RemainingHP > 0)
            {
                return true;
            }
            else if(Pokemon3.RemainingHP > 0)
            {
                return true;
            }

            return false;
        }

        public void PopulateRandomCPU()
        {
            Pokemon1 = new Pokemon("Pichu", 200, 50, 50, 50, 50, 5, Item.Eviolite, Type.Electric, Type.None, true);
            Pokemon2 = new Pokemon("Pikachu", 200, 50, 50, 50, 50, 5, Item.ChoiceScarf, Type.Electric, Type.None, true);
            Pokemon3 = new Pokemon("Raichu", 200, 50, 50, 50, 50, 5, Item.ChoiceBand, Type.Electric, Type.Psychic, false);
        }
    }
}
