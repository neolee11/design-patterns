using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryKit
{

    //Interesting pattern, still not sure how it works

    public interface IWeaponFactory
    {

        /**
         * Creates an instance of the given type.
         * @param name representing enum of an object type to be created.
         * @return new instance of a requested class implementing {@link Weapon} interface.
         */
        IWeapon Create(WeaponType name);

        /**
         * Creates factory - placeholder for specified {@link Builder}s.
         * @param consumer for the new builder to the factory.
         * @return factory with specified {@link Builder}s
         */
        //static WeaponFactory factory(Consumer<IBuilder> consumer)
        //{
        //    HashMap<WeaponType, Supplier<Weapon>> map = new HashMap<>();
        //    consumer.accept(map::put);
        //    return name->map.get(name).get();
        //}
    }

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(WeaponType name)
        {
            throw new NotImplementedException();
        }
    }

    public interface IBuilder
    {
        //void Add(WeaponType name, Supplier<Weapon> supplier);
    }



    public interface IWeapon
    {
    }

    public class Axe : IWeapon
    {
        public override String ToString()
        {
            return "Axe";
        }
    }

    public class Bow : IWeapon
    {
        public override String ToString()
        {
            return "Bow";
        }
    }

    public class Spear : IWeapon
    {
        public override String ToString()
        {
            return "Spear";
        }
    }

    public class Sword : IWeapon
    {
        public override String ToString()
        {
            return "Sword";
        }
    }

    public enum WeaponType
    {
        SWORD, AXE, BOW, SPEAR
    }
}
