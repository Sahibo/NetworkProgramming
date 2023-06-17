using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        int port = 8888;
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        TcpListener listener = new TcpListener(ipAddress, port);
        listener.Start();

        Console.WriteLine("Server started.\n Waiting for connections...");

        TcpClient client1 = listener.AcceptTcpClient();
        Console.WriteLine("Player 1 connected.");

        TcpClient client2 = listener.AcceptTcpClient();
        Console.WriteLine("Player 2 connected.");

        NetworkStream stream1 = client1.GetStream();
        NetworkStream stream2 = client2.GetStream();

        while (true)
        {
            byte[] buffer = new byte[1];
            int bytesRead = stream1.Read(buffer, 0, buffer.Length);

            if (bytesRead > 0)
            {
                Console.WriteLine("Player 1 choice: " + (Choice)buffer[0]);

                stream2.Write(buffer, 0, buffer.Length);
            }

            bytesRead = stream2.Read(buffer, 0, buffer.Length);

            if (bytesRead > 0)
            {
                Console.WriteLine("Player 2 choice: " + (Choice)buffer[0]);

                stream1.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

enum Choice
{
    Rock = 0,
    Paper = 1,
    Scissors = 2
}
