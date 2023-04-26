using server.abstracts;

namespace server.concretes;

public class ProgramRunner
{
    public static void Runner(Action<IRunnable> newMethod, double probability, int sleepTime)
    {
        while (true)
        {
            Thread.Sleep(sleepTime);
            Console.WriteLine("\n[Waiting]\n");
            if (Random.Shared.NextDouble() < probability)
            {
                var runner = new RandomWaitCycleRunner();
                newMethod(runner);
            }

        }
    }
}