using Notes_App.Model_Creating_Classes_;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Notes_App.ViewModel.Commands
{
    public class New_Note_Command : ICommand
    {
        public Note_ViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged;
        public New_Note_Command(Note_ViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            Notebook_class selectedNotebook = parameter as Notebook_class;
            if(selectedNotebook !=null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Notebook_class selectedNotebook = parameter as Notebook_class;
            //Todo: create new notebook
        }
    }
}
