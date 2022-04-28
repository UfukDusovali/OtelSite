using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OtelSite.Models;

namespace OtelSite.BLL
{

    public class CustomerRepository : IRepository<Customer>
        {
            OtelSiteEntities db = new OtelSiteEntities();
            public List<Customer> Listele()
            {
                return db.Customers.ToList();
            }

            public Customer IdyeGore(Guid id)
            {
                return db.Customers.Find(id);
            }

            public bool Ekle(Customer eklenecek)
            {
                bool sonuc = false;
                try
                {
                    db.Customers.Add(eklenecek);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                catch (Exception)
                {
                    return sonuc;
                }
            }

            public bool Guncelle(Customer guncellenecek)
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
                    Customer silinecek = db.Customers.Find(id);
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