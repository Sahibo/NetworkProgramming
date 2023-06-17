using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter server IP address:");
        string ipAddress = Console.ReadLine();

        Console.WriteLine("Enter server port number:");
        int port = int.Parse(Console.ReadLine());

        TcpClient client = new TcpClient(ipAddress, port);
        NetworkStream stream = client.GetStream();

        Console.WriteLine("Connected to the server.");

        while (true)
        {
            Console.WriteLine("Enter your choice (0 - Rock, 1 - Paper, 2 - Scissors):");
            byte[] buffer = new byte[1];
            buffer[0] = byte.Parse(Console.ReadLine());

            stream.Write(buffer, 0, buffer.Length);

            byte[] opponentChoiceBuffer = new byte[1];
            stream.Read(opponentChoiceBuffer, 0, opponentChoiceBuffer.Length);

            Console.WriteLine("Opponent's choice: " + (Choice)opponentChoiceBuffer[0]);
        }
    }
}

enum Choice
{
    Rock = 0,
    Paper = 1,
    Scissors = 2
}