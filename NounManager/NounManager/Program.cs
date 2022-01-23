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
        //Acts as a Pass Thru to The Main Program Functionality in the Controller
        static void Main(string[] args)
        {
            NounController controller = new NounController();
            controller.Run();
        }
    }
}
