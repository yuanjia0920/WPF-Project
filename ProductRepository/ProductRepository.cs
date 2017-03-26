using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDB;

namespace ProductRepository
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public double Cost { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
    public class ProductRepository
    {
        public ProductModel Add(ProductModel productModel)
        {
            var productDb = ToDbModel(productModel);

            DatabaseManager.Instance.Products.Add(productDb);
            DatabaseManager.Instance.SaveChanges();

            productModel = new ProductModel
            {
                Id =productDb.ItemId,
                Number=productDb.ItemNumber,
                Description=productDb.ItemDescription,
                Price=productDb.ItemPrice,
                Quantity=productDb.ItemQuantity,
                Value=productDb.ItemValue,
                Cost=productDb.ItemCost,
                CreatedDate=productDb.ItemCreatedDate,
            };
            return productModel;
        }

        public List<ProductModel> GetAll()
        {
            // Use .Select() to map the database products to ProductModel
            var items = DatabaseManager.Instance.Products.Select(t => new ProductModel
            {
                Id = t.ItemId,
                Number = t.ItemNumber,
                Description = t.ItemDescription,
                Price = t.ItemPrice,
                Quantity = t.ItemQuantity,
                Value = t.ItemValue,
                Cost = t.ItemCost,
                CreatedDate = t.ItemCreatedDate,
            }).ToList();
            return items;
        }

        public bool Update(ProductModel productModel)
        {
            var original = DatabaseManager.Instance.Products.Find(productModel.Id);

            if(original!=null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(productModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool Remove(int productId)
        {
            var items = DatabaseManager.Instance.Products.Where(t => t.ItemId == productId);

            if(items.Count()==0)
            {
                return false;
            }

            DatabaseManager.Instance.Products.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Product ToDbModel(ProductModel productModel)
        {
            var productDb = new Product
            {
                ItemId=productModel.Id,
                ItemNumber=productModel.Number,
                ItemDescription=productModel.Description,
                ItemPrice=productModel.Price,
                ItemQuantity=productModel.Quantity,
                ItemValue=productModel.Value,
                ItemCost=productModel.Cost,
                ItemCreatedDate=productModel.CreatedDate,
            };

            return productDb;
        }
    }
}
