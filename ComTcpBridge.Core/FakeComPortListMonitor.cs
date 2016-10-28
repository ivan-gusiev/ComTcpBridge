using System.Linq;

namespace ComTcpBridge.Core
{
    public sealed class FakeComPortListMonitor : ComPortListMonitor
    {
        private readonly static string[] _fakePorts = Enumerable.Range(1, 4).Select(i => "COM" + i).ToArray();

        public override string[] GetComPorts()
        {
            return _fakePorts;
        }

    }
}
