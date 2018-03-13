using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using USER;
using System.Collections.Specialized;


namespace Vpret
{
 // note futur : Add user  with 0 right if non existant
    public class UserManager
    {
        public string Username { get; set; }
        public int Right { get; set; }

        public Dictionary<string, int> Users;

        public UserManager()
        { 
            Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Username = trimUserName(Username);
            Right = getRightAccess(Username);

        }

        // because Windows username of all ving user are of the type VINGEN****\USERNAME
        private static string trimUserName(string linkedUsername)
        {
            string newUsername;
            
            int index = linkedUsername.IndexOf("\\");
         
            if (index > 0)
                newUsername = linkedUsername.Substring(linkedUsername.IndexOf("\\") + 1);
            else
                newUsername = "Touriste";
            return newUsername;
        }

        private static int getRightAccess(string Username)
        {
            /*
            var access = (from user in 
                             select new VisualisationPret
                             {
                                 NumLp = sdelivery.SDHNUM_0,
                                 NumCp = sdelivery.SOHNUM_0,
                                 DateRetour = sdelivery.LNDRTNDAT_0,
                                 Client = sdelivery.BPINAM_0,
                                 NumClient = sdelivery.BPINAM_0, 
                             }).Distinct();
          * */

            return 1;
        }
        
        public int checkRight(string username)
        {
            var users = (from USER in VpretContext.Instance.vPretContext.USER
                         where (USER.USERNAME.ToUpper()).Equals(username.ToUpper())
                         select USER);
            foreach (var user in users)
                return user.RIGHT;
            return 0;
        }
        
        private void doAlertbyMail()
        {

        }
    }
}
