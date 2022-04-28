using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelSite.Models;

namespace OtelSite.BLL
{

    public class RoomsTypeRepository : IRepository<RoomsType>
        {
            OtelSiteEntities db = new OtelSiteEntities();
            public List<RoomsType> Listele()
            {
                return db.RoomsTypes.ToList();
            }

            public RoomsType IdyeGore(Guid id)
            {
                return db.RoomsTypes.Find(id);
            }

            public bool Ekle(RoomsType eklenecek)
            {
                bool sonuc = false;
                try
                {
                    db.RoomsTypes.Add(eklenecek);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }

            public bool Guncelle(RoomsType guncellenecek)
            {
                bool sonuc = false;
                try
                {

                    Customer eski = db.Customers.FirstOrDefault(p => p.Id == guncellenecek.Id);
                    db.Entry(eski).CurrentValues.SetValues(guncellenecek);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }

            public bool Sil(Guid id)
            {
                bool sonuc = false;
                try
                {
                    RoomsType silinecek = db.RoomsTypes.Find(id);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }
        }
    
}