using NoteApps.Model;
using NoteApps.ViewModel.Commands;
using NotesApp.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApps.ViewModel
{
    public class NoteVM
    {
        //chúng ta cần phải list notebook và list note
        //cần command là create new note và create new notebook
        // Đây là 1 property Notebook. Chúng ta sử dụng ObservableCollection vì khi có thay đổi gì trong list thì nó sẽ thông báo
        public ObservableCollection<Notebook> Notebooks { get; set; }
        private Notebook selectedNotebook;
        public Notebook SelectedNotebook
        {
            get { return selectedNotebook;}
            set
            {
                selectedNotebook = value;
                //TODO: get notes
            }
        }
        public ObservableCollection<Note> Notes { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public NoteVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            //chú thích lỗi nếu người dùng chưa tạo notebook nào thì dòng này không được thức hiện
            ReadNotebooks();
        }
        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook"
            };
            DatabaseHelper.Insert(newNotebook);
        }
        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title="New note"
            };
            DatabaseHelper.Insert(newNote);
        }
        public void ReadNotebooks()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                //truy cập vào database và gán notebooks 1 list các notebook
                var notebooks = conn.Table<Notebook>().ToList();
                //mỗi khi chúng ta đọc notebooks thì sẽ không bị nhân đôi lên
                Notebooks.Clear();
                foreach(var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
            }
        }
        public void ReadNote()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (SelectedNotebook != null)
                {
                    //truy cập vào database tại nơi mà NotebookId giống với Notebook mình đang select và gán notes là 1 list các note
                    var notes = conn.Table<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
                    Notes.Clear();
                    //duyệt mảng notes
                    foreach(var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
            }
        }
    }
}
