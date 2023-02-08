using Movies.Models;
using System.Collections.Generic;

namespace Movies.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Movie> GetMovies();
        void AddMovie(Movie movie);
        void RemoveMovie(int? id);
        Movie GetMovieById(int? id);
        //int GetMovieByMovie(Movie movie);
        void EditMovie(Movie movie);
        IEnumerable<Movie> FilterMovies(string genre, string mparating);
    }
}
