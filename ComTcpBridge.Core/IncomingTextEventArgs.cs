using System;

namespace ComTcpBridge.Core
{
    public class IncomingTextEventArgs : EventArgs
    {
        public string IncomingText { get; private set; }

        public IncomingTextEventArgs(string incomingText)
        {
            IncomingText = incomingText;
        }

    }
}
