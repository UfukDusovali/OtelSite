using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelSite.Models;


namespace OtelSite.BLL
{

    public class RoomRepository : IRepository<Room>
        {
            OtelSiteEntities db = new OtelSiteEntities();
            public List<Room> Listele()
            {
                return db.Rooms.ToList();
            }

            public Room IdyeGore(Guid id)
            {
                return db.Rooms.Find(id);
            }

            public bool Ekle(Room eklenecek)
            {
                bool sonuc = false;
                try
                {
                    db.Rooms.Add(eklenecek);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }

            public bool Guncelle(Room guncellenecek)
            {
                bool sonuc = false;
                try
                {

                    Room eski = db.Rooms.FirstOrDefault(p => p.Id == guncellenecek.Id);
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
                    Room silinecek = db.Rooms.Find(id);
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