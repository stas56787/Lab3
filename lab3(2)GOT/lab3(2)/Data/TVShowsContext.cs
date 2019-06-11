using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Models;

namespace lab3.Data
{
    public class TVShowsContext
    {
        public static List<TVShow> GetAll()
        {
            List<TVShow> all = new List<TVShow>();
            using (Context db = new Context())
            {
                all = db.TVShows.ToList();
            }

            return all;
        }

        public static void AddTVShow(TVShow tvShowToAdd)
        {
            using (Context db = new Context())
            {
                db.TVShows.Add(tvShowToAdd);
                db.SaveChanges();
            }
        }

        public static void UpdataTVShow(TVShow tvShow)
        {
            using (Context db = new Context())
            {
                if (tvShow != null)
                {
                    db.TVShows.Update(tvShow);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteTVShow(TVShow tvShowToDelete)
        {
            using (Context db = new Context())
            {
                if (tvShowToDelete != null)
                {
                    db.TVShows.Remove(tvShowToDelete);
                    db.SaveChanges();
                }
            }
        }

        public static List<TVShow> FindTVShows(string nameShow, string duration)
        {
            List<TVShow> tvShows = new List<TVShow>();
            using (Context db = new Context())
            {
                if (nameShow != null && nameShow != "")
                {
                    tvShows = db.TVShows.Where(k => k.NameShow == nameShow).ToList();
                }
                if (duration != null && duration != "")
                {
                    if (tvShows.Count != 0)
                    {
                        tvShows = tvShows.Where(k => k.Duration == duration).ToList();
                    }
                    else
                    {
                        tvShows = db.TVShows.Where(k => k.Duration == duration).ToList();
                    }
                }
            }
            return tvShows;
        }

        public static TVShow FindTVShowById(int id)
        {
            TVShow tvShows = null;
            using (Context db = new Context())
            {
                tvShows = db.TVShows.Where(k => k.TVShowID == id).ToList().FirstOrDefault();
            }
            return tvShows;
        }
    }
}
