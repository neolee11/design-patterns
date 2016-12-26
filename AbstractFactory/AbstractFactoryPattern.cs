using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IKingdomFactory
    {
        IKing CreateKing();
        ICastle CreateCastle();
    }

    public class GoodKingdomFactory : IKingdomFactory
    {
        public IKing CreateKing()
        {
           return new GoodKing();
        }

        public ICastle CreateCastle()
        {
            return new GoodCastle();
        }
    }

    public class EvilKingdomFactory : IKingdomFactory
    {
        public IKing CreateKing()
        {
            return new EvilKing();
        }

        public ICastle CreateCastle()
        {
            return new EvilCastle();
        }
    }


    public interface ICastle
    {
        string Location();
    }

    class EvilCastle : ICastle
    {
        public string Location()
        {
            return "Winter town";
        }
    }

    class GoodCastle : ICastle
    {
        public string Location()
        {
            return "Awesome city";
        }
    }

    public interface IKing
    {
        string Description();
    }

    public class GoodKing : IKing
    {
        public string Description()
        {
            return "I'm a good king";
        }
    }

    public class EvilKing : IKing
    {
        public string Description()
        {
            return "I'm an evil king";
        }
    }

}
