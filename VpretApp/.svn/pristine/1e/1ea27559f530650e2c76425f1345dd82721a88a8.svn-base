using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Windows.Forms;

// Get the configuration of the logs
[assembly: XmlConfigurator(ConfigFile =  "vPret.exe.config", Watch = true)]
namespace vPret
{
    /// <summary>
    /// Contain all loggers which use the Log class
    /// </summary>
    public static class Log
    {
        
        public static ILog Program
        {
            get { return LogManager.GetLogger("Program"); }
        }
        public static ILog Vpret
        {
            get { return LogManager.GetLogger("Vpret"); }
        }
        public static ILog UCF
        {
            get { return LogManager.GetLogger("UCF"); }
        }
        public static ILog UCTechReception
        {
            get { return LogManager.GetLogger("UCTechReception"); }
        }
        public static ILog UCTechControle
        {
            get { return LogManager.GetLogger("UCTechControle"); }
        }
        public static ILog DialogCommentaire
        {
            get { return LogManager.GetLogger("DialogCommentaire"); }
        }
        public static ILog UCRP
        {
            get { return LogManager.GetLogger("UCRP"); }
        }
        public static ILog UserManager
        {
            get { return LogManager.GetLogger("UserManager"); }
        }
        public static ILog VpretContext
        {
            get { return LogManager.GetLogger("VpretContext"); }
        }
        public static ILog X3Context
        {
            get { return LogManager.GetLogger("X3Context"); }
        }
        public static ILog ReportLoan
        {
            get { return LogManager.GetLogger("ReportLoan"); }
        }
    }
}

