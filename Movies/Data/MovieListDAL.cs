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
            
        }

        public Movie GetMovieById(int? id)
        {
            foreach(Movie movie in MovieList)
            {
                if(movie.Id == id)
                {
                    return movie;
                }
            }
            return null;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MovieList;
        }

        public void RemoveMovie(int? id)
        {
            
        }
    }
}
