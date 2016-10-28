using System;
using System.Diagnostics;
using System.Threading;

namespace ComTcpBridge.Core
{
    public class FakeComConnection : DuplexConnection
    {
        #region State And Construction

        public FakeComConnection(string portName) : base(portName)
        {
        }

        #endregion

        #region Implementation

        protected override void InitializeChannel()
        {
            Debug.WriteLine($"Initializing fake COM connection {Name}");
        }

        protected override void DestroyChannel()
        {
            Debug.WriteLine($"Destroying fake COM connection {Name}");

        }

        protected override string GetString()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var text = $"{Name}: {DateTime.UtcNow.ToString("HH:mm:ss.ffff")}";
            Debug.WriteLine(text);
            return text;
        }

        protected override void PutString(string str)
        {
            Debug.WriteLine(str);
        }

        #endregion

    }
}
