using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstApp
{
    public class DBRepository
    {
        SQLiteConnection database;
        private List<Product> products;
        Random random = new Random();
        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }

        public DBRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Product>();
            Products = new List<Product>();

            //Add items to list

            //Berry
            Products.Add(new Product { EstWord = "Maasikas", EngWord = "Strawberry", Category = "Berries", Image = "Strawberry.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Vaarikas", EngWord = "Raspberry", Category = "Berries", Image = "Raspberry.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Murakas", EngWord = "Blackberry", Category = "Berries", Image = "Blackberry.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Arbuus", EngWord = "Watermelon", Category = "Berries", Image = "Watermelon.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Jõhvikas", EngWord = "Cranberry", Category = "Berries", Image = "Cranberry.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Mustikas", EngWord = "Blueberry", Category = "Berries", Image = "Blueberry.jpg", Completed = 0 });

            //Fruit
            Products.Add(new Product { EstWord = "Õun", EngWord = "Apple", Category = "Fruits", Image = "Apple.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Pirn", EngWord = "Pear", Category = "Fruits", Image = "Pear.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Mango", EngWord = "Mango", Category = "Fruits", Image = "Mango.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Banaan", EngWord = "Banana", Category = "Fruits", Image = "Banana.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Ananas", EngWord = "Pineapple", Category = "Fruits", Image = "Pineapple.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Avokaado", EngWord = "Avocado", Category = "Fruits", Image = "Avocado.jpg", Completed = 0 });

            //Vegetables
            Products.Add(new Product { EstWord = "Kurk", EngWord = "Cucumber", Category = "Vegetables", Image = "Cucumber.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Tomat", EngWord = "Tomato", Category = "Vegetables", Image = "Tomato.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Kapsas", EngWord = "Cabbage", Category = "Vegetables", Image = "Cabbage.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Porgand", EngWord = "Carrot", Category = "Vegetables", Image = "Carrot.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Peet", EngWord = "Beet", Category = "Vegetables", Image = "Beet.jpg", Completed = 0 });
            Products.Add(new Product { EstWord = "Baklažaan", EngWord = "Eggplant", Category = "Vegetables", Image = "Eggplant.jpg", Completed = 0 });


            foreach (Product p in Products)
            {
                database.Insert(p);
            }
        }
        public IEnumerable<Product> GetItems()
        {
            return database.Table<Product>().ToList();
        }

        public Product GetCategoryItems(string category)
        {
            return Products.Find(x => x.Category == category);
        }
        public Product GetItem(int id)
        {
            return database.Get<Product>(id);
        }
        public Product GetRamdomItem()
        {
            int someRandomNumber = random.Next(1, Products.Count());
            return Products[someRandomNumber];
            //return database.Get<Product>(someRandomNumber);
        }
        public string GetRamdomString()
        {
            List<string> list = new List<string>{ "Melon", "Mustikas", "Viinamari", "Avacado", "Arbuus", "Paprika", "Kartul", "Porgand", "Lillkapsas", "Pippar" };
            int someRandomNumber = random.Next(1, list.Count());
            return list[someRandomNumber].ToString();
        }

    }
}