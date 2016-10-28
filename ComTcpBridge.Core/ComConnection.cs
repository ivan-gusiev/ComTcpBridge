using System;
using System.IO.Ports;
using System.Threading;

namespace ComTcpBridge.Core
{
    public class ComConnection : DuplexConnection
    {
        #region State And Construction
        
        private SerialPort _port;

        public ComConnection(string portName) : base(portName)
        {
        }
        
        #endregion

        #region Implementation
        
        protected override void InitializeChannel()
        {
            _port = new SerialPort(Name, 9600)
            {
                //BaudRate = 9600,
                //DataBits = 8,
                //Handshake = Handshake.None,
                //Parity = Parity.None,
                //StopBits = StopBits.One,
                //DtrEnable = false,
                
            };
            _port.Open();
        }

        protected override void DestroyChannel()
        {
            _port.Dispose();
        }

        protected override string GetString()
        {
            try
            {
                return _port.ReadLine();
            }
            catch
            {
                // we just stop the communication on any error
                return null;
            }
        }

        protected override void PutString(string str)
        {
            try
            {
                _port.WriteLine(str);
            }
            catch
            {
                // ignore everything on error
            }
        }

        #endregion

    }
}
