using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes_App.Model_Creating_Classes_;

namespace Notes_App.ViewModel
{
   public class Login_ViewModel
    {
        private User_HomePage user;
        public User_HomePage User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

    }
}
