using NoteApps.Model;
using NoteApps.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApps.ViewModel
{
    //đây là class sẽ binding đến LoginWindow
    public class LoginVM
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }
        //đây là 1 property 
        public RegisterCommand RegisterCommand { get; set; }
        //đây là 1 property
        public LoginCommand LoginCommand { get; set; }
        //đây là 1 contructor
        public LoginVM()
        {
            //this truyền vào là instance LoginVM
            RegisterCommand = new RegisterCommand(this);
            //this truyền vào là instance LoginVM
            LoginCommand = new LoginCommand(this);
        }
    }
    //chúng ta sẽ cần 1 nut login và 1 nút regiter. Chúng ta sẽ cho user khi click vào button thì chuyển từ stacked panel sang cái khác
    // pannel kia sẽ được giấu và 1 cái pannel khác sẽ được hiển thị 
}
