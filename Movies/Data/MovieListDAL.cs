using Movies.Interfaces;
using Movies.Models;
using System.Collections.Generic;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        //private static List<Movie> MovieList = new List<Movie>
        //{
        //    new Movie("Lion King",1994,4f),
        //    new Movie("Trip to the Moon",1902,5f),
        //    new Movie("Megamind",2010,5f),
        //};

        private AppDbContext db;

        public MovieListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddMovie(Movie movie)
        {
            //MovieList.Add(movie);
            db.Movies.Add(movie);
            db.SaveChanges(); // don't forget to save
        }

        public void EditMovie(Movie movie)
        {
            //int i;
            //i = GetMovieByMovie(movie);
            //MovieList[i] = movie;
            db.Movies.Update(movie);
            db.SaveChanges();
        }

        public Movie GetMovieById(int? id)
        {
            //return MovieList.Where(m=> m.Id == id).FirstOrDefault();
            return db.Movies.Where(m => m.Id == id).FirstOrDefault();            
        }

        public IEnumerable<Movie> GetMovies()
        {
            //return MovieList;
            return db.Movies.OrderBy(m => m.Year).ToList();
        }

        public void RemoveMovie(int? id)
        {
            Movie foundMovie = GetMovieById(id);
            //MovieList.Remove(foundMovie);
            db.Movies.Remove(foundMovie);
            db.SaveChanges();
        }

        public IEnumerable<Movie> FilterMovies(string genre, string mparating)
        {
            if(genre == null)
            {
                genre = "";
            }
            if(mparating == null)
            {
                mparating = "";
            }

            if(genre == "" && mparating == "")
            {
                return GetMovies();
            }

            IEnumerable < Movie > lstMovies = GetMovies().Where
                (m => (!string.IsNullOrEmpty(m.Genre)) && m.Genre.ToLower().Contains(genre.ToLower())).ToList();
            IEnumerable<Movie> lstMovies2 = lstMovies.Where
                (m => (!string.IsNullOrEmpty(m.MPARating)) && m.MPARating.ToLower().Equals(mparating.ToLower())).ToList();

            if(lstMovies2.Count() <= 0)
            {
                return lstMovies;
            }
            return lstMovies2;
        }
    }
}
