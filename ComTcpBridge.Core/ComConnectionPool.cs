using System;
using System.Collections.Generic;

namespace ComTcpBridge.Core
{
    public class ComConnectionPool
    {
        private Dictionary<string, ComConnection> _connections = new Dictionary<string, ComConnection>(StringComparer.InvariantCultureIgnoreCase);

        public ComConnection this[string port]
        {
            get
            {
                ComConnection rdr;
                if (_connections.TryGetValue(port, out rdr))
                {
                    return rdr;
                }
                else
                {
                    return CreateAndAdd(port);
                }
            }
        }

        public bool Delete(string port)
        {
            ComConnection rdr;

            if (_connections.TryGetValue(port, out rdr))
            {
                rdr.Stop();
                return _connections.Remove(port);
            }
            else
            {
                return false;
            }
        }

        private ComConnection CreateAndAdd(string port)
        {
            var reader = new ComConnection(port);
            reader.Start();
            _connections[port] = reader;
            return reader;
        }
    }
}
