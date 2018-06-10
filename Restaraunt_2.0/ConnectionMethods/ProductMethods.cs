using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBaseLibraryEntiti.Entities;
using LibraryEntities;

namespace EntityMethods
{
     static public class ProductMethods 
    {
        static public bool AddItem(Product item)
        {
            return ConnectionToDateBase.Unit.ProductsRepository.AddItem(ConnectionToDateBase.Convert.NewProductEnt(item));
        }
        static public bool AddItems(IEnumerable<Product> items)
        {
            List<ProductEnt> productEnts= new List<ProductEnt>();
            foreach (var x in items)
            {
                productEnts.Add(ConnectionToDateBase.Convert.NewProductEnt(x));
            }
            return ConnectionToDateBase.Unit.ProductsRepository.AddItems(productEnts);
        }
        static public bool ChangeItem(Product item)
        {
            return ConnectionToDateBase.Unit.ProductsRepository.ChangeItem(ConnectionToDateBase.Convert.NewProductEnt(item));
        }
        static public bool DeleteItem(int id)
        {
            return ConnectionToDateBase.Unit.ProductsRepository.DeleteItem(id);
        }
        static public Product GetItem(int id)
        {
            Product product = ConnectionToDateBase.Convert.NewProduct(ConnectionToDateBase.Unit.ProductsRepository.GetItem(id));
            return product;
        }
        static public List<Product> Outpoot()
        {
            List<ProductEnt> productEnts = ConnectionToDateBase.Unit.ProductsRepository.AllItems.ToList();
            List<Product> products = new List<Product>();
            foreach (var p in productEnts)
            {
              Product product = ConnectionToDateBase.Convert.NewProduct(p);
               products.Add(product);
            }
            return products;
        }
    }
}
