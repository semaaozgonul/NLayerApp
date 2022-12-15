using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Product:BaseEntity
    {
        //public Product(string name)
        //{
        //    Name = name ?? throw new ArgumentNullException(nameof(Name));
        //} bu şekilde Category ve ProductFeature çizgili gelir tanımlanmadı cünkü.
        
        //Nullable check özelliği kapatılabilir
        //tırtık üzerinde düzeltmelerden .editorcomfig oluşturulabilir.
        //Manuel olarak properties of file değiştirilebilir.  

        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } //bu ve alt satır Navigation property
        public ProductFeature ProductFeature { get; set; }//çünkü product cıkıslı veya tersi yönde gidilebilir.
    }
}
