using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notes_App.ViewModel.Commands
{
    public class New_Notebook_Command : ICommand
    {
        public Note_ViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged;
        public New_Notebook_Command(Note_ViewModel vm)
        {
            VM = vm;
        }
            
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Todo: create new notebook
        }
    }
}
