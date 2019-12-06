using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Notes_App.Model_Creating_Classes_
{
    public class Note_class : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private int id_notebook;
        public int Id_notebook
        {
            get { return id_notebook; }
            set
            {
                id_notebook = value;
                OnPropertyChanged("Id_notebook");
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private DateTime created_Time;

        public DateTime Created_Time
        {
            get { return created_Time; }
            set
            {
                created_Time = value;
                OnPropertyChanged("Created_Time");
            }
        }
        private DateTime updated_Time;
        public DateTime Update_Time
        {
            get
            {
                return updated_Time;

            }
            set
            {
                updated_Time = value;
                OnPropertyChanged("Updated_Time");
            }
        }
        private string file_Location;
        public string File_Location
        {
            get
            {
                return file_Location;
            }
            set
            {
                file_Location = value;
                OnPropertyChanged("File_Location");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
