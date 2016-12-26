using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Server
    {
        private static Server server;
        private Server()
        {
            this.Name = $"Server name {DateTime.Now}" ;
        }

        public string Name { get; private set; }

        public static Server Instance
        {
            get
            {
                if(server == null) server = new Server();
                return server;
            }
        }
    }
}
