using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class // bu bizim için class olacak
    {
        Task<T> GetByIdAsync(int id);//geriiye bir t entity dönecek idye göre data dön,asenkron metod old. async verdik, int id yi alacak
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        IQueryable<T> where(Expression<Func<T,bool>> expression);
        //IQueryable ile yazılan sorgular direkt veritabanına gitmez, mutlaka tolist veya tolistasync ile direkt gider
        // whereden sonra özellikle bunu yaptık ki orderby yapalim veya başka sorgular yazabilelim
        //burada async değil çünkü buradaveri tabanına sorgu yapmadık,veritabanına yapılacak olan sorguyu oluşturuyoruz.
            //productRepository.where(x=>x.id>5).ToListAsync();
        //Expression oluşturma amacı:where() kısmından ıqueryable döner sorgu yapmadık daha,işlemlere devaö edebiliriz
        //ama ne zaman tolist yapısı eklenirse o zaman db ye sorgu yapacak.
        //eğer list dersek where()  kısmını direkt db den ceker çektiği datayı memorye alır aldıktan sonra orderby yapar.
        //IQUERYABLE ile whereden sonra orrder by ı da alır sonra veritabanından sıralı olarak çeker.
        //where deki x öyleki kısmı için expression ile func delegesi yazıcaz tipi func delegesi alacak,delege: metodları işsaret eden yapılar
        //<func<t,bool>> x= t entity,x.id>5= bool kısmı true/false
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //anyde bool döndük var mı yok mu örnek olarak
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        //bidern fazla kaydetme için range ini ekliyoruz, list değil interface aldık.
        //abstract class ve interfacelerle calişmak önemli(soyut nesneler)
        //new anahtar sözcüğü ile nesne örneği alamayız
        void Update(T entity);
        //neden async değil(update ve delete) cunku bunların asenkron metodları yok efcore tarafında gerek de yok
        //efcore memory e alıp takip ettiği ürünün sadece state ini classın sadece state ini değiştiriyor
        //uzun sürmediği için async yapısı yok
        //bıseyı update etmek için entity vermek lazım ve verdıgımız entity zaten memoryde efcore takip ediyor
        //update edince sadece o memoryde takip edilen entitynin state ini modified olarak değiştiriyor.
        //add yeni ürün ekliyor uzun süren bi işlem bu yüzden bunun bir async si var.
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
