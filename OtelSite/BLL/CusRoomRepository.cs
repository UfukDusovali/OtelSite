using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelSite.Models;

namespace OtelSite.BLL
{

    public class CusRoomRepository : IRepository<CusRoom>
        {
            OtelSiteEntities db = new OtelSiteEntities();
            public List<CusRoom> Listele()
            {
                return db.CusRooms.ToList();
            }

            public CusRoom IdyeGore(Guid id)
            {
                return db.CusRooms.Find(id);
            }

            public bool Ekle(CusRoom eklenecek)
            {
                bool sonuc = false;
                try
                {
                    db.CusRooms.Add(eklenecek);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }

            public bool Guncelle(CusRoom guncellenecek)
            {
                bool sonuc = false;
                try
                {

                    CusRoom eski = db.CusRooms.FirstOrDefault(p => p.Id == guncellenecek.Id);
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
                    CusRoom silinecek = db.CusRooms.Find(id);
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