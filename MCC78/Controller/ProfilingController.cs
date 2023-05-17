using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC78.Model;

namespace MCC78.Controller
{
    public class ProfilingController
    {
        public void Get()
        {
            var profilings = new Profilings();
            var result = Profilings.InsertProfiling(profilings);

            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }
        }
    }
}
