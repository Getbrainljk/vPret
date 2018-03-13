using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;
using Pret;
using vPret;

namespace Vpret
{
    /// <summary>
    ///  Connection with vPret 
    /// </summary>
    public class VpretContext
    {
      public VpretDataContext vPretContext { get; private set; }

      private VpretContext()
        {
            Log.VpretContext.Debug("VpretContext()");
            string vPretConnectionString = ConfigurationManager.ConnectionStrings["Pret.Properties.Settings.vPretConnectionString"].ConnectionString;
            vPretContext = new VpretDataContext((string)vPretConnectionString);
        }

     private static readonly Lazy<VpretContext> lazyInstance = new Lazy<VpretContext>(() => new VpretContext());
     public static VpretContext Instance { get { return lazyInstance.Value; } }

    }
}

