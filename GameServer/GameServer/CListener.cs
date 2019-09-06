using System.Net;
using System.Net.Sockets;
using System;
namespace GameServer
{
    internal class CListener
    {
        SocketAsyncEventArgs accept_args;

        Socket listen_socket;

        AutoResetEvent flow_control_event;

        public delegate void NewclientHandler(Socket client_socket, object token);
        public NewclientHandler callback_on_newclient;

        public CListener() {
            this.callback_on_newclient = null;
        }

        public void start(string host, int port, int backlog) {
            //creat sock
            this.listen_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress address;

            if(host == "0.0.0.0") {
                address = IPAddress.Any;
            }
            else {
                address = IPAddress.Parse(host);
            }
            IPEndPoint endpoint = new IPEndPoint(address, port);

            try {
                //socket binding host info and call listen method
                this.listen_socket.Bind(endpoint);
                this.listen_socket.Listen(backlog);

                this.accept_args = new SocketAsyncEventArgs();
                this.accept_args.Completed += new System.EventHandler<SocketAsyncEventArgs>(on_accept_completed);

                this.listen_socket.AcceptAsync(this.accejjpt_args);
            }
            catch (System.Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}