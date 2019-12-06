using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notes_App.ViewModel.Commands
{
    //using Icommand interface
    public class Register_Command : ICommand
    {
        public Login_ViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged;
        public Register_Command (Login_ViewModel vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
        }
    }
}
