using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes_App.Model_Creating_Classes_;
using Notes_App.ViewModel;
using Notes_App.ViewModel.Commands;

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
        public Login_Command Login_Command { get; set; }
        public Register_Command Register_Command { get; set; }
        public Login_ViewModel()
        {
            Register_Command = new Register_Command(this);
            Login_Command = new Login_Command(this);
        }
    }
}
