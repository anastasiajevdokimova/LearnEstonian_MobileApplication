using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstApp
{
    [Table("Words")]
    public class DataBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EstWord { get; set; }
        public string EngWord { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int Compl { get; set; }
    }
}
