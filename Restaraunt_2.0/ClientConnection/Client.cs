using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConnection
{/// <summary>
/// Sends a request to the server and receives a response
/// </summary>
    public class Client
    {/// <summary>
     /// Creates a connection
     /// </summary>
     /// <param name="tcpClient">The  TCP client by which we will connect</param>
     /// <returns></returns>
        public static NetworkStream Start(TcpClient tcpClient)
        {
            NetworkStream stream = tcpClient.GetStream();
            return stream;
        }
        /// <summary>
        /// The method that sends the request
        /// </summary>
        /// <param name="Message">Request text</param>
        /// <param name="stream">NetworkStream</param>
        /// <param name=" tcpClient">TCP Client</param>
        /// <returns>Response string from the server</returns>
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
