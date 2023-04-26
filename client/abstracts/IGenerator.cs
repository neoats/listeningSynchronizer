using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.abstracts
{
    internal interface IGenerator
    {
        IEnumerable<string> Generate(int maxChar, int delay);
    }
}
