using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstApp
{
    public class DBRepository
    {
        SQLiteConnection database;

        private List<Product> products;

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

        Product kapp;
        
        public Product Kapp
        {
            get
            {
                return kapp;
            }
            set
            {
                kapp = value;
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
            Products.Add(new Product { EstWord = "Vaarikas", EngWord = "Raspberry", Category = "Berries", Image = "img", Completed = 0 });
            Products.Add(new Product { EstWord = "Murakas", EngWord = "Blackberry", Category = "Berries", Image = "img", Completed = 0 });

            //Fruit
            Products.Add(new Product { EstWord = "Õun", EngWord = "Apple", Category = "Fruits", Image = "img", Completed = 0 });
            Products.Add(new Product { EstWord = "Pirn", EngWord = "Pear", Category = "Fruits", Image = "img", Completed = 0 });
            Products.Add(new Product { EstWord = "Mango", EngWord = "Mango", Category = "Fruits", Image = "img", Completed = 0 });

            //Vegetables
            Products.Add(new Product { EstWord = "Kurk", EngWord = "Cucumber", Category = "Vegetables", Image = "img", Completed = 0 });
            Products.Add(new Product { EstWord = "Tomat", EngWord = "Tomato", Category = "Vegetables", Image = "img", Completed = 0 });
            Products.Add(new Product { EstWord = "Kapsas", EngWord = "Cabbage", Category = "Vegetables", Image = "img", Completed = 0 });

            foreach (Product p in Products)
            {
                database.Insert(p);
            }
        }
        public IEnumerable<Product> GetItems()
        {
            return database.Table<Product>().ToList();
        }

        public Product GetItem(int id)
        {
            return database.Get<Product>(id);
        }

    }
}
