using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace URCommunicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.12"), 29999);

            byte[] receiveBuffer = new byte[2048];
            string response = "";

            int bytesRec = 0;

            s.Connect(endPoint);
            if (s.Connected)
            {
                bytesRec = s.Receive(receiveBuffer);
                response = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRec);
                Console.WriteLine($"Successfully connected! response : {response}");
            }

            

            while (true)
            {
                Console.WriteLine("커맨드를 입력하세요 1: power on 2: power off 0: 프로그램 종료");
                string command = Console.ReadLine();
                string sendCommand = "";
                switch (command)
                {
                    case "0":
                        // 프로그램 종료
                        break;
                    case "1":
                        sendCommand = "power on\r\n";
                        break;
                    case "2":
                        sendCommand = "power off\r\n";
                        break;
                    case "3":
                        sendCommand = "robotmode\r\n";
                        break;
                    case "4":
                        sendCommand = "get loaded program\r\n";
                        break;
                    case "5":
                        sendCommand = "popup test popup\r\n";
                        break;
                    case "6":
                        sendCommand = "brake release\r\n";
                        break;
                    default:
                        sendCommand = command + "\r\n";
                        break;
                }

                if (command.Equals("0"))
                {
                    s.Disconnect(true);
                    s.Close();
                    s.Dispose();
                    break;
                }
                    

                byte[] sendBuffer = new byte[256];
                
                sendBuffer = Encoding.ASCII.GetBytes(sendCommand);

                //s.Send(sendBuffer);

                

                s.Send(sendBuffer);
                Console.WriteLine($"Successfully sended! ");

                bytesRec = s.Receive(receiveBuffer);
                response = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRec);
                Console.WriteLine($"response : {response}");

                
            }
            

        }
    }
}
