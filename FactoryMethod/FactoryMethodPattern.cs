using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public interface IBlacksmith
    {
        IWeapon manufactureWeapon(EWeaponType weaponType);
    }

    public class ElfBlacksmith : IBlacksmith
    {
        public IWeapon manufactureWeapon(EWeaponType weaponType)
        {
            return new ElfWeapon(weaponType);
        }
    }

    public class OrcBlacksmith : IBlacksmith
    {
        public IWeapon manufactureWeapon(EWeaponType weaponType)
        {
            return new OrcWeapon(weaponType);
        }
    }

    public interface IWeapon
    {
        EWeaponType getWeaponType();
    }

    public class OrcWeapon : IWeapon
    {
        private EWeaponType weaponType;

        public OrcWeapon(EWeaponType weaponType)
        {
            this.weaponType = weaponType;
        }

        public override String ToString()
        {
            return "Orcish " + weaponType;
        }

        public EWeaponType getWeaponType()
        {
            return weaponType;
        }
    }

    public class ElfWeapon : IWeapon
    {

        private EWeaponType weaponType;

        public ElfWeapon(EWeaponType weaponType)
        {
            this.weaponType = weaponType;
        }

        public override String ToString()
        {
            return "Elven " + weaponType;
        }

        public EWeaponType getWeaponType()
        {
            return weaponType;
        }
    }


    public enum EWeaponType
    {
        SHORT_SWORD, SPEAR, AXE, UNDEFINED
    }
}
