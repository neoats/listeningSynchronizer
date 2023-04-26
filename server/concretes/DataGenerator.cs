using server.abstracts;
using server.constants;

namespace server.concretes
{
    public class DataGenerator :IDataGenerator
    {
       
        #region yieldOneChar
        /*  public IEnumerable<string> Generate()
          {
              while (true)
              {
                  int randomIndex = Random.Shared.Next(MyConstants.AllChars.Length);
                  char randomChar = MyConstants.AllChars[randomIndex];
                  yield return randomChar.ToString();
              }
          }
  */

        #endregion
        #region yieldMultiChar
        public IEnumerable<string> Generate(int maxChar,int delay)
        {
            while (true)
            {
                Thread.Sleep(delay);
                var randomChars = Enumerable.Range(0, Random.Shared.Next(0, maxChar))
                    .Select(x => MyConstants.AllChars[Random.Shared.Next(MyConstants.AllChars.Length)])
                    .ToArray();
                yield return new string(randomChars);
            }
        }
        public IEnumerable<string> Generate(int maxChar, int delay, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(delay);
                var randomChars = Enumerable.Range(0, Random.Shared.Next(0, maxChar))
                    .Select(x => MyConstants.AllChars[Random.Shared.Next(MyConstants.AllChars.Length)])
                    .ToArray();
              
                yield return new string(randomChars);
               
            }
        }

        #endregion


    }
}
