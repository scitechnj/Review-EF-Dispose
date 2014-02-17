using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            var logger = LogManager.GetLogger(typeof(Program));
            logger.Info("This is a test message");
            try
            {
                int x = 0;
                int y = 10/x;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            Console.ReadKey(true);
        }
    }
}
