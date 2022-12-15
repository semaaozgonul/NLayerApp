using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class // bunun da bir class olacagını belirttik
    {
        Task<T> GetByIdAsync(int id);//geriiye bir t entity dönecek idye göre data dön,asenkron metod old. async verdik, int id yi alacak
        Task<IEnumerable<T>> GetAllAsync();//farklılık olsun diye azdık aynı da kalabilir.
        IQueryable<T> where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //anyde bool döndük var mı yok mu örnek olarak
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);//bu servisde değişiklikleri veritabanına kaydedeceğimiz için ve
        Task RemoveAsync(T entity);//SaveChangeAsync() metodu kullanacagım için düzenlemeleri bu sekilde yaptım.
        Task RemoveRangeAsync(IEnumerable<T> entities);


    }
}
