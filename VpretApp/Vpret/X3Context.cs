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
    public class X3Context
        {
            public DataClassesVpretDataContext x3context { get; private set; }

            private X3Context()
            {
                string x3ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Vpret.Properties.Settings.x3v5sConnectionString"].ConnectionString;
                x3context = new DataClassesVpretDataContext(x3ConnectionString);
            }

            private static readonly Lazy<X3Context> lazyInstance = new Lazy<X3Context>(() => new X3Context());
            public static X3
                Instance { get { return lazyInstance.Value; } }

        }
}
