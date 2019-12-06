using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Notes_App.Model_Creating_Classes_;
using Notes_App.ViewModel.Commands;

namespace Notes_App.ViewModel
{
    public class Note_ViewModel
    {
        public ObservableCollection<Notebook_class> Notebook_class
        {
            get; set;
        }
        private Notebook_class selected_Notebook;

        public Notebook_class Selected_Notebook
        {
            get { return selected_Notebook; }
            set 
            { 
                selected_Notebook = value; 
                //TODO: get notes
            }
        }
        public ObservableCollection<Note_class> Note_class
        {
            get; set;
        }
        public New_Notebook_Command New_Notebook_Command { get; set; }
        public New_Note_Command New_Note_Command { get; set; }

        public Note_ViewModel()
        {
            New_Notebook_Command = new New_Notebook_Command(this);
            New_Note_Command = new New_Note_Command(this);
        }
    }
}
