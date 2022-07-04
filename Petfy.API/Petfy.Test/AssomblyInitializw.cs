using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Test
{
    
    public class Assombly
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext context)
        {
            
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup(TestContext context)
        {

        }
    }
}
