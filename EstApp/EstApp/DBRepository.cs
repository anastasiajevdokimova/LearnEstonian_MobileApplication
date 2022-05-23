using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstApp
{
    public class DBRepository
    {
        SQLiteConnection database;

        public DBRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<DataBase>();
        }
    }
}
