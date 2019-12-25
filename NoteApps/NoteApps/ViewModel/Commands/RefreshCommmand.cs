using NoteApps.Model;
using NoteApps.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApps.ViewModel.Commands
{
    public class RefreshCommmand : ICommand
    {
        public NoteVM ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;
        public RefreshCommmand (NoteVM vm)
        {
            this.ViewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var notebook = parameter as Notebook;

            if (notebook != null)
                ViewModel.Refresh();
        }
    }
}
