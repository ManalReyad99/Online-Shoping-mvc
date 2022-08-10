using Online_Shoping.Models;
using System.Collections.Generic;
using System.Linq;

namespace Online_Shoping.Reporistry
{
    public class CatogeryReporsitry : ICatogory
    {
        Context context;
        public CatogeryReporsitry(Context c)
        {
            context = c;
        }
        public int delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return context.categories.ToList();
        }

        public int insert(Category item)
        {
            throw new System.NotImplementedException();
        }

        public int update(int Id, Category item)
        {
            throw new System.NotImplementedException();
        }
    }
}
