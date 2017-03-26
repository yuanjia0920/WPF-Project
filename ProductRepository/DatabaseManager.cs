using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDB;

namespace ProductRepository
{
    public class DatabaseManager
    {
        private static readonly ProductsEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ProductsEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static ProductsEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
