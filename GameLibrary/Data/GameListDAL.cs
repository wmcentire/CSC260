using GameLibrary.Interfaces;
using GameLibrary.Models;

namespace GameLibrary.Data
{
    public class GameListDAL : IDataAccessLayer
    {
        /*public static List<Game> games = new List<Game> {
            new Game("Dwarf Fortress",
                    26.99,
                    4.5f,
                    "https://media.discordapp.net/attachments/1068360348165476355/1072003273944469504/dwarffortressimage.png",
                    "Steam",
                    "Colony Sim",
                    "Not Rated"),
            new Game("Deep Rock Galactic",
                    29.99,
                    4.9f,
                    "https://media.discordapp.net/attachments/1068360348165476355/1072003273357283439/DRG.jpg",
                    "Steam",
                    "FPS PvE",
                    "Teen"),
            new Game("Persona 5 Royal",
                    29.99,
                    4.7f,
                    "https://media.discordapp.net/attachments/1068360348165476355/1072003274166784020/persona-5-royal.jpg?width=1406&height=791",
                    "PS4/PS5",
                    "Life Sim/JRPG",
                    "Mature"),
            new Game("Hollow Knight",
                    15,
                    4.8f,
                    "https://media.discordapp.net/attachments/1068360348165476355/1072003273608933416/HollowKnight.jpg?width=1406&height=791",
                    "Steam/PS4/XBOX/Switch",
                    "Metroidvania",
                    "E10+"),
            new Game("Slime Rancher",
                    19.99,
                    4.5f,
                    "https://media.discordapp.net/attachments/1068360348165476355/1072003274414239824/Slime-Rancher-1280x640.jpg",
                    "Steam/XBOX",
                    "Fantasy Management",
                    "E10+")


        //};*/

        private AppDbContext db;

        public GameListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddGame(Game game)
        {
            db.games.Add(game);
            db.SaveChanges();
        }

        public void EditGame(Game game)
        {
            db.games.Update(game);
            db.SaveChanges();
        }

        public Game GetGameById(int? id)
        {
            return db.games.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Game> GetCollection()
        {
            return db.games.OrderBy(g => g.Rating).ToList(); ;
        }

        public void RemoveGame(int? id)
        {
            Game game = GetGameById(id);
            db.games.Remove(game);
            db.SaveChanges();
        }

        public IEnumerable<Game> SearchForGames(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return db.games;
            }

            return db.games.Where(c => c.Title.ToLower().Contains(key.ToLower()));
        }
    }
}
