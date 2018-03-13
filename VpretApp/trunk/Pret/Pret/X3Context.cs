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
    ///  Connection with x3
    /// </summary>
    public class X3Context
        {
        public VpretDataContext x3context { get; private set; }

            private X3Context()
            {
                Log.X3Context.Debug("X3Context()");
                string x3ConnectionString = ConfigurationManager.ConnectionStrings["Pret.Properties.Settings.x3v5sConnectionString"].ConnectionString;
                x3context = new VpretDataContext(x3ConnectionString);
            }

            private static readonly Lazy<X3Context> lazyInstance = new Lazy<X3Context>(() => new X3Context());
            public static X3Context Instance { get { return lazyInstance.Value; } }

        }
}
