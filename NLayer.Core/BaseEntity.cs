using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity// abstract: Base Entity'den bir nesne örneği  alınmasın
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }//null olamaz
        public DateTime? UpdatedDate { get; set; }//ilk önce null olabilir.

    }
}
