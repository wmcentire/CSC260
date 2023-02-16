using GameLibrary.Models;
namespace GameLibrary.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Game> GetCollection();
        void AddGame(Game game);
        void RemoveGame(int? id);
        Game GetGameById(int? id);
        void EditGame(Game Game);
        IEnumerable<Game> SearchForGames(string key);
        public IEnumerable<Game> FilterGames(string platform, string esrb);
        
    }
}
