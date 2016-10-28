using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ComTcpBridge.Core
{
    class TcpConnection : DuplexConnection
    {
        #region State and Construction

        private readonly TcpClient _client;
        private NetworkStream _stream;
        private StreamReader _reader;

        public TcpConnection(TcpClient client) : base(client?.Client.LocalEndPoint.ToString())
        {
            if (client == null) throw new ArgumentNullException("client");

            _client = client;
            _client.LingerState = new LingerOption(enable: false, seconds: 0);
        }

        #endregion

        #region Implementation

        protected override void InitializeChannel()
        {
            _stream = _client.GetStream();
            _reader = new StreamReader(_stream);
        }

        protected override void DestroyChannel()
        {
            _stream?.Close();
            _client.Close();
        }

        protected override string GetString()
        {
            try
            {
                return _reader.ReadLine();
            }
            catch (IOException ioe)
            {
                Debug.WriteLine(ioe.Message);
                Stop();
                return null;
            }
        }

        protected override void PutString(string line)
        {
            if (!line.EndsWith("\n")) line += Environment.NewLine;
            var bytes = Encoding.UTF8.GetBytes(line);
            try
            {
                _stream.Write(bytes, 0, bytes.Length);
                _stream.Flush();
            }
            catch (IOException ioe)
            {
                Debug.WriteLine(ioe.Message);
                Stop();
            }
        }

        #endregion

    }
}
