using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Models;

namespace lab3.Data
{
    public class GenresContext
    {
        public static List<Genre> GetAll()
        {
            List<Genre> all = new List<Genre>();
            using (Context db = new Context())
            {
                all = db.Genres.ToList();
            }

            return all;
        }

        public static void AddGenre(Genre genre)
        {
            using (Context db = new Context())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
        }

        public static void UpdataGenre(Genre genre)
        {
            using (Context db = new Context())
            {
                if (genre != null)
                {
                    db.Genres.Update(genre);
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteGenre(Genre genre)
        {
            using (Context db = new Context())
            {
                if (genre != null)
                {
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
            }
        }

        public static List<Genre> FindGenre(string genreName, string descriptionOfGenre)
        {
            List<Genre> genres = new List<Genre>();
            using (Context db = new Context())
            {
                if (genreName != null && genreName != "")
                {
                    genres = db.Genres.Where(k => k.NameGenre == genreName).ToList();
                }
                if (descriptionOfGenre != null && descriptionOfGenre != "")
                {
                    if (genres.Count != 0)
                    {
                        genres = genres.Where(k => k.DescriptionOfGenre == descriptionOfGenre).ToList();
                    }
                    else
                    {
                        genres = db.Genres.Where(k => k.DescriptionOfGenre == descriptionOfGenre).ToList();
                    }
                }
            }
            return genres;
        }

        public static Genre FindGenreById(int id)
        {
            Genre genre = null;
            using (Context db = new Context())
            {
                genre = db.Genres.Where(k => k.GenreID == id).ToList().FirstOrDefault();
            }
            return genre;
        }
    }
}
