using EntityBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitDb;

namespace Methods
{
   public class PurchasedProducts
    {
        public int Id { get; set; }
        public ProductEnt Product { get; set; }
        public decimal Price { get; set; }
        public PurchasedProducts(PurchasedProductEnt purchased)
        {
            Id = purchased.Id;
            Product = purchased.Product;
            Price = purchased.Price;
        }
        void AddPurchasedProducts(ProductEnt product, decimal price)
        {
            PurchasedProductEnt purchasedProduct = new PurchasedProductEnt(product, price);
            Unit.PurchaserProdutsRepository.AddItem(purchasedProduct);
        }
        void PurchasedProductsDelete(int id)
        {
            Unit.PurchaserProdutsRepository.DeleteItem(id);
        }
        List<PurchasedProducts> PurchasedProductsOutpoot()
        {
            List<PurchasedProductEnt> purchasedProductEnts = Unit.PurchaserProdutsRepository.AllItems.ToList();
            List<PurchasedProducts> purchasedProductsList = new List<PurchasedProducts>();
            foreach (var p in purchasedProductEnts)
            {
                PurchasedProducts purchased = new PurchasedProducts(p);
                purchasedProductsList.Add(purchased);
            }
            return purchasedProductsList;
        }
    }
}
