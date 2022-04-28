using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelSite.Models;

namespace OtelSite.BLL
{

    public class RervRoomDateRepository : IRepository<RervRoomDate>
        {
            OtelSiteEntities db = new OtelSiteEntities();
            public List<RervRoomDate> Listele()
            {
                return db.RervRoomDates.ToList();
            }

            public RervRoomDate IdyeGore(Guid id)
            {
                return db.RervRoomDates.Find(id);
            }
            public RervRoomDate Tarih(DateTime date)
            {
                return db.RervRoomDates.Find(date);
            }

            public bool Ekle(RervRoomDate eklenecek)
            {
                bool sonuc = false;
                try
                {
                    db.RervRoomDates.Add(eklenecek);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }

            public bool Guncelle(RervRoomDate guncellenecek)
            {
                bool sonuc = false;
                try
                {

                    RervRoomDate eski = db.RervRoomDates.FirstOrDefault(p => p.Id == guncellenecek.Id);
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
                    RervRoomDate silinecek = db.RervRoomDates.Find(id);
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