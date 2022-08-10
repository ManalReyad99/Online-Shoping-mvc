using Online_Shoping.Models;
using System.Collections.Generic;
using System.Linq;

namespace Online_Shoping.Reporistry
{
    public class ProductReporistry : IProduct
    {
        Context context;
        public ProductReporistry(Context c)
        {
            context = c;
        }
        public int delete(int id)
        {
            Product product = GetById(id);
            if (product != null)
            { 
            context.products.Remove(product);
                return context.SaveChanges();
        }
            return 0;
        }

        public List<Product> GetAll()
        {
            return context.products.ToList();
        }

        public List<Product> GetByCatogeryName(string CatogeryName)
        {
            return context.products.Where ( p => p.category.name == CatogeryName ).ToList();
            
        }

        public Product GetById(int Id)
        {
            return context.products.FirstOrDefault(p => p.id == Id);
                
        }

        public int insert(Product item)
        {
            if (item != null)
            {
                context.products.Add(item);
                return context.SaveChanges();
            }
            return 0;
        }

        public int update(int Id, Product item)
        {
            Product product = context.products.FirstOrDefault(p => p.id == Id);
            if(product!=null)
            {
                product.image = item.image;
                product.name = item.name;
                product.price = item.price;
                product.quantity = item.quantity;
                return context.SaveChanges();
            }
            return 0;


        }
    }
}
