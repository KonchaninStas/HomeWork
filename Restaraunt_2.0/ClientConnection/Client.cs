using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConnection
{
    public class Client
    {
        public static NetworkStream Start(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            return stream;
        }
        public static string ClientMessageForServer(string Message, NetworkStream stream, TcpClient tcpClient)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(Message);
            stream.Write(buffer, 0, buffer.Length);
            buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(buffer, 0, buffer.Length);
                builder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
            }
            while (stream.DataAvailable);
            return Message = builder.ToString();

        }
       
    }
}
