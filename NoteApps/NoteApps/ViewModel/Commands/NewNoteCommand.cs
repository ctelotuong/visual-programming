using NoteApps.Model;
using NoteApps.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace NotesApp.ViewModel.Commands
{
    public class NewNoteCommand : ICommand
    {
        //đã check hết
        public NoteVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            // Dòng này dùng để refesh parameter truyền vào ở CanExecute ở dưới. Parameter sẽ luôn luôn được cập nhật không chỉ nhật 1 giá trị duy nhất và không thay đổi
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        
        }

        public NewNoteCommand(NoteVM vm)
        {
            VM = vm;
        }

        
        public bool CanExecute(object parameter)
        {

            Notebook selectedNotebook = parameter as Notebook;
            if (selectedNotebook != null)
                return true;
            else
            {
                CommandManager.InvalidateRequerySuggested();
                return false;
            }
            

        }


        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;

            //TODO: Create new note
            VM.CreateNote(selectedNotebook.Id);
        }
    }
}