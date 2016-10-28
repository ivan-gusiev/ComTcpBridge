using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ComTcpBridge.Core
{
    public abstract class DuplexConnection
    {

        #region State And Construction

        private string name;
        private Thread _readerThread;
        private volatile bool _closed;

        protected DuplexConnection(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", "name");

            this.name = name;
        }

        #endregion

        #region Interface

        public bool IsOpen { get { return !_closed; } }

        public void Start()
        {
            _readerThread = new Thread(Listen) { IsBackground = true };
            _closed = false;
            _readerThread.Start();
        }

        public void Stop()
        {
            DestroyChannel();
            _readerThread = null;
            _closed = true;
        }

        public string Name
        {
            get { return name; }
        }

        public event EventHandler<IncomingTextEventArgs> Received;

        public void Send(string line)
        {
            if (_closed) return;
            PutString(line);
        }

        #endregion

        #region Internal interface

        protected virtual void InitializeChannel()
        {

        }

        protected virtual void DestroyChannel()
        {

        }

        protected abstract string GetString();

        protected abstract void PutString(string line);

        #endregion

        #region Implementation

        private void Listen()
        {
            InitializeChannel();

            string value;
            EventHandler<IncomingTextEventArgs> inc;
            do
            {
                value = GetString();
                inc = Received;
                if (inc != null)
                {
                    inc(this, new IncomingTextEventArgs(value));
                }
            } while (value != null && !_closed);
        }

        #endregion

    }
}
