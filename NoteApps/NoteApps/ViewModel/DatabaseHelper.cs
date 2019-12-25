using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApps.ViewModel
{
    //class nay dùng để insert và load data từ Model
   public class DatabaseHelper
    {
        //đã check hết
        // Đây là địa chỉ lưu file. Path là dùng để thao tác với file, Path.Combine là gộp nhiều string lại và trả về 1 đường dẫn duy nhất
        public static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");
        // <T> ở đây là một generic method, và T sẽ là động và không bị ràng buộc bởi kiểu dữ liệu. Đây là hàm insert dữ liệu
        public static bool Insert<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberOfRows=conn.Insert(item);
                // nếu có insert thì return là true
                if (numberOfRows > 0)
                    result= true;
            }
            return result;
        }
        // đây là hàm Update dữ liệu
        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberOfRows=conn.Update(item);
                // nếu có update thì return là true
                if (numberOfRows > 0)
                    result= true;
            }
            return result;
        }
        //đây là hàm delete dữ liệu
        public static bool Delete<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
               int numberOfRows=conn.Delete(item);
                //nếu có delete thì return là true
                if (numberOfRows > 0)
                    result= true;
            }
            return result;
        }
    }
}
