using NoteApps.Model;
using NoteApps.ViewModel.Commands;
using NotesApp.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApps.ViewModel
{
    public class NoteVM : INotifyPropertyChanged
    {
        private bool isEditing;
        //đã check
        public bool IsEditing
        {
            get { return isEditing; }
            set 
            { 
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }
        public ObservableCollection<Notebook> Notebooks { get; set; }
        private Notebook selectedNotebook;
        //chúng ta cần phải list notebook và list note
        //cần command là create new note và create new notebook
        // Đây là 1 property Notebook. Chúng ta sử dụng ObservableCollection vì khi có thay đổi gì trong list thì nó sẽ thông báo
        //đã check
        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                //TODO: get notes
                ReadNote();
                OnPropertyChanged("SelectedNotebook");
            }
        }

        private Note note;
        //đã check
        public Note SelectedNote
        {
            get { return note; }
            set
            {
                note = value;
                SelectedNoteChanged(this, new EventArgs());
                OnPropertyChanged("SelectedNote");
            }
        }
        public ObservableCollection<Note> Notes { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public BeginEditCommand BeginEditCommand { get; set; }
        public HasEditingCommand HasEditingCommand { get; set; }
        public DeleteNotebookCommand DeleteNotebookCommand { get; set; }
        public RefreshCommmand RefreshCommmand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        //Event chọn note khác
        public event EventHandler SelectedNoteChanged;
        //event chọn notebook khác
        public event EventHandler SelectedNotebookChanged;
        //đã check
        public NoteVM()
        {
            //TODO:
            IsEditing = false;
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            BeginEditCommand = new BeginEditCommand(this);
            HasEditingCommand = new HasEditingCommand(this);
            DeleteNotebookCommand = new DeleteNotebookCommand(this);
            RefreshCommmand = new RefreshCommmand(this);
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            //chú thích lỗi nếu người dùng chưa tạo notebook nào thì dòng này không được thức hiện
            ReadNotebooks();
            ReadNote();
        }
        //đã check
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //đã check thêm try catch
        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook",
                UserId = App.UserID
            };
            try
            {
                DatabaseHelper.Insert(newNotebook);
            }
            catch(Exception ex)
            {

            }
            ReadNotebooks();
        }
        //đã check và thêm try catch
        public void CreateNote(string notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title="New note"
            };
            try
            {
                DatabaseHelper.Insert(newNote);
            }
            catch (Exception ex)
            {

            }
            ReadNote();
        }
        //đã check hết
        public  void ReadNotebooks()
        {
            
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                try
                {
                    //truy cập vào database và gán notebooks 1 list các notebook
                    var notebooks =  conn.Table<Notebook>().Where(n => n.UserId == App.UserID).ToList();
                    //mỗi khi chúng ta đọc notebooks thì sẽ không bị nhân đôi lên
                    
                    Notebooks.Clear();
                    foreach (var notebook in notebooks)
                    {
                        Notebooks.Add(notebook);
                    }
                }
                catch
                {

                }

            }
        }
        //đã check hết
        public void ReadNote()
        {
            try
            {

                try
                {
                    using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
                    {
                        if (SelectedNotebook != null)
                        {
                            //truy cập vào database tại nơi mà NotebookId giống với Notebook mình đang select và gán notes là 1 list các note
                            var notes = conn.Table<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
                            Notes.Clear();
                            //duyệt mảng notes
                            foreach (var note in notes)
                            {
                                Notes.Add(note);

                            }
                        }
                    }
                }
                catch
                {

                }
            }
            catch
            {

            }
        }
        //đã check
        public void StartEditing()
        {
            IsEditing = true;
            
        }
        //đã check
        public void HasRename(Notebook notebook)
        {
            if(notebook!= null)
            {
                try
                {
                    try
                    {
                        DatabaseHelper.Update(notebook);
                    }
                    catch
                    {

                    }
                    IsEditing = false;
                    ReadNotebooks();

                }
                catch(Exception ex)
                {

                }
            }
            
        }
        //đã check
        public void UpdateSelectedNote()
        {
            DatabaseHelper.Update(SelectedNote);
        }
        public void DeleteNotebook(Notebook notebook)
        {
            try
            {
                DatabaseHelper.Delete(notebook);
                ReadNotebooks();
            }
            catch
            {

            }
        }
        public void Refresh()
        {
            try
            {
                
                ReadNotebooks();
            }
            catch
            {

            }
        }
    }

}
