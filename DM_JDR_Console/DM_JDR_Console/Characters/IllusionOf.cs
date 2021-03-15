using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    class IllusionOf : Character
    {
        public IllusionOf(Illusioniste illusionisteParent, int cpt)
        {
            this.name = illusionisteParent.GetName() + " n° " + cpt.ToString();
            this.attack = illusionisteParent.GetAttack();
            this.defense = illusionisteParent.GetDefense();
            this.attackSpeed = illusionisteParent.GetAttackSpeed();
            this.damages = illusionisteParent.GetDamages();
            this.maximumLife = 1;
            this.currentLife = 1;
            this.powerSpeed = illusionisteParent.GetPowerSpeed();
            this.illusionisteParent = illusionisteParent;
            rand = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }
    }
}
