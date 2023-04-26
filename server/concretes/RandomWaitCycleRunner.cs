using server.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.concretes
{
    public class RandomWaitCycleRunner : IRunnable
    {
        public void Wait()
        {
          
            int sleepTime = GetRandomSleepTime();
            Thread.Sleep(sleepTime);

        }

        private int GetRandomSleepTime()
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

    }
}
