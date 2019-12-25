using NoteApps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApps.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        //đã check hết
        //đây là 1 property
        public LoginVM VM { get; set; }
        public event EventHandler CanExecuteChanged;
        //đây là 1 contructor
        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            var user = parameter as User;
            //if (user != null)
            // return false;
            //    if (string.IsNullOrEmpty(user.Username))
            //        return false;
            //    if (string.IsNullOrEmpty(user.Password))
            //        return false;
            
                return true;
            
        }

        public void Execute(object parameter)
        {
            VM.Login();
        }
    }
}
