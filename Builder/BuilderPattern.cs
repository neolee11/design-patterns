using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Hero
    {
        public Profession? profession;
        public String name;
        public HairType? hairType;
        public HairColor? hairColor;
        public Armor? armor;
        public Weapon? weapon;

        private Hero(HeroBuilder builder)
        {
            this.profession = builder.profession;
            this.name = builder.name;
            this.hairColor = builder.hairColor;
            this.hairType = builder.hairType;
            this.weapon = builder.weapon;
            this.armor = builder.armor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("This is a ")
                    .Append(profession)
                    .Append(" named ")
                    .Append(name);
            if (hairColor != null || hairType != null)
            {
                sb.Append(" with ");
                if (hairColor != null)
                {
                    sb.Append(hairColor).Append(' ');
                }
                if (hairType != null)
                {
                    sb.Append(hairType).Append(' ');
                }
                sb.Append(hairType != HairType.BALD ? "hair" : "head");
            }
            if (armor != null)
            {
                sb.Append(" wearing ").Append(armor);
            }
            if (weapon != null)
            {
                sb.Append(" and wielding a ").Append(weapon);
            }
            sb.Append('.');
            return sb.ToString();
        }


        public class HeroBuilder
        {
            internal Profession? profession;
            internal String name;
            internal HairType? hairType;
            internal HairColor? hairColor;
            internal Armor? armor;
            internal Weapon? weapon;

            public HeroBuilder(Profession? profession, String name)
            {
                if (profession == null || name == null)
                {
                    throw new ArgumentException("profession and name can not be null");
                }

                this.profession = profession;
                this.name = name;
            }

            public HeroBuilder WithHairType(HairType hairType)
            {
                this.hairType = hairType;
                return this;
            }

            public HeroBuilder withHairColor(HairColor hairColor)
            {
                this.hairColor = hairColor;
                return this;
            }

            public HeroBuilder withArmor(Armor armor)
            {
                this.armor = armor;
                return this;
            }

            public HeroBuilder withWeapon(Weapon weapon)
            {
                this.weapon = weapon;
                return this;
            }

            public Hero Build()
            {
                return new Hero(this);
            }
        }
       
    }

    public enum Armor
    {
        CLOTHES,
        LEATHER,
        CHAIN_MAIL,
        PLATE_MAIL
    }

    public enum HairColor
    {
        WHITE,
        BLOND,
        RED,
        BROWN,
        BLACK
    }

    public enum HairType
    {
        BALD,
        SHORT,
        CURLY,
        LONG_STRAIGHT,
        LONG_CURLY      
     }

    public enum Profession
    {
        WARRIOR,
        THIEF,
        MAGE,
        PRIEST
    }

    public enum Weapon
    {
        DAGGER,
        SWORD,
        AXE,
        WARHAMMER,
        BOW
    }

}
