﻿using NoteApps.Model;
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
        public NoteVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewNoteCommand(NoteVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            if (selectedNotebook != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;

            //TODO: Create new note
            VM.CreateNote(selectedNotebook.Id);
        }
    }
}