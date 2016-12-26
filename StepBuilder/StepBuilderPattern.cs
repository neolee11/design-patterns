using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepBuilder
{
    public class Character
    {

        public String name;
        public String fighterClass;
        public String wizardClass;
        public String weapon;
        public String spell;
        public List<String> abilities;

        public Character(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            var flatAbilities = string.Empty;
            if (abilities != null)
            {
                flatAbilities = abilities.Aggregate(string.Empty, (s, s1) => s + s1 + ", ");
                flatAbilities = flatAbilities.Substring(0, flatAbilities.Length - 2);
                flatAbilities = $"[{flatAbilities}]";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("This is a ")
                .Append(fighterClass != null ? fighterClass : wizardClass)
                .Append(" named ")
                .Append(name)
                .Append(" armed with a ")
                .Append(weapon != null ? weapon : spell != null ? spell : "with nothing")
                .Append(abilities != null ? " and wielding " + flatAbilities + " abilities" : "")
                .Append('.');
            return sb.ToString();
        }
    }


    public sealed class CharacterStepBuilder
    {
        private CharacterStepBuilder()
        {
        }

        public static INameStep NewBuilder()
        {
            return new CharacterSteps();
        }

        /**
         * First Builder Step in charge of the Character name. Next Step available : ClassStep
         */
        public interface INameStep
        {
            IClassStep SetName(String name);
        }

        /**
         * This step is in charge of setting the Character class (fighter or wizard). Fighter choice :
         * Next Step available : WeaponStep Wizard choice : Next Step available : SpellStep
         */
        public interface IClassStep
        {
            IWeaponStep SetFighterClass(String fighterClass);

            ISpellStep SetWizardClass(String wizardClass);
        }

        /**
         * This step is in charge of the weapon. Weapon choice : Next Step available : AbilityStep No
         * weapon choice : Next Step available : BuildStep
         */
        public interface IWeaponStep
        {
            IAbilityStep WithWeapon(String weapon);

            IBuildStep NoWeapon();
        }

        /**
         * This step is in charge of the spell. Spell choice : Next Step available : AbilityStep No spell
         * choice : Next Step available : BuildStep
         */
        public interface ISpellStep
        {
            IAbilityStep WithSpell(String spell);

            IBuildStep NoSpell();
        }

        /**
         * This step is in charge of abilities. Next Step available : BuildStep
         */
        public interface IAbilityStep
        {
            IAbilityStep WithAbility(String ability);

            IBuildStep NoMoreAbilities();

            IBuildStep NoAbilities();
        }

        /**
         * This is the final step in charge of building the Character Object. Validation should be here.
         */
        public interface IBuildStep
        {
            Character Build();
        }

        private class CharacterSteps : INameStep, IClassStep, IWeaponStep, ISpellStep, IAbilityStep, IBuildStep
        {
            private String name;
            private String fighterClass;
            private String wizardClass;
            private String weapon;
            private String spell;
            private List<String> abilities = new List<string>();

            public IClassStep SetName(String name)
            {
                this.name = name;
                return this;
            }

            public IWeaponStep SetFighterClass(String fighterClass)
            {
                this.fighterClass = fighterClass;
                return this;
            }

            public ISpellStep SetWizardClass(String wizardClass)
            {
                this.wizardClass = wizardClass;
                return this;
            }

            public IAbilityStep WithWeapon(String weapon)
            {
                this.weapon = weapon;
                return this;
            }

            public IBuildStep NoWeapon()
            {
                return this;
            }

            public IAbilityStep WithSpell(String spell)
            {
                this.spell = spell;
                return this;
            }

            public IBuildStep NoSpell()
            {
                return this;
            }

            public IAbilityStep WithAbility(String ability)
            {
                this.abilities.Add(ability);
                return this;
            }

            public IBuildStep NoMoreAbilities()
            {
                return this;
            }

            public IBuildStep NoAbilities()
            {
                return this;
            }

            public Character Build()
            {
                Character character = new Character(name);

                if (fighterClass != null)
                {
                    character.fighterClass = fighterClass;
                }
                else
                {
                    character.wizardClass = wizardClass;
                }

                if (weapon != null)
                {
                    character.weapon = weapon;
                }
                else
                {
                    character.spell = spell;
                }

                if (abilities.Any())
                {
                    character.abilities = abilities;
                }

                return character;
            }
        }
    }
}
