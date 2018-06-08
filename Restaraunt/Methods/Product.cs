using EntityBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public UnitWeight UnitWeight { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Product(int id, string name, decimal weight, UnitWeight unitWeight)
        {
            Name = name;
            Weight = weight;
            UnitWeight = unitWeight;
            DeliveryDate = DateTime.Now;
        }
        public Product(ProductEnt product)
        {
            Id = product.Id;
            Name = product.Name;
            Weight = product.Weight;
            UnitWeight = new UnitWeight(product.UnitWeight);
        }
        void AddProduct(string name, decimal weight, UnitWeight unitWeight)
        {
            ProductEnt product = new ProductEnt(name, weight, new UnitWeightEnt(unitWeight.Units));
            Unit.ProductsRepository.AddItem(product);
        }
        void DeleteProduct(int id)
        {
            Unit.ProductsRepository.DeleteItem(id);
        }
        List<Product> ProductOutpoot()
        {
            List<ProductEnt> product = Unit.ProductsRepository.AllItems.ToList();
            List<Product> products = new List<Product>();
            foreach (var p in product)
            {
                Product prod = new Product(p);
                products.Add(prod);
            }
            return products;
        }

    }
}
