using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApps.ViewModel.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged;
        public NewNotebookCommand(NoteVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Todo: Create New Notebook
            VM.CreateNotebook();
        }
    }
}
