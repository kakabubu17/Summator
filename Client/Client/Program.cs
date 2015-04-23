using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SendMessage(1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
        static void SendMessage(int port)
        {
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEP = new IPEndPoint(ipAddress, port);

            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.IP);

            socket.Connect(ipEP);
            Console.WriteLine("Введите 3 числа: ");
            string mess = Console.ReadLine();
            byte[] msg = Encoding.UTF8.GetBytes(mess);

            int bytesSend = socket.Send(msg);
            SendMessage(port);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
