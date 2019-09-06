using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace GameServer
{
    class CNetworkService
    {
        CListener client_listener;

        SocketAsyncEventArgs recive_event_args_pool;
        SocketAsyncEventArgs send_event_args_pool;

        public delegate void SessionHandler(TcpClient tcpClient);
        public SessionHandler session_created_callback { get; set; }
    }
}
