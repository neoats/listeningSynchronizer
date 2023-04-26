using System.Net;
using System.Net.Sockets;

namespace client;

class Program
{
    #region noAsyncTcp

    public static void Main(string[] args)
    {
        var client = new TcpClient();
        Console.WriteLine("connecting to server");
        Thread.Sleep(300);
        var ipAddress = IPAddress.Parse("127.0.0.1");
        var port = 8080;

        client.Connect(ipAddress, port);

        Console.WriteLine("Connected to server");

        using var stream = client.GetStream();
        using var reader = new StreamReader(stream);

        while (true)
        {
            var data = reader.ReadLine();
            Thread.Sleep(350);
            Console.WriteLine($"Received : {data}");
        }

        client.Close();
    }

    #endregion

    #region asyncPipe

    /* static async Task Main(string[] args)
     {
         var pipeClient = new NamedPipeClientStream(".", "mypipe", PipeDirection.In);

         Console.WriteLine("Attempting to connect to pipe...");
         await pipeClient.ConnectAsync();
         Console.WriteLine("Connected to pipe.");

         var reader = new StreamReader(pipeClient);

         while (true)
         {
             var data = await reader.ReadLineAsync();
             var myList = JsonConvert.DeserializeObject<List<string>>(data);

             foreach (var item in myList)
             {
                 Console.WriteLine($"Received {item}");
             }

            */
    /* pipeClient.WaitForPipeDrain();*/ /*
         }
     }*/

    #endregion

    #region noAsyncPipe

    /* static void Main(string[] args)
     {
         var pipeClient = new NamedPipeClientStream(".", "mypipe", PipeDirection.In);

         Console.WriteLine("Attempting to connect to pipe...");
         pipeClient.Connect();
         Console.WriteLine("Connected to pipe.");

         var reader = new StreamReader(pipeClient);

         var data = reader.ReadLine();
         var myList = JsonConvert.DeserializeObject<List<string>>(data);

         foreach (var item in myList)
         {
             Thread.Sleep(350);
             Console.WriteLine($"Received {item}");
         }

         pipeClient.Close();
     }
 */

    #endregion
}