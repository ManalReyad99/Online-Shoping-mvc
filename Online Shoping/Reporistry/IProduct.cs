using Online_Shoping.Models;
using System.Collections.Generic;
namespace Online_Shoping.Reporistry
{
    public interface IProduct:IReporistry<Product>
    {
        Product GetById(int Id);
       List<Product> GetByCatogeryName(string CatogeryName);
    }
}
