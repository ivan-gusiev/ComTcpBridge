using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ComTcpBridge.Core
{
    public class TcpServer
    {
        public int Port { get; set; }

        public ComConnection ComConnection { get; set; }

        public event EventHandler ConnectionEvent;

        public int OpenedConnections { get { return _connections.Count(c => c.IsOpen); } }

        private object tcpIncomingLock = new object();

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            ComConnection.Received += ComReader_Incoming;

            var thread = new Thread(ListenerLoop);
            thread.Start();
        }

        public void Stop()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener = null;
            }
            ComConnection.Received -= ComReader_Incoming;
        }

        private TcpListener _listener;
        private List<TcpConnection> _connections = new List<TcpConnection>(10);
        
        private void ListenerLoop()
        {
            _listener.Start();
            while (true)
            {
                try
                {
                    var client = _listener.AcceptTcpClient();
                    var connection = new TcpConnection(client);
                    _connections.Add(connection);
                    connection.Start();
                    connection.Received += Connection_Incoming;
                    ConnectionEvent?.Invoke(this, EventArgs.Empty);
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                catch (SocketException)
                {
                    break;
                }
            }

            foreach (var conn in _connections)
            {
                conn.Stop();
            }
            _connections.Clear();

            ConnectionEvent?.Invoke(this, EventArgs.Empty);
        }

        private void Connection_Incoming(object sender, IncomingTextEventArgs e)
        {
            lock (tcpIncomingLock)
            {
                ComConnection.Send(e.IncomingText);
            }
        }

        private void ComReader_Incoming(object sender, IncomingTextEventArgs e)
        {
            foreach (var conn in _connections)
            {
                conn.Send(e.IncomingText);
            }
        }
    }
}
