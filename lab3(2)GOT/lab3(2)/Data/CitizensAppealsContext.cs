using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Models;

namespace lab3.Data
{
    public class CitizensAppealsContext
    {
        public static List<CitizensAppeal> GetAll()
        {
            List<CitizensAppeal> all = new List<CitizensAppeal>();
            using (Context db = new Context())
            {
                all = db.CitizensAppeals.ToList();
            }

            return all;
        }

        public static void AddCitizensAppeal(CitizensAppeal citizensAppealToAdd)
        {
            using (Context db = new Context())
            {
                db.CitizensAppeals.Add(citizensAppealToAdd);
                db.SaveChanges();
            }
        }

        public static void UpdataCitizensAppeal(CitizensAppeal citizensAppeal)
        {
            using (Context db = new Context())
            {
                if (citizensAppeal != null)
                {
                    db.CitizensAppeals.Update(citizensAppeal);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteCitizensAppeal(CitizensAppeal citizensAppealToDelete)
        {
            using (Context db = new Context())
            {
                if (citizensAppealToDelete != null)
                {
                    db.CitizensAppeals.Remove(citizensAppealToDelete);
                    db.SaveChanges();
                }
            }
        }

        public static List<CitizensAppeal> FindCitizensAppeal(string lfo, string organization)
        {
            List<CitizensAppeal> services = new List<CitizensAppeal>();
            using (Context db = new Context())
            {
                if (lfo != null && lfo != "")
                {
                    services = db.CitizensAppeals.Where(k => k.LFO == lfo).ToList();
                }
                if (organization != null)
                {
                    if (services.Count != 0)
                    {
                        services = services.Where(k => k.Organization == organization).ToList();
                    }
                    else
                    {
                        services = db.CitizensAppeals.Where(k => k.Organization == organization).ToList();
                    }
                }
            }
            return services;
        }

        public static CitizensAppeal FindCitizensAppeal(int id)
        {
            CitizensAppeal citizensAppeal = null;
            using (Context db = new Context())
            {
                citizensAppeal = db.CitizensAppeals.Where(k => k.CitizensAppealID == id).ToList().FirstOrDefault();
            }
            return citizensAppeal;
        }
    }
}
