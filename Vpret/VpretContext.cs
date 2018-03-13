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
using USER;


namespace Vpret
{
    public class VpretContext
    {
      public DataClassesVpretDataContext vPretContext { get; private set; }

      private VpretContext()
        {
            var vPretConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Vpret.Properties.Settings.vPretConnectionString"].ConnectionString;
            vPretContext = new DataClassesVpretDataContext((string)vPretConnectionString);
        }

     private static readonly Lazy<VpretContext> lazyInstance = new Lazy<VpretContext>(() => new VpretContext());
     public static VpretContext Instance { get { return lazyInstance.Value; } }
        
    }
}

