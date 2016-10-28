using ComTcpBridge.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComToTcp
{
    public class MainFormViewModel
    {

        #region Interface

        // --- COM Ports ---

        public string[] ComPorts
        {
            get
            {
                return _comPorts;
            }
            private set
            {
                Swap(ref _comPorts, value, ComPortsChanged);
            }
        }

        public event EventHandler ComPortsChanged;
        
        public string SelectedComPort { get; set; }

        // --- TCP Ports ---

        public int SelectedTcpPort { get; set; }


        // --- State ---

        public bool IsListening
        {
            get
            {
                return _isListening;
            }
            private set
            {
                SwapValue(ref _isListening, value, IsListeningChanged);
            }
        }

        public event EventHandler IsListeningChanged;

        public void Listen()
        {
            ListenImpl();
        }

        public void Stop()
        {
            StopImpl();
        }
        

        // --- Connections ---

        public int TotalConnections
        {
            get
            {
                return _totalConnections;
            }
            private set
            {
                SwapValue(ref _totalConnections, value, TotalConnectionsChanged);
            }
        }

        public event EventHandler TotalConnectionsChanged;

        #endregion

        #region Implementation

        private string[] _comPorts = new string[0];
        private bool _isListening;
        private int _totalConnections;
        private ComPortListMonitor _listMonitor;
        private ComConnectionPool _comReaders = new ComConnectionPool();
        private TcpServer _server;

        public MainFormViewModel()
        {
            SelectedTcpPort = 5050;
            InitializeListMonitor();
        }

        private void InitializeListMonitor()
        {
            _listMonitor = new ComPortListMonitor();
            _comPorts = _listMonitor.GetComPorts();
            _listMonitor.ComPortsUpdate += _listMonitor_ComPortsUpdate;
        }

        void ListenImpl()
        {
            _server = new TcpServer
            {
                Port = SelectedTcpPort,
                ComConnection = _comReaders[SelectedComPort]
            };
            _server.Start();
            _server.ConnectionEvent += _server_ConnectionEvent;

            IsListening = true;
        }


        void StopImpl()
        {
            if (_server == null) return;

            _comReaders.Delete(_server.ComConnection.Name);
            _server.Stop();
            _server.ConnectionEvent -= _server_ConnectionEvent;
            _server = null;
            TotalConnections = 0;
            IsListening = false;
        }

        void Swap<T>(ref T target, T newValue, EventHandler eh) where T : class
        {
            if (newValue == null) throw new ArgumentNullException("value");

            if (target != newValue)
            {
                target = newValue;
                Raise(eh);
            }
        }

        void SwapValue<T>(ref T target, T newValue, EventHandler eh) where T : struct
        {
            if (!target.Equals(newValue))
            {
                target = newValue;
                Raise(eh);
            }
        }

        void Raise(EventHandler eh)
        {
            if (eh == null) return;

            var ctl = Program.MainForm;
            if (ctl == null) return;
            if (ctl.InvokeRequired)
            {
                ctl.BeginInvoke((Action<EventHandler>)Raise, new object[] { eh });
            }
            else
            {
                eh(this, EventArgs.Empty);
            }


        }

        private void _listMonitor_ComPortsUpdate(object sender, EventArgs e)
        {
            var newPorts = _listMonitor.GetComPorts();
            if (!Enumerable.SequenceEqual(_comPorts, newPorts))
            {
                ComPorts = newPorts;
            }

            // hack: use the same timer event to update TotalConnections
            TotalConnections = _server?.OpenedConnections ?? 0;
        }

        private void _server_ConnectionEvent(object sender, EventArgs e)
        {
            var server = sender as TcpServer;
            TotalConnections = server.OpenedConnections;
        }

        #endregion
    }

}
