using client.abstracts;
using client.constants;

namespace client.concretes
{
    internal class dataGenerator :IGenerator
    {
        #region noyield
        /*     public List<string> Generate()
            {
                List<string> myString = new List<string>();
                for (;;)
                {
                   var randomIndex= Random.Shared.Next(MyConstants.AllChars.Length);
                   char randomChar = MyConstants.AllChars[randomIndex];
                   myString.Append(randomChar.ToString());
                }

                return myString;
            }*/


        #endregion
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

        #endregion


    }
}
