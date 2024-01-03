using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardCalculator
{
    public class Spell
    {
       public SpellInfo SpellInfo { get; set; }
       public SpellSchool SpellSchool { get; set; }


        public Spell(SpellInfo spellInfo, SpellSchool spellSchool)
        {
            SpellInfo = spellInfo;
            SpellSchool = spellSchool;
            
        }

        public override string ToString()
        {
            return $"---------------Spell Info-------------" +
                   $"\nSpell Name:   {SpellInfo.spellName}" +
                   $"\nSpell Level:  {SpellInfo.spellLevel}" +
                   $"\nSpell School: {SpellSchool}" +
                   $"\n--------------------------------------"


                   ;
                    
        }

    }
}
