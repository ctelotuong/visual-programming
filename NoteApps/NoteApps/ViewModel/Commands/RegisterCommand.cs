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
            // bởi vì người dùng chỉ cần nhấn nút register để đăng ký mà không cần ràng buộc gì nên luôn luôn sẽ được execute
            return true;
        }

        public void Execute(object parameter)
        {
           
        }
    }
}
