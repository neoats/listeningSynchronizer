using System.Net.Sockets;
using server.abstracts;

namespace server.concretes;

public class DataSender : IDataSender
{
    public void SendData<T>(TcpClient client, IEnumerable<T> data)
    {
        var stream = client.GetStream();
        var writer = new StreamWriter(stream);
        writer.AutoFlush = true;

        foreach (var item in data)
        {
            Thread.Sleep(350);
            Console.WriteLine($"Sending : {item}");
            writer.WriteLine($"{item}");
        }

        stream.Flush();
        client.Close();
    }

   
}