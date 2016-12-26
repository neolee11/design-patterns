using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPool
{
    public abstract class ObjectPool<T>
    {

        //private Dictionary<int, T> available = new Dictionary<int, T>();
        //private Dictionary<int, T> inUse = new Dictionary<int, T>();

        private Queue<T> available = new Queue<T>();
        private List<T> inUse = new List<T>();
        private int nextIndex = -1;

        private Object thisLock = new Object();

        protected abstract T create();

        /**
         * Checkout object from pool
         */
        public T checkOut()
        {
            lock (thisLock)
            {
                if (available.Count <= 0)
                {
                    var newObj = create();
                    available.Enqueue(newObj);
                }

                T instance = available.Dequeue();
                inUse.Add(instance);

                return instance;
            }
        }

        public void checkIn(T instance)
        {
            lock (thisLock)
            {
                inUse.Remove(instance);
                available.Enqueue(instance);
            }
        }
        
        public override String ToString()
        {
            return $"Pool available={available.Count} inUse={inUse.Count}";
        }
    }

    public class OliphauntPool : ObjectPool<Oliphaunt>
    {
        protected override Oliphaunt create()
        {
            return new Oliphaunt();
        }
    }

    /// <summary>
    /// Oliphaunts are expensive to create
    /// </summary>
    public class Oliphaunt
    {

        private static int counter = 1;

        //private readonly int id;
        public int Id { get; }

        /**
         * Constructor
         */
        public Oliphaunt()
        {
            Id = counter++;
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override String ToString()
        {
            return String.Format("Oliphaunt id=%d", Id);
        }
    }

}
