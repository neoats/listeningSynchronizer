using System.Net;
using System.Net.Sockets;
using server.abstracts;
using server.concretes;

namespace server;

class Program
{
    #region noAsyncTcp

    static void Main(string[] args)
    {
        IDataGenerator generator = new DataGenerator();
        IDataSender sender = new DataSender();
        ProgramRunner runnable = new ProgramRunner();
      
        var server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
        server.Start();
        Console.WriteLine("Waiting for client connection...");
       
        var client = server.AcceptTcpClient();
        Console.WriteLine("Client connected.");

        ProgramRunner.Runner((runner) =>
        {
            var data = generator.Generate(15, 50, 2000);
            runner.Wait();
            sender.SendData(client, data);
        }, 0.15, 1000);


        server.Stop();
    }
    


    #endregion

    #region asyncPipe

    /* static async Task Main(string[] args)
    {
        var pipeServer = new NamedPipeServerStream("mypipe");
        IGenerator generator = new dataGenerator();
        Console.WriteLine("Waiting for client connection...");
        await pipeServer.WaitForConnectionAsync();
        Console.WriteLine("Client connected.");

        while (true)
        {

            var myList = generator.Generate(15,100,20).ToList();
            var data = JsonConvert.SerializeObject(myList);

            using (StreamWriter writer = new StreamWriter(pipeServer) { AutoFlush = true })
            {
                await writer.WriteAsync(data);
                await writer.FlushAsync();
                foreach (var item in myList)
                {
                    Task.Delay(1000);
                    Console.WriteLine($"Sending : {item}");
                }

            }


        }

        pipeServer.Dispose();
    }
    */

    #endregion

    #region noAsyncPipe

    /*   
        static void Main(string[] args)
        {
            var pipeServer = new NamedPipeServerStream("mypipe");
            IGenerator generator = new dataGenerator();
            Console.WriteLine("Waiting for client connection...");
            pipeServer.WaitForConnection();
            Console.WriteLine("Client connected.");

            var myList = generator.Generate(15, 50, 20).ToList();


            var data = JsonConvert.SerializeObject(myList);

            var writer = new StreamWriter(pipeServer) { AutoFlush = true };

            writer.Write(data);
            foreach (var item in myList)
            {
                Thread.Sleep(350);
                Console.WriteLine($"Sending : {item}");
            }

        }*/

    #endregion
}