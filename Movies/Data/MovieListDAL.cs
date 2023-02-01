using Movies.Interfaces;
using Movies.Models;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie("Lion King",1994,4f),
            new Movie("Trip to the Moon",1902,5f),
            new Movie("Megamind",2010,5f),
        };

        public void AddMovie(Movie movie)
        {
            MovieList.Add(movie);
        }

        public void EditMovie(Movie movie)
        {
            int i;
            i = GetMovieByMovie(movie);
            MovieList[i] = movie;
        }

        public Movie GetMovieById(int? id)
        {
            return MovieList.Where(m=> m.Id == id).FirstOrDefault();
            
        }

        public int GetMovieByMovie(Movie movie)
        {
            return MovieList.FindIndex(x => x.Id == movie.Id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MovieList;
        }

        public void RemoveMovie(int? id)
        {
            Movie foundMovie = GetMovieById(id);
            MovieList.Remove(foundMovie);
        }
    }
}
