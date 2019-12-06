using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;//important(Tuong)

namespace Notes_App.ViewModel
{
    public class DatabaseHelper
    {
        //dbFile will save in current Directory of the sortware so you can easily will it(Tuong)
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "noteDB.db3");
        //using static so we can easily access it without having create an instance of the database helper class (Tuong)
        //<T> is generic method
        public static bool Insert<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn= new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberofRows=conn.Insert(item);
                if(numberofRows >0)
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberofRows = conn.Update(item);
                if (numberofRows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool Detele<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int numberofRows = conn.Delete(item);
                if (numberofRows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
