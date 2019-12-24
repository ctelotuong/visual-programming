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
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
