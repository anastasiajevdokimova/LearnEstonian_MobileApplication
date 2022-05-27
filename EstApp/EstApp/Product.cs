using SQLite;

namespace EstApp
{
    [Table("Words")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EstWord { get; set; }
        public string EngWord { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int Completed { get; set; }
    }
}
