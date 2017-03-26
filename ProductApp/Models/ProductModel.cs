using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public double? Value { get; set; }
        public double? Cost { get; set; }
        public DateTime CreatedDate { get; set; }

        public ProductRepository.ProductModel ToRepositoryModel()
        {
            var repositoryModel = new ProductRepository.ProductModel
            {
                Id=Id,
                Number=Number.Value,
                Description=Description,
                Price=Price.Value,
                Quantity=Quantity.Value,
                Value=Value.Value,
                Cost=Cost.Value,
                CreatedDate=CreatedDate,               
            };

            return repositoryModel;
        }

        public static ProductModel ToModel(ProductRepository.ProductModel respositoryModel)
        {
            var productModel = new ProductModel
            {
                Id=respositoryModel.Id,
                Number=respositoryModel.Number,
                Description=respositoryModel.Description,
                Price=respositoryModel.Price,
                Quantity=respositoryModel.Quantity,
                Value=respositoryModel.Value,
                Cost=respositoryModel.Cost,
                CreatedDate=respositoryModel.CreatedDate,
            };

            return productModel;
        }
    }
}
