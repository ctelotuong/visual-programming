using NoteApps.Model;
using NoteApps.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApps.ViewModel
{
    //đây là class sẽ binding đến LoginWindow
    public class LoginVM
    {
        private User user;
        //đã check
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        //đây là 1 property 
        public RegisterCommand RegisterCommand { get; set; }
        //đây là 1 property
        public LoginCommand LoginCommand { get; set; }
        public event EventHandler HasLogIn;
        //đây là 1 contructor
        //đã check
        public LoginVM()
        {
            User = new User();
            //this truyền vào là instance LoginVM
            RegisterCommand = new RegisterCommand(this);
            //this truyền vào là instance LoginVM
            LoginCommand = new LoginCommand(this);
        }
        //đã check.Thêm try catch nếu nhập không đúng thì không vào
        public void Login()
        {
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
                {
                    conn.CreateTable<User>();
                    var user = conn.Table<User>().Where(u => u.Username == User.Username).FirstOrDefault();
                    if (user.Password == User.Password)
                    {
                        App.UserID = user.Id.ToString();
                        HasLogIn(this, new EventArgs());
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        //đã check y chang login
        public void Register()
        {
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
                {
                    conn.CreateTable<User>();
                    var result = DatabaseHelper.Insert(User);
                    if (result)
                    {
                        //TODO:
                        App.UserID = User.Id.ToString();
                        HasLogIn(this, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    //chúng ta sẽ cần 1 nut login và 1 nút regiter. Chúng ta sẽ cho user khi click vào button thì chuyển từ stacked panel sang cái khác
    // pannel kia sẽ được giấu và 1 cái pannel khác sẽ được hiển thị 
}
