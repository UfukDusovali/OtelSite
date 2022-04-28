using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelSite.BLL
{
    interface IRepository<T> where T : class
    {
        List<T> Listele();

        T IdyeGore(Guid id);

        bool Ekle(T eklenecek);

        bool Guncelle(T guncellenecek);

        bool Sil(Guid id);
    }
}
