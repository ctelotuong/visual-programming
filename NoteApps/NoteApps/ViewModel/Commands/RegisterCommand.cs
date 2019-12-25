using NoteApps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NoteApps.ViewModel.Commands
{
    //đây là class dùng để xử lý những sự kiện từ button Register.
    public class RegisterCommand : ICommand
    {
        //đã check hết
        //đây là 1 property
        public LoginVM VM { get; set; }
        public event EventHandler CanExecuteChanged;
        //constructor mà gia trị truyền vào là vm
        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            var user = parameter as User;
            //if (user == null)
            //    return false;
            //if (string.IsNullOrEmpty(user.Username))
            //    return false;
            //if (string.IsNullOrEmpty(user.Password))
            //    return false;
            //if (string.IsNullOrEmpty(user.Email))
            //    return false;
            //if (string.IsNullOrEmpty(user.Lastname))
            //    return false;
            //if (string.IsNullOrEmpty(user.Name))
            //    return false;
            // bởi vì người dùng chỉ cần nhấn nút register để đăng ký mà không cần ràng buộc gì nên luôn luôn sẽ được execute
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Register();
        }
    }
}
