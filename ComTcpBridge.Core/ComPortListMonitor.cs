using System;
using System.IO.Ports;
using System.Timers;

namespace ComTcpBridge.Core
{
    public class ComPortListMonitor
    {
        Timer _timer;

        public event EventHandler ComPortsUpdate;

        public virtual string[] GetComPorts()
        {
            return SerialPort.GetPortNames();
        }

        public ComPortListMonitor()
        {
            _timer = new Timer(10 * 1000);
            _timer.AutoReset = true;
            _timer.Elapsed += (s, ea) => ComPortsUpdate?.Invoke(this, EventArgs.Empty);
            _timer.Start();
        }

    }
}
