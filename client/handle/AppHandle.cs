namespace client.handle
{
    public class AppHandle
    {
        private int appId;
        private bool isRunning;
        private bool isPaused;
        private Thread thread;

        public AppHandle(int id)
        {
            this.appId = id;
            this.isRunning = true;
            this.isPaused = false;
            this.thread = new Thread(this.Run);
        }

        public void Run()
        {
            while (this.isRunning)
            {
                if (!this.isPaused)
                {
                    this.ProduceData();
                }
                Thread.Sleep(new Random().Next(800, 900));
            }
        }

        public void ProduceData()
        {
            int data = new Random().Next(0, 10);
            Console.WriteLine($"App {this.appId} produced data: {data}");
        }

        public void Pause()
        {
            this.isPaused = true;
        }

        public void Resume()
        {
            this.isPaused = false;
        }

        public void Start()
        {
            this.thread.Start();
        }

        public void Stop()
        {
            this.isRunning = false;
            this.thread.Join();
        }
    }
}
