using NoteApps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApps.ViewModel.Commands
{
    public class HasEditingCommand : ICommand
    {
        //đã check hết
        public NoteVM VM { get; set; }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public HasEditingCommand(NoteVM vm)
        {
            VM = vm;

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            VM.HasRename(notebook);
            
        }
    }
}
