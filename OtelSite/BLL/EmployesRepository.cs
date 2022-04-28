using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelSite.Models;

namespace OtelSite.BLL
{

    public class EmployesRepository : IRepository<Employess>
    {
        OtelSiteEntities db = new OtelSiteEntities();
        public List<Employess> Listele()
        {
            return db.Employesses.ToList();
        }

        public Employess IdyeGore(Guid id)
        {
            return db.Employesses.Find(id);
        }

        public bool Ekle(Employess eklenecek)
        {
            bool sonuc = false;
            try
            {
                db.Employesses.Add(eklenecek);
                sonuc = db.SaveChanges() > 0;
                return sonuc;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }

        public bool Guncelle(Employess guncellenecek)
        {
            bool sonuc = false;
            try
            {

                Employess eski = db.Employesses.FirstOrDefault(p => p.Id == guncellenecek.Id);
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
                Employess silinecek = db.Employesses.Find(id);
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