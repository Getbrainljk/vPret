using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Collections.Specialized;
using Pret;
using vPret;

namespace Vpret
{
    // User singelton
    public class UserManager
    {
        public string Username { get; set; }
        public int Right { get; set; }
        public int Id { get ; set; }
        private static readonly Lazy<UserManager > lazyInstance = new Lazy<UserManager>(() => new UserManager());
        public static UserManager currentUser{ get { return lazyInstance.Value; } }


        public Dictionary<string, int> Users;

        public UserManager()
        {
            Log.UserManager.Debug("UserManager()");

            Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Username = trimUserName(Username);
            Right = checkRight(Username);

        }

        public int checkRight(string username)
        {
            Log.UserManager.Debug("checkRight()");

            USER user = (from USER in VpretContext.Instance.vPretContext.USER
                         where (USER.USE_USERNAME.ToUpper()).Equals(username.ToUpper())
                         select USER).Single();
            Id = user.USE_ID;
            Log.UserManager.Info("User " + Username + " has " + Right.ToString() + " as right");
           if (user != null)
             if (user.USE_RIGHT != 0)
                 return user.USE_RIGHT;
            return 0;
        }
        // because Username of all ving user are of the type VINGEN****\USERNAME
        private static string trimUserName(string linkedUsername)
        {
            Log.UserManager.Debug("trimUserName()");

            string newUsername = "";
            int index = linkedUsername.IndexOf("\\");
            if (index > 0)
                newUsername = linkedUsername.Substring(linkedUsername.IndexOf("\\") + 1);
            return newUsername;
        }
    }
}
