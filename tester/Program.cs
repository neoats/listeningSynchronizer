namespace empty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double probability = 0.15;


            RunProgram(RandomWaitCycle, probability, 200);

            #region actionSample
            /*    Action method = new Action(delegate {
                    Console.WriteLine("x"); Console.WriteLine("y");
                });
                method();*/


            #endregion


        }
        static void RunProgram(Action newMethod, double probability, int sleepTime)
        {
            while (true)
            {
                Thread.Sleep(sleepTime);

                if (Random.Shared.NextDouble() < probability)
                {
                    newMethod();
                }

                Console.WriteLine(Random.Shared.Next(0, 999));
            }
        }

        static int GetRandomSleepTime()
        {
            int previousRandom = -1;
            int currentRandom = Random.Shared.Next(5, 30) * 450;

            if (previousRandom > 20)
            {
                for (int i = 0; i < Random.Shared.Next(5, 10); i++)
                {
                    currentRandom = Random.Shared.Next(1, 10) * 450;
                }
            }

            return currentRandom;
        }

        static void RandomWaitCycle()
        {
          
            Console.WriteLine("\n[Waiting]\n");
            int sleepTime = GetRandomSleepTime();
            Thread.Sleep(sleepTime);
        }
    }
}