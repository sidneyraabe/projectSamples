using NounManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NounManager
{
    class Program
    {
        static void Main(string[] args)
        {
            NounController controller = new NounController();
            controller.Run();
        }
    }
}
