using System.Net.Sockets;

namespace server.abstracts;

interface IDataSender
{
    void SendData<T>(TcpClient client, IEnumerable<T> data);
}