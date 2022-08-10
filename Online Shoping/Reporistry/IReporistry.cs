using System.Collections.Generic;

namespace Online_Shoping.Reporistry
{
    public interface IReporistry<T>where T : class
    {
        int insert(T item);
        int update(int Id, T item);
        int delete(int Id);

        List<T> GetAll();
    }
}
